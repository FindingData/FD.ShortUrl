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
            var eKeyValue = _config["EKey"];
            var title = _config["PositionOptions:Title"];
            var name = _config["PositionOptions:Name"];
            var defaultLogLevel = _config["Logging:LogLevel:Default"];

            return Content($"MyKey value: {myKeyValue} \n" +
                           $"EKey: {eKeyValue} \n" +
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

        [HttpGet]
        public IActionResult CommandLine()
        {
            return Content(
                    $"Key1: '{_config["Key1"]}'\n" +
                    $"Key2: '{_config["Key2"]}'\n" +
                    $"Key3: '{_config["Key3"]}'\n" +
                    $"Key4: '{_config["Key4"]}'\n" +
                    $"Key5: '{_config["Key5"]}'\n" +
                    $"Key6: '{_config["Key6"]}'");
        }


        [HttpGet]
        public IActionResult Memory()
        {
            var myKeyValue = _config["MyKey"];
            var title = _config["Position:Title"];
            var name = _config["Position:Name"];
            var defaultLogLevel = _config["Logging:LogLevel:Default"];


            return Content($"MyKey value: {myKeyValue} \n" +
                           $"Title: {title} \n" +
                           $"Name: {name} \n" +
                           $"Default Log Level: {defaultLogLevel}");
        }

        [HttpGet]
        public IActionResult GetValue()
        {
            var number = _config.GetValue<int>("NumberKey", 99);
            return Content($"{number}");
        }

    }
}
