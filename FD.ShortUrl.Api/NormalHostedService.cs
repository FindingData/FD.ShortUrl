using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FD.ShortUrl.Api
{
    public class NormalHostedService : IHostedService
    {
        readonly ILogger<NormalHostedService> _logger;

        public NormalHostedService(ILogger<NormalHostedService> logger)
        {
            _logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("NormalHostedService started");
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("NormalHostedService stopped");
            return Task.CompletedTask;
        }
    }
}
