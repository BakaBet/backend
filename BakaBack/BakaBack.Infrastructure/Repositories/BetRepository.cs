using BakaBack.Domain.Interfaces;
using BakaBack.Domain.Models;
using BakaBack.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BakaBack.Infrastructure.Repositories
{
    public class BetRepository : IBetRepository
    {
        private readonly ApplicationDbContext _context;

        public BetRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Bet> PlaceBetAsync(Bet bet)
        {
            if (bet == null)
                throw new ArgumentNullException(nameof(bet));

            var sportEvent = await _context.SportEvents.FindAsync(bet.EventId);
            if (sportEvent == null)
            {
                throw new Exception("SportEvent not found.");
            }

            try
            {
                _context.Bets.Add(bet);
                await _context.SaveChangesAsync();
                return bet;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to place bet.", ex);
            }
        }

        public async Task<IEnumerable<Bet>> GetUserBetsAsync(string user_id)
        {
            try
            {
                return await _context.Bets
                    .Where(b => b.UserId == user_id)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve user bets.", ex);
            }
        }
    }
}
