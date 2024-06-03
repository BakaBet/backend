namespace BakaBack.Domain.Models
{
    public interface IUser
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public int Coins { get; set; }
        public List<Bet> Bets { get; set; }
    }
}
