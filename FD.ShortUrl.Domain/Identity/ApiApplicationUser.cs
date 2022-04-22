using Microsoft.AspNetCore.Identity;

namespace FD.ShortUrl.Domain
{
    public class ApiApplicationUser :IdentityUser<Guid>
    {
       
        public string Email { get; set; }
      
        public string FullName { get; set; }
        [PersonalData]
        public string CertificateId { get; set; }
        [PersonalData]
        public string MyTitle { get; set; }

        public virtual ICollection<ApiApplicationUserClaim> Claims { get; set; }
        public virtual ICollection<ApiApplicationUserLogin> Logins { get; set; }
        public virtual ICollection<ApiApplicationUserToken> Tokens { get; set; }
        public virtual ICollection<ApiApplicationUserRole> UserRoles { get; set; }


    }
}
