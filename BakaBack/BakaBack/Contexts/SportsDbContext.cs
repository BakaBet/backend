using BakaBack.Models;
using Microsoft.EntityFrameworkCore;

namespace BakaBack.Contexts
{
    public class SportsDbContext : DbContext
    {
        public SportsDbContext(DbContextOptions<SportsDbContext> options) : base(options)
        { }

        public DbSet<Match> Matches { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Match>()
            .HasMany(m => m.Outcomes);
        }
    }
}
