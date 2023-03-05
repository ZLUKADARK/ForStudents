using Microsoft.EntityFrameworkCore;
using Test.Domain.Entities;

namespace Test.DLL.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options)
            : base(options)
        { 
            Database.EnsureCreated();
        }

        public DbSet<Person> Person { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<SocialClass> SocialClass { get; set; }
    }
}
