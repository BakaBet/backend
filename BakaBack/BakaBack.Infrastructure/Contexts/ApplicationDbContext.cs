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
    }
}
