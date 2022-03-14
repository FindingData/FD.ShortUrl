using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FD.ShortUrl.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoZeroesController : ControllerBase
    {
        [HttpGet("{id:noZeroes}")]
        public IActionResult Get(string id) =>
        Content(id);
    }
}
