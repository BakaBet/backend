using BakaBack.Domain.Interfaces;

namespace BakaBack.Domain.Services
{
    public class OddsService : IOddsService
    {
        private readonly IBetRepository _betRepository;
        private readonly IEventRepository _sportEventRepository;

        public OddsService(IBetRepository betRepository, IEventRepository sportEventRepository)
        {
            _betRepository = betRepository;
            _sportEventRepository = sportEventRepository;
        }

        public async Task UpdateOddsAsync(string eventId)
        {
            var bets = await _betRepository.GetBetsByEventIdAsync(eventId);
            var sportEvent = await _sportEventRepository.GetSportsEventByIdAsync(eventId);

            if (sportEvent == null) throw new ArgumentException("Invalid event ID");

            var homeBets = bets.Count(b => b.Team == sportEvent.HomeTeam);
            var awayBets = bets.Count(b => b.Team == sportEvent.AwayTeam);

            var totalBets = homeBets + awayBets;

            if (totalBets > 0)
            {

                await UpdateAwayOutcomeAsync(eventId, CalculateOutcome(awayBets, totalBets));
                await UpdateHomeOutcomeAsync(eventId, CalculateOutcome(homeBets, totalBets));

            }
        }

        public async Task UpdateAwayOutcomeAsync(string eventId, decimal? value)
        {
            await _sportEventRepository.UpdateAwayOutcomeAsync(eventId, value);
        }

        public async Task UpdateHomeOutcomeAsync(string eventId, decimal? value)
        {
            await _sportEventRepository.UpdateHomeOutcomeAsync(eventId, value);
        }
        public decimal CalculateOutcome(int bets, int totalBets)
        {

            if (bets < 1 && totalBets > 1)
            {
                bets = 1;
            }
            return 1.0m / ((decimal)bets / totalBets);
        }
    }
}
