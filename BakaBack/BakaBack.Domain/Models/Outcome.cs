namespace BakaBack.Domain.Models
{
    public class Outcome
    {
        public decimal Odds { get; set; }

        public Outcome(decimal odds)
        {
            ValidateOdds(odds);
            Odds = odds;
        }

        private void ValidateOdds(decimal odds)
        {
            if (odds <= 0)
            {
                throw new ArgumentException("Odds must be positive");
            }
        }
    }
}