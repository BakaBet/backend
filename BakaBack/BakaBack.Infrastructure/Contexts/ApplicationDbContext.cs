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
        public DbSet<SportEvent> SportEvents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<LifeBet>()
                .HasKey(lb => lb.Id);

            modelBuilder.Entity<Proposal>()
                .HasKey(p => new { p.UserId, p.EventId });

            modelBuilder.Entity<Participation>()
                .HasKey(p => new { p.UserId, p.Stake });
        }
    }
}
