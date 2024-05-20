using BakaBack.Models;
namespace BakaBack.Repositories
{
    public class LifeBetRepository
    {
        private readonly LifeBetContext _context;

        public LifeBetRepository(LifeBetContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LifeBet>> GetAllLifeBets()
        {
            return await _context.LifeBets.ToListAsync();
        }
    }
}
