using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FD.ShortUrl.Api.Controllers
{
    [Route("")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {           
            return Ok("hello");
        }
    }
}
