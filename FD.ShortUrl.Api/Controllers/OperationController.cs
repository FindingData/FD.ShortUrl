using FD.ShortUrl.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.Text.Json;

namespace FD.ShortUrl.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public OperationController(IHttpClientFactory httpClientFactory) =>
            _httpClientFactory = httpClientFactory;

        public IEnumerable<ShortUrlPO>? GitHubBranches { get; set; }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,"/api/Index");
            

            var httpClient = _httpClientFactory.CreateClient("Operation");
            using var httpResponseMessage =
                await httpClient.SendAsync(request);


            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var contentStream =
                    await httpResponseMessage.Content.ReadAsStreamAsync();

                return Content(await httpResponseMessage.Content.ReadAsStringAsync());
            }
            return NotFound();

        }
    }
}
