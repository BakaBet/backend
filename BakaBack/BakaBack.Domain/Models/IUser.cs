namespace BakaBack.Domain.Models
{
    public interface IUser
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Coins { get; set; }
        public List<Bet> Bets { get; set; }
    }
}
