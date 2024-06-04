using BakaBack.Domain.Interfaces;
using BakaBack.Domain.Services;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BakaBack.Infrastructure.Services
{
    public class TimerService
    {
        private readonly Timer _timer;
        private readonly IBetService _betService;

        public TimerService(IBetService betService)
        {
            _betService = betService;
            _timer = new Timer(async (e) => await CheckBets(), null, TimeSpan.Zero, TimeSpan.FromMinutes(1));
        }

        private async Task CheckBets()
        {
            await _betService.CheckAndEndBetsAsync();
        }

        public void Stop()
        {
            _timer.Dispose();
        }
    }
}