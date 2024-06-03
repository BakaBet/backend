using BakaBack.Domain.Models;
using BakaBack.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace BakaBack.Infrastructure.Contexts
{
    public class SportsDbContext : DbContext
    {
        public SportsDbContext(DbContextOptions<SportsDbContext> options) : base(options)
        { }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Bet> Bets { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Bet>()
                .HasOne(b => b.Match)
                .WithMany()
                .HasForeignKey(b => b.MatchId);

            modelBuilder.Entity<Bet>()
                .HasOne<ApplicationUser>()
                .WithMany()
                .HasForeignKey(b => b.UserId);
        }
    }
}
