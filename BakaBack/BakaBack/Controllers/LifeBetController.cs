using BakaBack.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class LifeBetController : ControllerBase
{
    private readonly LifeBetService _lifeBetService;
    private readonly UserManager<ApplicationUser> _userManager;

    public LifeBetController(LifeBetService lifeBetService, UserManager<ApplicationUser> userManager)
    {
        _lifeBetService = lifeBetService;
        _userManager = userManager;
    }

    [Authorize]
    [HttpPost("create")]
    public async Task<IActionResult> CreateLifeBet([FromBody] CreateLifeBetModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return Unauthorized();
        }

        var lifeBet = await _lifeBetService.CreateLifeBetAsync(user.Id, model.Terms, model.Odds, model.InitialStake);
        return Ok(lifeBet);
    }

    [HttpGet("pending")]
    public async Task<IActionResult> GetPendingLifeBets()
    {
        var lifeBets = await _lifeBetService.GetPendingLifeBetsAsync();
        return Ok(lifeBets);
    }

    [Authorize]
    [HttpPost("negotiate")]
    public async Task<IActionResult> NegotiateOdds([FromBody] NegotiateOddsModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return Unauthorized();
        }

        var lifeBet = await _lifeBetService.NegotiateOddsAsync(model.LifeBetId, user.Id, model.NewOdds);
        if (lifeBet == null)
        {
            return NotFound();
        }

        return Ok(lifeBet);
    }

    [Authorize]
    [HttpPost("join")]
    public async Task<IActionResult> JoinLifeBet([FromBody] JoinLifeBetModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return Unauthorized();
        }

        var lifeBet = await _lifeBetService.JoinLifeBetAsync(model.LifeBetId, user.Id, model.Stake);
        if (lifeBet == null)
        {
            return NotFound();
        }

        return Ok(lifeBet);
    }
}

public class CreateLifeBetModel
{
    [Required]
    public string Terms { get; set; }
    [Required]
    public decimal Odds { get; set; }
    [Required]
    public decimal InitialStake { get; set; }
}

public class NegotiateOddsModel
{
    [Required]
    public int LifeBetId { get; set; }
    [Required]
    public decimal NewOdds { get; set; }
}

public class JoinLifeBetModel
{
    [Required]
    public int LifeBetId { get; set; }
    [Required]
    public decimal Stake { get; set; }
}
