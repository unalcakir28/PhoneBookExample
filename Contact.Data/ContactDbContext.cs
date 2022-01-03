using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Data
{
    public class ContactDbContext : DbContext
    {
        public ContactDbContext(DbContextOptions<ContactDbContext> options)
            : base(options)
        {
        }

        public ContactDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("User ID=postgres;Password=4jm5eX4b;Host=localhost;Port=5432;Database=ContactDb;Pooling=true;Integrated Security=true;");
        }

        public DbSet<Contact.Entity.Contact> Contacts { get; set; }
        public DbSet<Contact.Entity.ContactDetail> ContactDetails { get; set; }
    }
}
