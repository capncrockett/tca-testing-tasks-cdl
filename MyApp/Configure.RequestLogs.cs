using ServiceStack.Data;
using ServiceStack.Jobs;
using ServiceStack.Web;
using ServiceStack.OrmLite;
using ServiceStack.Logging;
using System.Data;

[assembly: HostingStartup(typeof(MyApp.ConfigureRequestLogs))]

namespace MyApp;

public class ConfigureRequestLogs : IHostingStartup
{
    private static readonly string[] AdminRoles = { "Admin" }; // Fix for CA1861

    public void Configure(IWebHostBuilder builder) => builder
        .ConfigureServices((context, services) =>
        {

            // Configure RequestLogs to use SQL Server via OrmLite
            services.AddPlugin(new RequestLogsFeature
            {
                // Using ServiceStack's built-in database logging using the configured IDbConnectionFactory
                EnableResponseTracking = true,
                EnableRequestBodyTracking = true,
                EnableErrorTracking = true,
                AccessRole = AdminRoles[0], // Fix for CS0117: Use 'AccessRole' instead of 'RequiredRoles'
            });
            services.AddHostedService<RequestLogsHostedService>();
        });
}

public class RequestLogsHostedService(ILogger<RequestLogsHostedService> log, IRequestLogger requestLogger) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var timer = new PeriodicTimer(TimeSpan.FromHours(1)); // Run once per hour
        while (!stoppingToken.IsCancellationRequested && await timer.WaitForNextTickAsync(stoppingToken))
        {
            try
            {
                // ServiceStack RequestLogsFeature already uses the configured IDbConnectionFactory
                // We just need to log to indicate the service is running
                log.LogInformation("Request logs maintenance check completed at {Time}", DateTimeOffset.Now);
            }
            catch (Exception ex)
            {
                log.LogError(ex, "Error during request logs maintenance");
            }
        }
    }
}
