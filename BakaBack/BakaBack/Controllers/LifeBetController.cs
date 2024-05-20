using BakaBack.Models;
using Microsoft.AspNetCore.Mvc;

namespace BakaBack.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LifeBetController : ControllerBase
    {
        //private readonly ILifeBetRepository lifeBetRepository;

        //public LifeBetController(ILifeBetRepository lifeBetRepository)
        //{
        //    this.lifeBetRepository = lifeBetRepository;
        //}

        //[HttpGet]
        //public IActionResult GetAllLifeBets()
        //{
        //    if (_lifeBets == null || !_lifeBets.Any())
        //    {
        //        return NotFound(new { message = "No LifeBets found" });
        //    }
        //    return Ok(_lifeBets.AsEnumerable());
        //}

        //[HttpGet("{id}")]
        //public IActionResult GetLifeBet(int id)
        //{
        //    var lifeBet = _lifeBets.FirstOrDefault(b => b.BetId == id);
        //    if (lifeBet == null)
        //    {
        //        return NotFound(new { message = $"LifeBet with ID {id} not found" });
        //    }
        //    return Ok(lifeBet);
        //}

        //[HttpPost]
        //public IActionResult CreateLifeBet(LifeBet lifeBet)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(new { message = "Invalid LifeBet data", errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)) });
        //    }

        //    lifeBet.BetId = _lifeBets.Count + 1;
        //    _lifeBets.Add(lifeBet);
        //    return CreatedAtRoute("GetLifeBet", new { id = lifeBet.BetId }, lifeBet);
        //}

        //[HttpPut("{id}")]
        //public IActionResult UpdateLifeBet(int id, LifeBet lifeBet)
        //{
        //    if (id != lifeBet.BetId)
        //    {
        //        return BadRequest(new { message = "ID in URL and object body don't match" });
        //    }

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(new { message = "Invalid LifeBet data", errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)) });
        //    }

        //    var existingLifeBet = _lifeBets.FirstOrDefault(b => b.BetId == id);
        //    if (existingLifeBet == null)
        //    {
        //        return NotFound(new { message = $"LifeBet with ID {id} not found" });
        //    }

        //    int index = _lifeBets.IndexOf(existingLifeBet);
        //    _lifeBets[index] = lifeBet;
        //    return NoContent();
        //}

        //[HttpDelete("{id}")]
        //public IActionResult DeleteLifeBet(int id)
        //{
        //    var lifeBetToDelete = _lifeBets.FirstOrDefault(b => b.BetId == id);
        //    if (lifeBetToDelete == null)
        //    {
        //        return NotFound(new { message = $"LifeBet with ID {id} not found" });
        //    }

        //    _lifeBets.Remove(lifeBetToDelete);
        //    return NoContent();
        //}
    }
}
