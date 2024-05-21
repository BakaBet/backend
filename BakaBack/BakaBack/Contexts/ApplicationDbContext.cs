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
    }

    public class ApplicationUser : IdentityUser
    {
        public DbSet<Bet> Bets { get; set; }
        public DbSet<Match> Matches { get; set; } // Ajout de DbSet pour Match

        public int BakaCoins { get; set; } = 100; // Initialiser avec 100 BakaCoins à l'inscription
    }
}
