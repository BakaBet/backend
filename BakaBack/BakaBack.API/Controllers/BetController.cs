using BakaBack.Domain.Models;
using BakaBack.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BakaBack.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BetController : ControllerBase
    {
        private readonly IBetService _betService;

        public BetController(IBetService betService)
        {
            _betService = betService;
        }

        [HttpPost]
        public async Task<ActionResult<Bet>> PlaceBet([FromBody] Bet bet)
        {
            try
            {
                var placedBet = await _betService.PlaceBetAsync(bet);
                return Ok(placedBet);
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
                var bets = await _betService.GetUserBetsAsync(user_id);
                return Ok(bets);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
