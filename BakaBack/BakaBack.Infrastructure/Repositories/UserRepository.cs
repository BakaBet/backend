using BakaBack.Domain.Models;
using BakaBack.Infrastructure.Contexts;

namespace BakaBack.Infrastructure.Repositories
{
    public class UserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IUser> GetUserByIdAsync(string userId)
        {
            return await _context.Users.FindAsync(userId);
        }

        public async Task UpdateUserAsync(IUser user)
        {
            var appUser = await _context.Users.FindAsync(user.Id);
            if (appUser != null)
            {
                //appUser.Username = user.Username;
                appUser.Coins = user.Coins;
                _context.Users.Update(appUser);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteUserAsync(string userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}
