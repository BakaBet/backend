using BakaBack.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakaBack.Domain.Interfaces
{
    public interface ILifeBetService
    {
        Task<IEnumerable<LifeBet>> GetLifeBetsAsync();
        Task<LifeBet> GetLifeBetByIdAsync(int id);
        Task AddLifeBetAsync(LifeBet lifeBet);
        Task<bool> UpdateLifeBetAsync(LifeBet lifeBet);
        //Task<IEnumerable<Negotiation>> GetNegotiationsAsync(int lifeBetId);
        //Task<Negotiation> GetNegotiationByIdAsync(int id);
        //Task<Negotiation> InitiateNegotiationAsync(Negotiation negotiation);
        //Task<bool> RespondToNegotiationAsync(int negotiationId, bool isAccepted);
    }
}
