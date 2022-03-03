using FD.ShortUrl.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FD.ShortUrl.Api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ConfigController : ControllerBase
    {
        private readonly IConfiguration _config;

        public ConfigController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var myKeyValue = _config["MyKey"];
            var title = _config["PositionOptions:Title"];
            var name = _config["PositionOptions:Name"];
            var defaultLogLevel = _config["Logging:LogLevel:Default"];

            return Content($"MyKey value: {myKeyValue} \n" +
                           $"Title: {title} \n" +
                           $"Name: {name} \n" +
                           $"Default Log Level: {defaultLogLevel}");
        }

        [HttpGet]
        public IActionResult Bind()
        {
            var positionOptions = new PositionOption();
            _config.GetSection(PositionOption.PositionOptions).Bind(positionOptions);

            return Content($"Title: {positionOptions.Title} \n" +
                           $"Name: {positionOptions.Name}");
        }



    }
}
