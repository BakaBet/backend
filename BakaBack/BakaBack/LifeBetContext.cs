using BakaBack.Models;
using Microsoft.EntityFrameworkCore;

namespace BakaBack
{
    public class LifeBetContext : DbContext
    {
        public LifeBetContext(DbContextOptions<LifeBetContext> options) : base(options)
        {

        }

        public DbSet<LifeBet> LifeBets { get; set; }
    }
}
