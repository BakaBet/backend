using BakaBack.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakaBack.Domain.Interfaces
{
    public interface ILifeBetRepository
    {
        Task<IEnumerable<LifeBet>> GetLifeBetsAsync();
        Task<LifeBet> GetLifeBetByIdAsync(int id);
        Task AddLifeBetAsync(LifeBet lifeBet);
        Task<bool> UpdateLifeBetAsync(LifeBet lifeBet);
        //Task<IEnumerable<Negotiation>> GetNegotiationsAsync(int lifeBetId);
        //Task<Negotiation> GetNegotiationByIdAsync(int id);
        //Task<Negotiation> CreateNegotiationAsync(Negotiation negotiation);
        //Task<bool> UpdateNegotiationAsync(Negotiation negotiation);
    }
}
