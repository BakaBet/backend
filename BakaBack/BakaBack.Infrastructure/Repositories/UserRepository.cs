using BakaBack.Domain.Interfaces;
using BakaBack.Domain.Models;
using BakaBack.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BakaBack.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddBonusAsync(string userId, decimal bonusAmount)
        {
            try
            {
                var user = await _context.Users.FindAsync(userId);
                if (user == null)
                    return false;

                user.Coins += bonusAmount;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to add bonus to user.", ex);
            }
        }

        public async Task<IUser> GetUserByIdAsync(string userId)
        {
            try
            {
                return await _context.Users.FindAsync(userId);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve user by ID.", ex);
            }
        }

        public async Task<decimal?> GetUserBalanceAsync(string userId)
        {
            try
            {
                var user = await _context.Users.FindAsync(userId);
                return user?.Coins;
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
                return await _context.Bets
                    .Where(b => b.UserId == userId)
                    .ToListAsync();
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
                var user = await _context.Users.FindAsync(userId);
                if (user == null)
                    return false;

                user.FirstName = firstName;
                user.LastName = lastName;
                user.Email = email;

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update user.", ex);
            }
        }
        public async Task<bool> SubtractCoinsAsync(string userId, decimal amount)
        {
            try
            {
                var user = await _context.Users.FindAsync(userId);
                if (user == null)
                    return false;

                if (user.Coins < amount)
                    return false;

                user.Coins -= amount;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to subtract coins from user.", ex);
            }
        }
    }
}