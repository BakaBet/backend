using Microsoft.AspNetCore.Identity;
using BakaBack.Domain.Models;

namespace BakaBack.Infrastructure.Models
{
    public class ApplicationUser : IdentityUser, IUser
    {
        public List<Bet> Bets { get; set; }
        public decimal Coins { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
