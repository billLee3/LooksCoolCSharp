using Microsoft.EntityFrameworkCore;
using PowerAppsUIValues.Models;

namespace PowerAppsUIValues
{
    public class AppDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<UISchema> UISchemas { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UISchema>()
                .HasKey(p => p.Id);
            base.OnModelCreating(modelBuilder);
        }
    }
}
