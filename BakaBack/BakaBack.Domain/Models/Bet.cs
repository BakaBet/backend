using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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

        private void ValidateBet(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Amount must be greater than 0");
            }
        }
    }
}
