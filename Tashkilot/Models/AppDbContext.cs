using Microsoft.EntityFrameworkCore;

namespace Labaratoriya.Models
{
    internal class AppDbContext:DbContext
    {
        public AppDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=OrganDB;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        public DbSet<Mijoz> Mijozlar {get; set; }   
        public DbSet<Organ> Organlar {set; get; }
    }
}
