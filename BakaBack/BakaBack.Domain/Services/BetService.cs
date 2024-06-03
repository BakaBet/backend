using BakaBack.Domain.Interfaces;
using BakaBack.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BakaBack.Domain.Services
{
    public class BetService : IBetService
    {
        private readonly IBetRepository _betRepository;

        public BetService(IBetRepository betRepository)
        {
            _betRepository = betRepository;
        }

        public async Task<Bet> PlaceBetAsync(Bet bet)
        {
            if (bet == null)
                throw new ArgumentNullException(nameof(bet));

            try
            {
                return await _betRepository.PlaceBetAsync(bet);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to place bet.", ex);
            }
        }

        public async Task<IEnumerable<Bet>> GetUserBetsAsync(string user_id)
        {
            try
            {
                return await _betRepository.GetUserBetsAsync(user_id);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve user bets.", ex);
            }
        }
    }
}