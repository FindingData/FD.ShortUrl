using FD.ShortUrl.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FD.ShortUrl.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyDIController : ControllerBase
    {
        private readonly IMyDependency _myDependency;

        public MyDIController(IMyDependency myDependency,
       IEnumerable<IMyDependency> myDependencies)
        {

            Console.WriteLine(myDependency is DifferentDependency);

            var dependencyArray = myDependencies.ToArray();
            Console.WriteLine(dependencyArray[0] is MyDependency);
            Console.WriteLine(dependencyArray[1] is DifferentDependency);
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
