using FD.ShortUrl.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.Text.Json;

namespace FD.ShortUrl.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypedController : ControllerBase
    {
        private readonly GitHubService _gitHubService;

        public TypedController(GitHubService gitHubService) =>
            _gitHubService = gitHubService;

        public IEnumerable<GitHubBranch>? GitHubBranches { get; set; }
        [HttpGet]
        public async Task<IActionResult> Index()
        {

            try
            {
                GitHubBranches = await _gitHubService.GetAspNetCoreDocsBranchesAsync();
            }
            catch (HttpRequestException)
            {
                // ...
            }
            return Content(JsonSerializer.Serialize(GitHubBranches));
        }
    }
}
