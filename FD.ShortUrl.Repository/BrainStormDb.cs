using FD.ShortUrl.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FD.ShortUrl.Repository
{
    public class BrainStormDb : DbContext
    {
        public BrainStormDb(DbContextOptions<BrainStormDb> options)
            : base(options) { }

        public DbSet<BrainstormSession> BrainstormSessions { get; set; } = null!;
    }
}
