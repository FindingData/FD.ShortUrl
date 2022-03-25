using FD.ShortUrl.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FD.ShortUrl.Repository
{
    public class ContactDb : DbContext
    {
        public ContactDb(DbContextOptions<ContactDb> options)
            : base(options) { }

        public DbSet<Contact> Contacts => Set<Contact>();

        
    }
}
