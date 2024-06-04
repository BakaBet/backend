namespace BakaBack.Domain.Models
{
    public class Participation
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public decimal Stake { get; set; }
        public decimal Odds { get; set; }

        public Participation(string userId, decimal stake, decimal odds)
        {
            UserId = userId;
            Stake = ValidateStake(Stake);
            Odds = ValidateOdds(Odds);
        }

        private static decimal ValidateStake(decimal stake)
        {
            if (stake <= 0)
            {
                throw new ArgumentException("Stake must be greater than 0");
            }
            return stake;
        }

        private static decimal ValidateOdds(decimal odds)
        {
            if (odds <= 0)
            {
                throw new ArgumentException("Odds must be greater than 0");
            }
            return odds;
        }
    }
}
