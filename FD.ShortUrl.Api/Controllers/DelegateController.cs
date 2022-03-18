using FD.ShortUrl.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.Text.Json;

namespace FD.ShortUrl.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DelegateController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DelegateController(IHttpClientFactory httpClientFactory) =>
            _httpClientFactory = httpClientFactory;

        public IEnumerable<ShortUrlPO>? GitHubBranches { get; set; }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
      "/api/ShortUrls")
            {
                Headers =
            {
                { "X-API-KEY", "123456789" },              
            }
            };

            var httpClient = _httpClientFactory.CreateClient("HttpMessageHandler");
            using var httpResponseMessage =
                await httpClient.SendAsync(request);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var contentStream =
                    await httpResponseMessage.Content.ReadAsStreamAsync();

                GitHubBranches = await JsonSerializer.DeserializeAsync
                    <IEnumerable<ShortUrlPO>>(contentStream);
                return Content(JsonSerializer.Serialize(GitHubBranches));
            }
            else
            {                
                return Content(await httpResponseMessage.Content.ReadAsStringAsync());
            }
            
        }
    }
}
