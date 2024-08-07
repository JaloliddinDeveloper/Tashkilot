using Microsoft.EntityFrameworkCore;

namespace Tashkilot.Models
{
    internal class AppDbContext:DbContext
    {
        public AppDbContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=kadrlarDB.db");
        }
        public DbSet<Kadr> Kadrlar {  get; set; }   
    }
}
