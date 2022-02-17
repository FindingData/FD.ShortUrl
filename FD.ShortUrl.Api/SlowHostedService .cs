namespace FD.ShortUrl.Api
{
    public class SlowHostedService : IHostedService
    {
        readonly ILogger<SlowHostedService> _logger;

        public SlowHostedService(ILogger<SlowHostedService> logger)
        {
            _logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("SlowHostedService started");
            return Task.CompletedTask;
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("SlowHostedService stopping...");
            await Task.Delay(10_000);
            _logger.LogInformation("SlowHostedService stopped");
        }
    }
}
