using BakaBack.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BakaBack.Domain.Interfaces
{
    public interface IEventRepository
    {
        Task<IEnumerable<SportEvent>> GetSportsEventsAsync();
        Task<SportEvent> GetSportsEventByIdAsync(string eventId);
        Task<IEnumerable<Outcome>> GetOddsByEventIdAsync(string eventId);
        Task<bool> UpdateOddsAsync(string eventId, string outcomeName, decimal newOdds);
    }
}