using FD.ShortUrl.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.Text.Json;

namespace FD.ShortUrl.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NamedController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public NamedController(IHttpClientFactory httpClientFactory) =>
            _httpClientFactory = httpClientFactory;

        public IEnumerable<GitHubBranch>? GitHubBranches { get; set; }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
        "/repos/dotnet/AspNetCore.Docs/branches");

            var httpClient = _httpClientFactory.CreateClient("github");
            var httpResponseMessage = await httpClient.SendAsync(request);

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
