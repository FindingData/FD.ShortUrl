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

        public ConfigBindController(IOptions<PositionOption> options)
        {
            _options = options.Value;
        }

        [HttpGet]
        [HttpGet]
        public IActionResult Index()
        {
            return Content($"Title: {_options.Title} \n" +
                        $"Value: {_options.Value} \n" +
                     $"Name: {_options.Name}");
        }
    }
}
