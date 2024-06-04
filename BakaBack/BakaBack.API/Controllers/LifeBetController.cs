using BakaBack.Domain.Interfaces;
using BakaBack.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using BakaBack.API.DTO;

namespace BakaBack.API.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class LifeBetsController : ControllerBase
        {
            private readonly ILifeBetService _lifeBetService;

            public LifeBetsController(ILifeBetService lifeBetService)
            {
                _lifeBetService = lifeBetService;
            }

            // GET: api/LifeBets
            [HttpGet]
            public async Task<ActionResult<IEnumerable<LifeBet>>> GetLifeBets()
            {
                var lifeBets = await _lifeBetService.GetLifeBetsAsync();
                return Ok(lifeBets);
            }

            // GET: api/LifeBets/{id}
            [HttpGet("{id}")]
            public async Task<ActionResult<LifeBet>> GetLifeBet(int id)
            {
                var lifeBet = await _lifeBetService.GetLifeBetByIdAsync(id);
                if (lifeBet == null)
                {
                    return NotFound();
                }
                return Ok(lifeBet);
            }

        // POST: api/LifeBets
        [HttpPost]
        public async Task<ActionResult> AddLifeBet([FromBody] Proposal lifeBetRequest)
        {
            var lifeBet = new LifeBet(lifeBetRequest);
            await _lifeBetService.AddLifeBetAsync(lifeBet);
            return CreatedAtAction(nameof(GetLifeBet), new { id = lifeBet.Id }, lifeBet);
        }

        // PUT: api/LifeBets/{id}
        [HttpPut("{id}")]
            public async Task<IActionResult> UpdateLifeBet(int id, [FromBody] LifeBet lifeBet)
            {
                if (id != lifeBet.Id)
                {
                    return BadRequest();
                }

                var success = await _lifeBetService.UpdateLifeBetAsync(lifeBet);
                if (!success)
                {
                    return BadRequest();
                }
                return NoContent();
            }
        }
}
