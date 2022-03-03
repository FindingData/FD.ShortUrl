using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FD.ShortUrl.Api.Controllers
{
    [Route("")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private IConfigurationRoot _configRoot;

        public HomeController(IConfiguration configRoot) {
            _configRoot = (IConfigurationRoot)configRoot;
        }

        [HttpGet]
        public IActionResult Index()
        {
            string str = "";
            foreach (var provider in _configRoot.Providers.ToList())
            {
                str += provider.ToString() + "\n";
            }
            return Ok(str);
        }
    }
}
