﻿using Microsoft.AspNetCore.Identity;
using BakaBack.Domain.Models;

namespace BakaBack.Infrastructure.Models
{
    public class ApplicationUser : IdentityUser, IUser
    {
        public string Username { get; set; }
        public int Coins { get; set; }
        public List<Bet> Bets { get; set; }
    }
}
