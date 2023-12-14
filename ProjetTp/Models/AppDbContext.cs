using Microsoft.EntityFrameworkCore;

namespace ProjetTp.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options)
        { }

        public DbSet<Fabriquant> Fabriquants { get; set; } 
        public DbSet<Format> Formats { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
    }
}
