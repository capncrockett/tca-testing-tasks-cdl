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
            
            // Run on startup - check if database needs initialization and users need to be created
            appHost.AfterInitCallbacks.Add(host => 
            {
                var log = host.GetApplicationServices().GetRequiredService<ILogger<ConfigureDbMigrations>>();
                log.LogInformation("Checking database and users on startup...");
                
                try 
                {
                    var scopeFactory = host.GetApplicationServices().GetRequiredService<IServiceScopeFactory>();
                    using (var scope = scopeFactory.CreateScope())
                    {
                        using var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                        
                        // Try to check if the database has been initialized
                        bool shouldInitDb = false;
                        try
                        {
                            // Check if we have users table with any users
                            shouldInitDb = !db.Users.Any();
                        }
                        catch (Exception ex)
                        {
                            // If we can't query, the database likely needs initialization
                            log.LogInformation("Database check failed, needs initialization: {Message}", ex.Message);
                            shouldInitDb = true;
                        }
                        
                        if (shouldInitDb)
                        {
                            log.LogInformation("Initializing database and creating users...");
                            
                            // Ensure database exists and schema is created
                            db.Database.EnsureCreated();
                            db.Database.Migrate();
                            
                            // Run OrmLite migrations
                            migrator.Run();
                            
                            // Create all users
                            EnsureAllUsersExist(host.GetApplicationServices()).Wait();
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
    private async Task EnsureAllUsersExist(IServiceProvider services)
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
            ("test@email.com", "Test User", "Test", "User", "p@55wOrd", "/img/profiles/user1.svg", Array.Empty<string>())
        };
        
        // Process each user - completely recreate them to ensure they work
        foreach (var (email, displayName, firstName, lastName, password, profileUrl, roles) in usersToCreate)
        {
            try
            {
                // Delete if exists
                var existingUser = await userManager.FindByEmailAsync(email);
                if (existingUser != null)
                {
                    logger.LogInformation("Removing existing user: {Email}", email);
                    await userManager.DeleteAsync(existingUser);
                }
                
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
            catch (Exception ex)
            {
                logger.LogError(ex, "Error processing user {Email}", email);
            }
        }
        
        logger.LogInformation("User creation complete. Admin, Manager, Employee, and Test users are available.");
    }
}
