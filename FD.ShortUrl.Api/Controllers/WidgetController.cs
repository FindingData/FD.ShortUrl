using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FD.ShortUrl.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WidgetController : ControllerBase
    {
        private readonly LinkGenerator _linkGenerator;

        public WidgetController(LinkGenerator linkGenerator) =>
            _linkGenerator = linkGenerator;

        public IActionResult Index()
        {
            var indexPath = _linkGenerator.GetPathByAction(
                HttpContext, values: new { id = 17 })!;

            return Content(indexPath);
        }

    }
}
