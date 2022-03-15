using FD.ShortUrl.Domain;
using Refit;

namespace FD.ShortUrl.Api
{
    public interface IGitHubClient
    {
        [Get("/repos/dotnet/AspNetCore.Docs/branches")]
        Task<IEnumerable<GitHubBranch>> GetAspNetCoreDocsBranchesAsync();
    }
}
