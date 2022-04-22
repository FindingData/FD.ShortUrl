using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FD.ShortUrl.Domain
{
    public class ApiApplicationUserRole: IdentityUserRole<Guid>
    {
        public virtual ApiApplicationUser User { get; set; }
        public virtual ApiApplicationRole Role { get; set; }
    }
}
