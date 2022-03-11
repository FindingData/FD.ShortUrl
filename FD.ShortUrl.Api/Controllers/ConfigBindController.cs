using FD.ShortUrl.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace FD.ShortUrl.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigBindController : ControllerBase
    {
        private readonly PositionOption _options;
        private readonly ILogger<ConfigBindController> _logger;

        public ConfigBindController(IOptions<PositionOption> options,
             ILogger<ConfigBindController> logger)
        {
            _options = options.Value;
            _logger = logger;

            try
            {
                var configValue = _options.Value;
            }
            catch (OptionsValidationException ex)
            {
                foreach (var failure in ex.Failures)
                {
                    _logger.LogError(failure);
                }
            }
        }

        [HttpGet]
        [HttpGet]
        public IActionResult Index()
        {
            string msg;
            try
            {
                msg = $"Name: {_options.Name} \n" +
                      $"Key1: {_options.Value} \n" +
                      $"Key2: {_options.Value2} \n";
            }
            catch (OptionsValidationException optValEx)
            {
                return Content(optValEx.Message);
            }
            return Content(msg);
        }
    }
}
