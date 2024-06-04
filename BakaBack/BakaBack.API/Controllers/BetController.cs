using BakaBack.Domain.Models;
using BakaBack.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BakaBack.Api.Models;
using BakaBack.API.DTO;

namespace BakaBack.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BetController : ControllerBase
    {
        private readonly IBetService _betService;
        private readonly IOddsService _oddsService;

        public BetController(IBetService betService, IOddsService oddsService)
        {
            _betService = betService;
            _oddsService = oddsService;
        }

        [HttpPost]
        public async Task<ActionResult<Bet>> PlaceBet([FromBody] BetDto bet)
        {
            try
            {
                var result = await _betService.PlaceBetAsync(
                    new Bet { UserId = bet.UserId, EventId = bet.EventId, 
                    Amount = bet.Amount, Team = bet.Team, DatePlaced = DateTime.Now, IsWon = false , EndTime = DateTime.Now.AddMinutes(1) , Gains = 0 , IsEnded = false});
                await _oddsService.UpdateOddsAsync(bet.EventId);
                return Ok(bet);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{user_id}")]
        public async Task<ActionResult<IEnumerable<Bet>>> GetUserBets(string user_id)
        {
            try
            {
                var userBets = await _betService.GetUserBetsAsync(user_id);
                return Ok(userBets);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
