using FD.ShortUrl.Domain;
using System.Threading.Tasks;

namespace FD.ShortUrl.Core
{
    public interface IGithubClient
  {
    Task<GithubUser> GetUserAsync(string userName);
  }
}
