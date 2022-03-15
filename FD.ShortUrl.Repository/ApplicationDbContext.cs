using FD.ShortUrl.Domain;
using Microsoft.EntityFrameworkCore;
using Oracle.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FD.ShortUrl.Repository
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {            
        }
        public DbSet<ShortUrlPO> ShortUrls { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasSequence<int>("SEQ_SHORT_URL");

            //modelBuilder.Entity<ShortUrlPO>().Property(e => e.SHORT_URL_ID).HasColumnName("ID")
            //   .ForOracleUseSequenceHiLo("SEQUENCE_NAME");

            modelBuilder.Entity<ShortUrlPO>().Property(o => o.SHORT_URL_ID).UseHiLo("SEQ_SHORT_URL");
        }
    }

}
