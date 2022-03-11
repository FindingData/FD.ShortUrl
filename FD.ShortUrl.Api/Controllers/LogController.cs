using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FD.ShortUrl.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private readonly ILogger _logger;

        //public LogController(ILogger<LogController> logger)
        //{
        //    _logger = logger;
        //}

        public LogController(ILoggerFactory logger)
        {
            _logger = logger.CreateLogger("LogController");
        }


        public void Index()
        {
             var message = $"LogController  visited at {DateTime.UtcNow.ToLongTimeString()}";
            _logger.LogInformation(message);
        }
    }
}
