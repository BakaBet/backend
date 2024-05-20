namespace BakaBack.Models
{
    public class LifeBet : BaseBet
    {
        public int Odd { get; set; }
        public int OddProposal { get; set; }

        public override double GetOdds(string selectedTeam)
        {
            return Odd;
        }
    }
}
