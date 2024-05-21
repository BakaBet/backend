using BakaBack.Models;
using Microsoft.EntityFrameworkCore;

public class SportsDbContext : DbContext
{
    public SportsDbContext(DbContextOptions<SportsDbContext> options): base(options)
    {

    }

    public DbSet<Match> Matches { get; set; }
    public DbSet<Bookmaker> Bookmakers { get; set; }
    public DbSet<Market> Markets { get; set; }
    public DbSet<Outcome> Outcomes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Match>()
            .HasMany(m => m.Bookmakers)
            .WithOne(b => b.Match)
            .HasForeignKey(b => b.MatchId);

        modelBuilder.Entity<Bookmaker>()
            .HasMany(b => b.Markets)
            .WithOne(m => m.Bookmaker)
            .HasForeignKey(m => m.BookmakerId);

        modelBuilder.Entity<Market>()
            .HasMany(m => m.Outcomes)
            .WithOne(o => o.Market)
            .HasForeignKey(o => o.MarketId);
    }
}