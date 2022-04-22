using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FD.ShortUrl.Domain
{
    public class ApiApplicationRole : IdentityRole<Guid>
    {
        public string Description { get; set; }


        public virtual ICollection<ApiApplicationUserRole> UserRoles { get; set; }
        public virtual ICollection<ApiApplicationRoleClaim> RoleClaims { get; set; }
    }


}
