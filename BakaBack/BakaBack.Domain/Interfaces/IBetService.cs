﻿using BakaBack.Domain.Models;

namespace BakaBack.Domain.Interfaces
{
    public interface IBetService
    {
        Task<Bet> PlaceBetAsync(Bet bet);
        Task<IEnumerable<Bet>> GetUserBetsAsync(string user_id);
    }
}