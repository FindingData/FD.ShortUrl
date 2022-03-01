using FD.ShortUrl.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FD.ShortUrl.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyServiceController : ControllerBase
    {
        private readonly Service1 _service1;
        private readonly Service2 _service2;
     

        public MyServiceController(Service1 service1, Service2 service2)
        {
            _service1 = service1;
            _service2 = service2;
          
        }


        [HttpGet]
        public IActionResult Index()
        {
            _service1.Write("MyService.OnGet");
            _service2.Write("MyService.OnGet");
            
            return Ok();
        }

    }
}
