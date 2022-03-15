using Microsoft.AspNetCore.Mvc;

namespace FD.ShortUrl.Api.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Content("index");
        }

        public IActionResult SubIndex()
        {
            return Content("subIndex");
        }
    }
}
