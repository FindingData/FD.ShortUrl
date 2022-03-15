using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FD.ShortUrl.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndexController : ControllerBase
    {
        private IConfigurationRoot _configRoot;

        public IndexController(IConfiguration configRoot) {
            _configRoot = (IConfigurationRoot)configRoot;
        }

        [HttpGet]
        public IActionResult Home()
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
