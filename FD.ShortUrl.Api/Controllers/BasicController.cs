using FD.ShortUrl.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.Text.Json;

namespace FD.ShortUrl.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasicController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BasicController(IHttpClientFactory httpClientFactory) =>
            _httpClientFactory = httpClientFactory;

        public IEnumerable<GitHubBranch>? GitHubBranches { get; set; }

        public async Task<IActionResult> Index()
        {
            
            var httpRequestMessage = new HttpRequestMessage(
                HttpMethod.Get,
                "https://api.github.com/repos/dotnet/AspNetCore.Docs/branches")
            {
                Headers =
            {
                { HeaderNames.Accept, "application/vnd.github.v3+json" },
                { HeaderNames.UserAgent, "HttpRequestsSample" }
            }
            };

            var httpClient = _httpClientFactory.CreateClient();
            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var contentStream =
                    await httpResponseMessage.Content.ReadAsStreamAsync();

                GitHubBranches = await JsonSerializer.DeserializeAsync
                    <IEnumerable<GitHubBranch>>(contentStream);               
            }
            return Content(JsonSerializer.Serialize(GitHubBranches));
        }
    }
}
