using FD.ShortUrl.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FD.ShortUrl.Auth.Data
{
    public class AuthDbContext : IdentityDbContext<WebAppUser>
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options)
            : base(options)
        {
        }
    }
}