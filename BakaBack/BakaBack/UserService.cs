using BakaBack.Contexts;
using BakaBack.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class UserService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ApplicationDbContext _context;

    public UserService(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
    {
        _userManager = userManager;
        _context = context;
    }

    // Méthode pour obtenir le solde de BakaCoins de l'utilisateur
    public async Task<int> GetBakaCoinsAsync(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        return user?.BakaCoins ?? 0;
    }

    // Méthode pour ajouter des BakaCoins à l'utilisateur
    public async Task<bool> AddBakaCoinsAsync(string userId, int amount)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
        {
            return false;
        }

        user.BakaCoins += amount;
        var result = await _userManager.UpdateAsync(user);

        return result.Succeeded;
    }

    // Méthode pour soustraire des BakaCoins de l'utilisateur
    public async Task<bool> SubtractBakaCoinsAsync(string userId, int amount)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null || user.BakaCoins < amount)
        {
            return false;
        }

        user.BakaCoins -= amount;
        var result = await _userManager.UpdateAsync(user);

        return result.Succeeded;
    }

    public async Task<List<Bet>> GetBetsByUserAsync(string userId)
    {
        return await _context.Bets
                             .Include(b => b.Match)
                             .Where(b => b.UserId == userId)
                             .ToListAsync();
    }

}
