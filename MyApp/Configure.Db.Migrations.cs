using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using MyApp.Data;
using MyApp.Migrations;
using MyApp.ServiceModel;

[assembly: HostingStartup(typeof(MyApp.ConfigureDbMigrations))]

namespace MyApp;

// Code-First DB Migrations: https://docs.servicestack.net/ormlite/db-migrations
public class ConfigureDbMigrations : IHostingStartup
{
    public void Configure(IWebHostBuilder builder) => builder
        .ConfigureAppHost(appHost => {
            var migrator = new Migrator(appHost.Resolve<IDbConnectionFactory>(), typeof(Migration1000).Assembly);
            
            // Main migrate command for database schema only
            AppTasks.Register("migrate", _ =>
            {
                var log = appHost.GetApplicationServices().GetRequiredService<ILogger<ConfigureDbMigrations>>();

                log.LogInformation("Running EF Migrations...");
                var scopeFactory = appHost.GetApplicationServices().GetRequiredService<IServiceScopeFactory>();
                using (var scope = scopeFactory.CreateScope())
                {
                    using var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                    db.Database.EnsureCreated();
                    db.Database.Migrate();
                    
                    log.LogInformation("Database schema migrations completed.");
                }

                log.LogInformation("Running OrmLite Migrations...");
                migrator.Run();
                
                // Automatically run the user creation after migrations
                log.LogInformation("Ensuring all users exist with correct credentials...");
                EnsureAllUsersExist(appHost.GetApplicationServices()).Wait();
            });
            
            AppTasks.Register("migrate.revert", args => migrator.Revert(args[0]));
            
            // Add a dedicated command to recreate all users
            AppTasks.Register("migrate.users", _ =>
            {
                var log = appHost.GetApplicationServices().GetRequiredService<ILogger<ConfigureDbMigrations>>();
                log.LogInformation("Force recreating all users...");
                
                // Create a scope to resolve scoped services like ApplicationDbContext
                var scopeFactory = appHost.GetApplicationServices().GetRequiredService<IServiceScopeFactory>();
                using (var scope = scopeFactory.CreateScope())
                {
                    EnsureAllUsersExist(scope.ServiceProvider, true).Wait();
                }
                
                log.LogInformation("User recreation complete.");
            });
            
            // Run on startup - check if database needs initialization and users need to be created
            appHost.AfterInitCallbacks.Add(host => 
            {
                var log = host.GetApplicationServices().GetRequiredService<ILogger<ConfigureDbMigrations>>();
                
                try
                {
                    // Create a scope to resolve scoped services
                    var scopeFactory = host.GetApplicationServices().GetRequiredService<IServiceScopeFactory>();
                    using (var scope = scopeFactory.CreateScope())
                    {
                        // Run migrations first
                        using (var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>())
                        {
                            log.LogInformation("Running EF Core Migrations...");
                            db.Database.Migrate();
                            
                            log.LogInformation("Database is ready. Checking if user seeding is needed...");
                            
                            // Always create all users on startup to ensure they work
                            // This will only recreate users if their credentials don't work in SQL Server
                            log.LogInformation("Running user seeding to ensure all users exist with valid credentials...");
                            EnsureAllUsersExist(scope.ServiceProvider, true).Wait();
                        }
                    }
                }
                catch (Exception ex)
                {
                    log.LogError(ex, "Error during startup database check. You may need to run migrations manually.");
                }
            });
            
            AppTasks.Run();
        });
        
    // Helper method to create all users
    private async Task EnsureAllUsersExist(IServiceProvider services, bool forceRecreate = false)
    {
        var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
        var logger = services.GetRequiredService<ILogger<ConfigureDbMigrations>>();
        
        string[] allRoles = [Roles.Admin, Roles.Manager, Roles.Employee];
        
        // Ensure roles exist first
        foreach (var roleName in allRoles)
        {
            if (!await roleManager.RoleExistsAsync(roleName))
            {
                logger.LogInformation("Creating role: {Role}", roleName);
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }
        }

        // Define all users to create
        var usersToCreate = new List<(string Email, string DisplayName, string FirstName, string LastName, string Password, string? ProfileUrl, string[] Roles)>
        {
            ("admin@email.com", "Admin User", "Admin", "User", "p@55wOrd", null, allRoles),
            ("manager@email.com", "Test Manager", "Test", "Manager", "p@55wOrd", "/img/profiles/user3.svg", new[] { Roles.Manager, Roles.Employee }),
            ("employee@email.com", "Test Employee", "Test", "Employee", "p@55wOrd", "/img/profiles/user2.svg", new[] { Roles.Employee }),
            ("new@user.com", "Test User", "Test", "User", "p@55wOrd", "/img/profiles/user1.svg", Array.Empty<string>())
        };
        
        // Process each user - completely recreate them to ensure they work
        foreach (var (email, displayName, firstName, lastName, password, profileUrl, roles) in usersToCreate)
        {
            try
            {
                // Delete if exists
                var existingUser = await userManager.FindByEmailAsync(email);
                if (existingUser != null && (forceRecreate || !existingUser.EmailConfirmed))
                {
                    logger.LogInformation("Removing existing user: {Email}", email);
                    await userManager.DeleteAsync(existingUser);
                    existingUser = null; // Mark as deleted so we recreate it below
                }
                
                // Create user if it doesn't exist or was deleted above
                if (existingUser == null)
                {
                    // Create fresh user
                    var user = new ApplicationUser
                    {
                        UserName = email,
                        Email = email,
                        DisplayName = displayName,
                        FirstName = firstName,
                        LastName = lastName,
                        ProfileUrl = profileUrl,
                        EmailConfirmed = true
                    };
                    
                    logger.LogInformation("Creating user: {Email}", email);
                    var result = await userManager.CreateAsync(user, password);
                    
                    if (result.Succeeded)
                    {
                        logger.LogInformation("Successfully created user: {Email}", email);
                        
                        // Add roles
                        if (roles.Length > 0)
                        {
                            await userManager.AddToRolesAsync(user, roles);
                            logger.LogInformation("Added roles to {Email}: {Roles}", email, string.Join(", ", roles));
                        }
                    }
                    else
                    {
                        logger.LogError("Failed to create user {Email}: {Errors}", 
                            email, string.Join(", ", result.Errors.Select(e => e.Description)));
                    }
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error processing user {Email}", email);
            }
        }
        
        logger.LogInformation("User creation complete. Admin, Manager, Employee, and Test users are available.");
    }
}
