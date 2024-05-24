using BakaBack.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BakaBack.Contexts
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSet pour vos entités autres que ApplicationUser
        public DbSet<Bet> Bets { get; set; }
        public DbSet<LifeBet> LifeBets { get; set; }
        public DbSet<Match> Matches { get; set; }
    }
}
