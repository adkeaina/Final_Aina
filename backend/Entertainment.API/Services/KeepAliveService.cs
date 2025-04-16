using Entertainment.API.Data;
using Microsoft.EntityFrameworkCore;

namespace Entertainment.API.Services
{
    public class KeepAliveService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;

        public KeepAliveService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var db = scope.ServiceProvider.GetRequiredService<EntertainmentDbContext>();

                    try
                    {
                        await db.Database.ExecuteSqlRawAsync("SELECT 1", cancellationToken: stoppingToken);
                        Console.WriteLine($"[KeepAlive] Pinged DB at {DateTime.Now}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"[KeepAlive] Failed to ping DB: {ex.Message}");
                    }
                }

                await Task.Delay(TimeSpan.FromMinutes(5), stoppingToken);
            }
        }
    }
}