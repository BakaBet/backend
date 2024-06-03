using BakaBack.Infrastructure.Contexts;

namespace BakaBack.Infrastructure.Repositories
{
    public class BakaCoinRepository
    {
        private readonly ApplicationDbContext _context;

        public BakaCoinRepository(ApplicationDbContext context) {
            _context = context;
        }
    }
}
