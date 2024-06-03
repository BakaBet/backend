namespace BakaBack.Domain.Models
{
    public class LifeBet
    {
        public int Id { get; set; }
        public string Terms { get; set; }
        public decimal Odds { get; set; }
        public decimal InitialStake { get; set; }
        public string Status { get; set; }
        public string CreatorId { get; set; }
    }
}
