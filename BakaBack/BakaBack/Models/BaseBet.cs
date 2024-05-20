namespace BakaBack.Models
{
    public abstract class BaseBet
    {
        public int BetId { get; set; }
        public string Description { get; set; }
        public string Winner { get; set; }
        public bool Closed { get; set; }
        public int MaxBet { get; set; }
        public int MinBet { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime StartTime { get; set; }
        public string Status { get; set; }

        public abstract double GetOdds(string selectedTeam);

        public double CalculatePayout(double amount, string selectedTeam)
        {
            if (Closed || Winner == null)
            {
                return 0;
            }

            double odds = GetOdds(selectedTeam);

            if (odds <= 0)
            {
                return 0;
            }

            return amount * odds;
        }

        public void UpdateBetResult(string winner)
        {
            if (Closed)
            {
                return;
            }

            Winner = winner;
            Closed = true;
        }
    }
}
