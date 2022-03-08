using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FD.ShortUrl.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigSectionController : ControllerBase
    {
        private readonly IConfiguration _config;

        public ConfigSectionController(IConfiguration config)
        {
            _config = config.GetSection("section2:subsection0");
        }

        
        [HttpGet]
        public IActionResult Index()
        {
            return Content(
               $"section2:subsection0:key0 '{_config["key0"]}'\n" +
               $"section2:subsection0:key1:'{_config["key1"]}'");
        }
    }
}
