using Microsoft.AspNetCore.Identity;

namespace BakaBack.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int BakaCoins { get; set; } = 100; // Initialiser avec 100 BakaCoins à l'inscription
    }
}
