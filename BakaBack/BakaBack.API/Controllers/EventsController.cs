using Microsoft.AspNetCore.Mvc;
using BakaBack.Domain.Models;
using BakaBack.Domain.Interfaces;
using BakaBack.API.DTO;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BakaBack.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventsController(IEventService eventService)
        {
            _eventService = eventService;
        }

        // GET /events/sports
        [HttpGet("sports")]
        public async Task<ActionResult<IEnumerable<SportEvent>>> GetSportsEvents()
        {
            var events = await _eventService.GetSportsEventsAsync();
            return Ok(events);
        }

        // GET /events/sports/{event_id}
        [HttpGet("sports/{event_id}")]
        public async Task<ActionResult<SportEvent>> GetSportsEvent(string event_id)
        {
            var sportEvent = await _eventService.GetSportsEventByIdAsync(event_id);
            if (sportEvent == null)
            {
                return NotFound();
            }
            return Ok(sportEvent);
        }
    }
}
