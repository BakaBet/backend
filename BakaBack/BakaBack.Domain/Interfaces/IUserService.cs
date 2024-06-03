using BakaBack.Domain.Models;

namespace BakaBack.Domain.Interfaces
{
    public interface IUserService
    {
        Task<IUser> GetUserByIdAsync(string userId);
        Task<bool> UpdateUserAsync(string userId, string firstName, string lastName, string email);
        Task<bool> AddBonusAsync(string userId, decimal bonusAmount);
        Task<decimal> GetUserBalanceAsync(string userId);
        Task<IEnumerable<Bet>> GetUserBetHistoryAsync(string userId);
    }
}