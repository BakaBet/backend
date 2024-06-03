using BakaBack.Domain.Interfaces;
using BakaBack.Domain.Models;

namespace BakaBack.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IUser> GetUserByIdAsync(string userId)
        {
            try
            {
                return await _userRepository.GetUserByIdAsync(userId);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve user by ID.", ex);
            }
        }

        public async Task<bool> AddBonusAsync(string userId, decimal bonusAmount)
        {
            try
            {
                return await _userRepository.AddBonusAsync(userId, bonusAmount);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to add bonus to user.", ex);
            }
        }

        public async Task<decimal> GetUserBalanceAsync(string userId)
        {
            try
            {
                return await _userRepository.GetUserBalanceAsync(userId) ?? 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve user balance.", ex);
            }
        }

        public async Task<IEnumerable<Bet>> GetUserBetHistoryAsync(string userId)
        {
            try
            {
                return await _userRepository.GetUserBetHistoryAsync(userId);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve user bet history.", ex);
            }
        }

        public async Task<bool> UpdateUserAsync(string userId, string firstName, string lastName, string email)
        {
            try
            {
                return await _userRepository.UpdateUserAsync(userId, firstName, lastName, email);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update user.", ex);
            }
        }
    }
}