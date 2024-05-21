using BakaBack.Models;
using Microsoft.AspNetCore.Mvc;

namespace BakaBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SportBetsController : ControllerBase
    {
        private readonly SportsBetRepository _repository;
        private readonly UserService _userService;

        public SportBetsController(SportsBetRepository repository, UserService userService)
        {
            _repository = repository;
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Match>>> GetMatches()
        {
            var matches = await _repository.GetAllMatchesAsync();
            return Ok(matches);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Match>> GetMatch(string id)
        {
            var match = await _repository.GetMatchByIdAsync(id);
            if (match == null)
            {
                return NotFound();
            }
            return Ok(match);
        }

        [HttpPost]
        public async Task<ActionResult<Match>> PostMatch(Match match)
        {
            await _repository.AddMatchAsync(match);
            return CreatedAtAction(nameof(GetMatch), new { id = match.Id }, match);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMatch(string id, Match match)
        {
            if (id != match.Id)
            {
                return BadRequest();
            }

            var existingMatch = await _repository.GetMatchByIdAsync(id);
            if (existingMatch == null)
            {
                return NotFound();
            }

            await _repository.UpdateMatchAsync(match);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMatch(string id)
        {
            var match = await _repository.GetMatchByIdAsync(id);
            if (match == null)
            {
                return NotFound();
            }

            await _repository.DeleteMatchAsync(id);
            return NoContent();
        }

        // Action pour récupérer les paris d'un utilisateur en fonction de son ID
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetBetsByUserId(string userId)
        {
            var bets = await _userService.GetBetsByUserAsync(userId);
            return Ok(bets);
        }

    }
}
