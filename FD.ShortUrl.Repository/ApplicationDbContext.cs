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
            modelBuilder.HasSequence<int>("seq_short_url");

           
        }
    }

}
