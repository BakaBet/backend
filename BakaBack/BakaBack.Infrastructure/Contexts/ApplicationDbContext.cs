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

            modelBuilder.Entity<SportEvent>()
                .HasMany(e => e.Outcomes)
                .WithOne(o => o.SportEvent)
                .HasForeignKey(o => o.EventId);

            // Define the relationship between Outcome and SportEvent
            modelBuilder.Entity<Outcome>()
                .HasOne(o => o.SportEvent)
                .WithMany(e => e.Outcomes)
                .HasForeignKey(o => o.EventId);

            // Define the relationship between Outcome and SportEvent
            modelBuilder.Entity<Outcome>()
                .HasOne(o => o.SportEvent)
                .WithMany(e => e.Outcomes)
                .HasForeignKey(o => o.EventId);
        }
    }
}
