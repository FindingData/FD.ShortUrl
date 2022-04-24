using Microsoft.AspNetCore.Identity;

namespace FD.ShortUrl.Domain
{
    public class ApiApplicationUser :IdentityUser<Guid>
    {                    
        public string? FullName { get; set; }
       
        public string? CertificateId { get; set; }
        
        public string? MyTitle { get; set; }

        public virtual ICollection<ApiApplicationUserClaim> Claims { get; set; }
        public virtual ICollection<ApiApplicationUserLogin> Logins { get; set; }
        public virtual ICollection<ApiApplicationUserToken> Tokens { get; set; }
        public virtual ICollection<ApiApplicationUserRole> UserRoles { get; set; }


    }
}
