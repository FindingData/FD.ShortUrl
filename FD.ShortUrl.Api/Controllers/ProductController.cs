using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FD.ShortUrl.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        
        private readonly ProductsMiddleware _middleware;

        public ProductController(ProductsMiddleware middleware)
        {
            _middleware = middleware;
        }

        
        [HttpGet]
        public async void Index()
        {
            
            await _middleware.InvokeAsync(HttpContext);            
        }
    }

}
