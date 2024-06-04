using BakaBack.Domain.Interfaces;
using BakaBack.Domain.Models;

namespace BakaBack.Domain.Services
{
    public class LifeBetService : ILifeBetService
    {
        private readonly ILifeBetRepository _lifeBetRepository;

        public LifeBetService(ILifeBetRepository lifeBetRepository)
        {
            _lifeBetRepository = lifeBetRepository;
        }

        public async Task<IEnumerable<LifeBet>> GetLifeBetsAsync()
        {
            return await _lifeBetRepository.GetLifeBetsAsync();
        }

        public async Task<LifeBet> GetLifeBetByIdAsync(int id)
        {
            return await _lifeBetRepository.GetLifeBetByIdAsync(id);
        }

        public async Task AddLifeBetAsync(LifeBet lifeBet)
        {
            await _lifeBetRepository.AddLifeBetAsync(lifeBet);
        }

        public async Task<bool> UpdateLifeBetAsync(LifeBet lifeBet)
        {
            return await _lifeBetRepository.UpdateLifeBetAsync(lifeBet);
        }
    }
}
