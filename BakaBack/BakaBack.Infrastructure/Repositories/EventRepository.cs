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
                var events = await _context.SportEvents.Include(e=>e.Outcomes).ToListAsync();
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
                var sportEvent = await _context.SportEvents.FindAsync(eventId);
                return sportEvent;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve sports event by ID.", ex);
            }
        }

        public async Task<IEnumerable<Outcome>> GetOddsByEventIdAsync(string eventId)
        {
            try
            {
                var odds = await _context.Outcomes
                    .Where(o => o.EventId == eventId)
                    .ToListAsync();
                return odds;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve odds by event ID.", ex);
            }
        }

        public async Task<bool> UpdateOddsAsync(string eventId, string outcomeName, decimal newOdds)
        {
            try
            {
                var outcome = await _context.Outcomes
                    .Where(o => o.EventId == eventId && o.Name == outcomeName)
                    .FirstOrDefaultAsync();

                if (outcome != null)
                {
                    outcome.Price = newOdds;
                    await _context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update odds.", ex);
            }
        }
    }
}