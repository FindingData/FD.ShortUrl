using FD.ShortUrl.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FD.ShortUrl.Repository
{
    public class EFConfigurationContext : DbContext
    {
        public EFConfigurationContext(DbContextOptions<EFConfigurationContext> options) : base(options)
        {
        }

        public DbSet<EFConfigurationValue> Values => Set<EFConfigurationValue>();
    }
}
