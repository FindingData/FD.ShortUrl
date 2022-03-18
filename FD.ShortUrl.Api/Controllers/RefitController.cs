using FD.ShortUrl.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using Refit;
using System.Text.Json;

namespace FD.ShortUrl.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RefitController : ControllerBase
    {
        private readonly IGitHubClient _gitHubClient;

        public RefitController(IGitHubClient gitHubClient) =>
            _gitHubClient = gitHubClient;

        public IEnumerable<GitHubBranch>? GitHubBranches { get; set; }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                GitHubBranches = await _gitHubClient.GetAspNetCoreDocsBranchesAsync();
            }
            catch (ApiException)
            {
                // ...
            }
            return Content(JsonSerializer.Serialize(GitHubBranches));
        }
    }
}
