using BakaBack.Domain.Interfaces;
using BakaBack.Domain.Models;
using BakaBack.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BakaBack.Infrastructure.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly ApplicationDbContext _context;

        public EventRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SportEvent>> GetSportsEventsAsync()
        {
            try
            {
                var events = await _context.SportEvents
                    .ToListAsync();

                return events;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve sports events.", ex);
            }
        }

        public async Task<SportEvent> GetSportsEventByIdAsync(string eventId)
        {
            try
            {
                var sportEvent = await _context.SportEvents
                    .FirstOrDefaultAsync(e => e.Id == eventId);

                return sportEvent;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve sports event by ID.", ex);
            }
        }

        public async Task<bool> UpdateHomeOutcomeAsync(string eventId, decimal? newOdds)
        {
            try
            {
                var sportEvent = await _context.SportEvents
                    .FirstOrDefaultAsync(e => e.Id == eventId);

                if (sportEvent == null || sportEvent.HomeOutcome == null)
                {
                    return false;
                }

                sportEvent.HomeOutcome = newOdds;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update home outcome.", ex);
            }
        }

        public async Task<bool> UpdateAwayOutcomeAsync(string eventId, decimal? newOdds)
        {
            try
            {
                var sportEvent = await _context.SportEvents
                    .FirstOrDefaultAsync(e => e.Id == eventId);

                if (sportEvent == null || sportEvent.AwayOutcome == null)
                {
                    return false;
                }

                sportEvent.AwayOutcome = newOdds;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update away outcome.", ex);
            }
        }
    }
}