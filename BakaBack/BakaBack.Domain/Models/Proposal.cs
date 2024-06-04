namespace BakaBack.Domain.Models
{
    public class Proposal
    {
        public string UserId { get; }
        public string EventId { get; }
        public string Terms { get; }
        public decimal Odds { get; }
        public decimal Stake { get; }

        public Proposal(string userId, string eventId, string terms, decimal odds, decimal stake)
        {
            UserId = userId;
            EventId = eventId;
            Terms = terms;
            Odds = ValidateOdds(odds);
            Stake = ValidateStake(stake);
        }

        private static decimal ValidateOdds(decimal odds)
        {
            if (odds <= 0)
            {
                throw new ArgumentException("Odds must be positive");
            }
            return odds;
        }

        private static decimal ValidateStake(decimal stake)
        {
            if (stake <= 0)
            {
                throw new ArgumentException("Stake must be positive");
            }
            return stake;
        }
    }
}
