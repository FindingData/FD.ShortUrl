namespace FD.ShortUrl.Api
{
    public class HostApplicationLifetimeEventsHostedService : IHostedService
    {
        private readonly IHostApplicationLifetime _hostApplicationLifetime;
        private readonly ILogger _logger;
        protected readonly IConfiguration _configuration;

        public HostApplicationLifetimeEventsHostedService(
            IHostApplicationLifetime hostApplicationLifetime,
            ILogger<HostApplicationLifetimeEventsHostedService> logger, 
            IConfiguration configuration)
        {

            _hostApplicationLifetime = hostApplicationLifetime;
            _logger = logger;
            _configuration = configuration;
        }


        public Task StartAsync(CancellationToken cancellationToken)
        {
            _hostApplicationLifetime.ApplicationStarted.Register(OnStarted);
            _hostApplicationLifetime.ApplicationStopping.Register(OnStopping);
            _hostApplicationLifetime.ApplicationStopped.Register(OnStopped);

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
            => Task.CompletedTask;

        private void OnStarted()
        {
            _logger.LogInformation(_configuration["PREFIX_MyKey"]);
            _logger.LogInformation(_configuration["MyKey"]);

            _logger.LogInformation("OnStarted...");
        }

        private void OnStopping()
        {
            _logger.LogInformation("OnStopping...");
        }

        private void OnStopped()
        {
            _logger.LogInformation("OnStopped...");
        }
    }
}
