using FD.ShortUrl.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Text.RegularExpressions;

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

        public ArrayExample? _array { get; private set; } = new ArrayExample();
        [HttpGet]
        public IActionResult GetArray()
        {
            if (_array == null)
            {
                throw new ArgumentNullException(nameof(_array));
            }
            _array = _config.GetSection("array").Get<ArrayExample>();
            string s = String.Empty;

            for (int j = 0; j < _array.Entries.Length; j++)
            {
                s += $"Index: {j}  Value:  {_array.Entries[j]} \n";
            }

            return Content(s);
        }

        [HttpGet]
        public IActionResult GetCustomer()
        {
            var quote1 = _config["quote1"];
            var quote2 = _config["quote2"];
            var quote3 = _config["quote3"];
         
            return Content($"quote1 value: {quote1} \n" +
                         $"quote2: {quote2} \n" +
                         $"quote3: {quote3} \n");
        }

        

    }
}
