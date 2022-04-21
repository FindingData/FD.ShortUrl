using Duende.IdentityServer.EntityFramework.Options;
using FD.ShortUrl.Domain;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace FD.ShortUrl.Auth.Data
{
    public class ApiAuthDbContext : ApiAuthorizationDbContext<ApiApplicationUser>
    {
        public ApiAuthDbContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions)
            : base(options, operationalStoreOptions)
        {

        }

     
    }
}