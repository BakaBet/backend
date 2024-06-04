using BakaBack.Domain.Models;

namespace BakaBack.Domain.Interfaces
{
    public interface IEventService
    {
        Task<IEnumerable<SportEvent>> GetSportsEventsAsync();
        Task<SportEvent> GetSportsEventByIdAsync(string eventId);
        Task<bool> UpdateAwayOutcomeAsync(string eventId, decimal value);
        Task<bool> UpdateHomeOutcomeAsync(string eventId, decimal value);
    }
}
