using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace FD.ShortUrl.Api.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Content("index");
        }

        public IActionResult Bad()
        {
            return BadRequest("bad");
        }

        public IActionResult Miss()
        {
            return Problem(statusCode:StatusCodes.Status404NotFound);
        }


        public IActionResult SubIndex()
        {
            return Content("subIndex");
        }
     
        public IActionResult Throw() =>
    throw new Exception("Sample exception.");

        public IActionResult HttpThrow() =>
throw new HttpResponseException(StatusCodes.Status404NotFound, "HttpResponse exception.");

        [Route("/error")]
        public IActionResult HandleError() =>
    Problem();

        [Route("/error-development")]
        public IActionResult HandleErrorDevelopment(
    [FromServices] IHostEnvironment hostEnvironment)
        {
            if (!hostEnvironment.IsDevelopment())
            {
                return NotFound();
            }

            var exceptionHandlerFeature =
                HttpContext.Features.Get<IExceptionHandlerFeature>()!;

            return Problem(
                detail: exceptionHandlerFeature.Error.StackTrace,
                title: exceptionHandlerFeature.Error.Message);
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
