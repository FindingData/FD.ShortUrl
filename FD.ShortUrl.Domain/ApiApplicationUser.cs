using Microsoft.AspNetCore.Identity;

namespace FD.ShortUrl.Domain
{
    public class ApiApplicationUser :IdentityUser
    {
        public string Email { get; set; }
        public string FullName { get; set; }
    }
}
