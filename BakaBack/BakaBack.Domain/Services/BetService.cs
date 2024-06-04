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
        private readonly IUserService _userService;
        private readonly IEventRepository _sportEventRepository;

        public BetService(IBetRepository betRepository, IUserService userService, IEventRepository sportEventRepository)
        {
            _betRepository = betRepository;
            _userService = userService;
            _sportEventRepository = sportEventRepository;
        }

        public async Task<Bet> PlaceBetAsync(Bet bet)
        {
            if (bet == null)
                throw new ArgumentNullException(nameof(bet));

            var success = await _userService.SubtractCoinsAsync(bet.UserId, bet.Amount);
            if (!success)
            {
                throw new Exception("Insufficient coins or user not found.");
            }

            var sportEvent = await _sportEventRepository.GetSportsEventByIdAsync(bet.EventId);
            if (sportEvent == null)
            {
                throw new Exception("SportEvent not found.");
            }

            if (bet.Team == sportEvent.HomeTeam)
            {
                bet.Odd = sportEvent.HomeOutcome ?? throw new Exception("Home team odds not available.");
            }
            else if (bet.Team == sportEvent.AwayTeam)
            {
                bet.Odd = sportEvent.AwayOutcome ?? throw new Exception("Away team odds not available.");
            }
            else
            {
                throw new Exception("Team not found in the event.");
            }
            try
            {
                return await _betRepository.PlaceBetAsync(bet);
            }
            catch (Exception ex)
            {
                await _userService.AddBonusAsync(bet.UserId, bet.Amount);
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