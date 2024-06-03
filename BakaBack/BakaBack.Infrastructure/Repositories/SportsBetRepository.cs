using BakaBack.Domain.Models;
using Microsoft.EntityFrameworkCore;
using BakaBack.Infrastructure.Contexts;

namespace BakaBack.Infrastructure.Repositories
{
    public class SportsBetRepository
    {
        private readonly SportsDbContext _context;

        public SportsBetRepository(SportsDbContext context)
        {
            _context = context;
        }

        public async Task AddMatchAsync(Match match)
        {
            _context.Matches.Add(match);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Match>> GetAllMatchesAsync()
        {
            return await _context.Matches
                .Include(m=> m.Outcomes)
                .ToListAsync();
        }

        public async Task<Match> GetMatchByIdAsync(string matchId)
        {
            return await _context.Matches
                .FirstOrDefaultAsync(m => m.Id == matchId);
        }

        public async Task UpdateMatchAsync(Match match)
        {
            _context.Matches.Update(match);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMatchAsync(string matchId)
        {
            var match = await _context.Matches.FindAsync(matchId);
            if (match != null)
            {
                _context.Matches.Remove(match);
                await _context.SaveChangesAsync();
            }
        }
    }
}

