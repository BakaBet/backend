namespace BakaBack.Domain.Models
{
    public class Bet
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string EventId { get; set; }
        public decimal Amount { get; set; }
        public DateTime DatePlaced { get; set; }
        public decimal Odd { get; set; }
        public bool IsWon { get; set; }
        public string Team { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsEnded { get; set; }
        public decimal? Gains { get; set; }

        private void ValidateBet(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Amount must be greater than 0");
            }
        }

        public bool EndBet()
        {
            if (!IsEnded && DateTime.Now >= EndTime)
            {
                IsEnded = true;
                RandomWinner();
                AttributeGains();
                return true;
            }

            return false;
        }

        private void AttributeGains()
        {
            if (IsWon)
            {
                Gains = Amount * Odd;
            }
            else
            {
                Gains = 0;
            }
        }

        private void RandomWinner()
        {
            Random random = new Random();
            int winner = random.Next(0, 2);
            IsWon = winner == 1;
        }
    }
}
