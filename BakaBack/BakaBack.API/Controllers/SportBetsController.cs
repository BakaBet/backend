using Microsoft.AspNetCore.Mvc;

using BakaBack.Domain.Models;
using BakaBack.Infrastructure.Repositories;

namespace BakaBack.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SportBetsController : ControllerBase
    {
        private readonly SportsBetRepository _repository;

        public SportBetsController(SportsBetRepository repository)
        {
            _repository = repository;
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
    }
}
