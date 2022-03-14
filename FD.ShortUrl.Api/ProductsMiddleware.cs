using System.Net.Mime;

namespace FD.ShortUrl.Api
{
    public class ProductsMiddleware
    {
        private readonly LinkGenerator _linkGenerator;

        public ProductsMiddleware(RequestDelegate next, LinkGenerator linkGenerator) =>
            _linkGenerator = linkGenerator;

        public async Task InvokeAsync(HttpContext httpContext)
        {
            httpContext.Response.ContentType = MediaTypeNames.Text.Plain;

            var productsPath = _linkGenerator.GetPathByAction("GetItems", "ShortUrl");

            await httpContext.Response.WriteAsync(
                $"Go to {productsPath} to see our products.");
        }
    }
}
