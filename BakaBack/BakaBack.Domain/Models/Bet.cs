namespace BakaBack.Domain.Models
{
    public class Bet
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string MatchId { get; set; }
        public virtual SportEvent Match { get; set; }
        public decimal Amount { get; set; }
        public DateTime DatePlaced { get; set; }
        public bool IsWon { get; set; }
    }
}
