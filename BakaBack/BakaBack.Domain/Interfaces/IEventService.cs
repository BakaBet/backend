using BakaBack.Domain.Models;

namespace BakaBack.Domain.Interfaces
{
    public interface IEventService
    {
        Task<IEnumerable<SportEvent>> GetSportsEventsAsync();
        Task<SportEvent> GetSportsEventByIdAsync(string eventId);
        Task<IEnumerable<Outcome>> GetOddsByEventIdAsync(string eventId);
        Task<bool> UpdateOddsAsync(string eventId, string outcomeName, decimal newOdds);
    }
}
