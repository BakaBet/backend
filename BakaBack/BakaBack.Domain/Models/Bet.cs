namespace BakaBack.Domain.Models
{
    public class Bet
    {
        public int Id { get; set; }
        public string UserId { get; private set; }
        public string EventId { get; private set; }
        public decimal Amount { get; private set; }
        public DateTime DatePlaced { get; private set; }
        public decimal Odd { get; private set; }
        public bool IsWon { get; set; }

        public Bet(string userId, string eventId, decimal amount)
        {
            ValidateBet(amount);
            UserId = userId;
            EventId = eventId;
            Amount = amount;
            DatePlaced = DateTime.Now;
            IsWon = false;
        }

        private void ValidateBet(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Amount must be greater than 0");
            }
        }
    }
}
