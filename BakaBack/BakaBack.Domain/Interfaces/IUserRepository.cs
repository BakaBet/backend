using BakaBack.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakaBack.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> AddBonusAsync(string userId, decimal bonusAmount);
        Task<IUser> GetUserByIdAsync(string userId);
        Task<decimal?> GetUserBalanceAsync(string userId);
        Task<IEnumerable<Bet>> GetUserBetHistoryAsync(string userId);
        Task<bool> UpdateUserAsync(string userId, string firstName, string lastName, string email);
    }
}
