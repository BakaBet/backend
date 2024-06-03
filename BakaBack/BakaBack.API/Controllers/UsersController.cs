using Microsoft.AspNetCore.Mvc;
using BakaBack.API.DTO;
using BakaBack.Domain.Services;
using BakaBack.Domain.Models;
using System.Threading.Tasks;
using System;
using BakaBack.Domain.Interfaces;

namespace BakaBack.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("{user_id}/bonus")]
        public async Task<IActionResult> AddBonus(string user_id, decimal amount)
        {
            try
            {
                var success = await _userService.AddBonusAsync(user_id, amount);
                if (success)
                {
                    return NoContent();
                }
                else
                {
                    return BadRequest("Failed to add bonus.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{user_id}")]
        public async Task<IActionResult> GetUser(string user_id)
        {
            try
            {
                var user = await _userService.GetUserByIdAsync(user_id);
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{user_id}/balance")]
        public async Task<IActionResult> GetUserBalance(string user_id)
        {
            try
            {
                var balance = await _userService.GetUserBalanceAsync(user_id);
                return Ok(balance);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{user_id}/bets/history")]
        public async Task<IActionResult> GetUserBetHistory(string user_id)
        {
            try
            {
                var bets = await _userService.GetUserBetHistoryAsync(user_id);
                return Ok(bets);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{user_id}")]
        public async Task<IActionResult> UpdateUser(string user_id, [FromBody] UserUpdateRequest request)
        {
            try
            {
                var success = await _userService.UpdateUserAsync(user_id, request.FirstName,  request.LastName,  request.Email);
                if (success)
                {
                    return NoContent();
                }
                else
                {
                    return BadRequest("Failed to update user.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}