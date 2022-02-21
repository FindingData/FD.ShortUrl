using FD.ShortUrl.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FD.ShortUrl.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyDIController : ControllerBase
    {
        private readonly IMyDependency _myDependency;

        public MyDIController(IMyDependency myDependency)
        {
            _myDependency = myDependency;
        }

        [HttpGet]
        public IActionResult Index()
        {
            _myDependency.WriteMessage("myDependenncy");
            return Ok("myDependenncy");
        }         
    }
}
