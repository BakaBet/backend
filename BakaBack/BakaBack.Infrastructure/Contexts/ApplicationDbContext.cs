using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BakaBack.Infrastructure.Models;
using BakaBack.Domain.Models;

    
namespace BakaBack.Infrastructure.Contexts
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Bet> Bets { get; set; }
        public DbSet<LifeBet> LifeBets { get; set; }
        public DbSet<Match> Matches { get; set; }
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
