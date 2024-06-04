using BakaBack.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BakaBack.Domain.Interfaces
{
    public interface IBetRepository
    {
        Task<Bet> PlaceBetAsync(Bet bet);
        Task<IEnumerable<Bet>> GetUserBetsAsync(string user_id);
        Task<IEnumerable<Bet>> GetBetsByEventIdAsync(string event_id);
    }
}