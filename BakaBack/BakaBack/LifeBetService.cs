using BakaBack.Contexts;
using BakaBack.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class LifeBetService
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public LifeBetService(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public async Task<LifeBet> CreateLifeBetAsync(string userId, string terms, decimal odds, decimal initialStake)
    {
        var lifeBet = new LifeBet
        {
            Terms = terms,
            Odds = odds,
            InitialStake = initialStake,
            Status = "pending",
            CreatorId = userId,
            Participants = new List<LifeBetParticipant>
            {
                new LifeBetParticipant
                {
                    UserId = userId,
                    Stake = initialStake,
                    NegotiatedOdds = odds
                }
            }
        };

        _context.LifeBets.Add(lifeBet);
        await _context.SaveChangesAsync();
        return lifeBet;
    }

    public async Task<IEnumerable<LifeBet>> GetPendingLifeBetsAsync()
    {
        return await _context.LifeBets
            .Include(b => b.Participants)
            .Include(b => b.Creator)
            .Where(b => b.Status == "pending")
            .ToListAsync();
    }

    public async Task<LifeBet> NegotiateOddsAsync(int lifeBetId, string userId, decimal newOdds)
    {
        var lifeBet = await _context.LifeBets
            .Include(b => b.Participants)
            .FirstOrDefaultAsync(b => b.Id == lifeBetId);

        if (lifeBet == null || lifeBet.Status != "pending")
        {
            return null;
        }

        var participant = lifeBet.Participants.FirstOrDefault(p => p.UserId == userId);
        if (participant == null)
        {
            participant = new LifeBetParticipant
            {
                LifeBetId = lifeBetId,
                UserId = userId,
                NegotiatedOdds = newOdds
            };
            lifeBet.Participants.Add(participant);
        }
        else
        {
            participant.NegotiatedOdds = newOdds;
        }

        await _context.SaveChangesAsync();
        return lifeBet;
    }

    public async Task<LifeBet> JoinLifeBetAsync(int lifeBetId, string userId, decimal stake)
    {
        var lifeBet = await _context.LifeBets
            .Include(b => b.Participants)
            .FirstOrDefaultAsync(b => b.Id == lifeBetId);

        if (lifeBet == null || lifeBet.Status != "pending")
        {
            return null;
        }

        var participant = new LifeBetParticipant
        {
            LifeBetId = lifeBetId,
            UserId = userId,
            Stake = stake,
            NegotiatedOdds = lifeBet.Odds
        };

        lifeBet.Participants.Add(participant);
        lifeBet.Status = "active"; // Mark as active when a participant joins
        await _context.SaveChangesAsync();
        return lifeBet;
    }
}
