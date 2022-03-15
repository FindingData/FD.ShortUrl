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

        [Route("{id}")]

        public IActionResult Index(int id) =>
        Content(Url.Action("Edit", new { id = id })!);

        public IActionResult Index()
        {
            var indexPath = _linkGenerator.GetPathByAction(
                HttpContext, values: new { id = 17 })!;

            var subscribePath = _linkGenerator.GetPathByAction(
                "Subscribe", "Home", new { id = 17 })!;

            //var subscribePath2 = _linkGenerator.GetPathByAction(
            //     "Subscribe", null!, new { id = 17 })!;

            var result = $"indexPath:{indexPath}\r\nsubscribePath:{subscribePath}\r\n";
            return Content(result);
        }       
    }
}
