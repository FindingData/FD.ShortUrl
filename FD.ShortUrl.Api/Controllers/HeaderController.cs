using FD.ShortUrl.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.Text.Json;

namespace FD.ShortUrl.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeaderController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HeaderController(IHttpClientFactory httpClientFactory) =>
            _httpClientFactory = httpClientFactory;

        public IEnumerable<ShortUrlPO>? GitHubBranches { get; set; }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
        "/api/ShortUrls");

            var httpClient = _httpClientFactory.CreateClient("PropagateHeaders");
            var httpResponseMessage = await httpClient.SendAsync(request);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var contentStream =
                    await httpResponseMessage.Content.ReadAsStreamAsync();

                GitHubBranches = await JsonSerializer.DeserializeAsync
                    <IEnumerable<ShortUrlPO>>(contentStream);               
            }
            return Content(JsonSerializer.Serialize(GitHubBranches));
        }
    }
}
