using BakaBack.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BakaBack.Domain.Interfaces
{
    public interface IEventRepository
    {
        Task<IEnumerable<SportEvent>> GetSportsEventsAsync();
        Task<SportEvent> GetSportsEventByIdAsync(string eventId);
        Task<bool> UpdateAwayOutcomeAsync(string eventId, decimal newOdds);
        Task<bool> UpdateHomeOutcomeAsync(string eventId, decimal newOdds);
    }
}