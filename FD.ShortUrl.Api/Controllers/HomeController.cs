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

        public IActionResult Subscribe(int i)
        {
            try
            {
                var a = 100 / i;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("参数错误");
            }
            return Content("Subscribe");
        }
    }
}
