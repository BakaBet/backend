namespace BakaBack.Models
{
    public class SportBet : BaseBet
    {
        public string Sport { get; set; }
        public string League { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public DateTime MatchTime { get; set; }
        public double? HomeOdds { get; set; }
        public double? DrawOdds { get; set; }
        public double? AwayOdds { get; set; }

        public override double GetOdds(string selectedTeam)
        {
            if (selectedTeam == HomeTeam)
            {
                return HomeOdds.Value;
            }
            else if (selectedTeam == "Draw")
            {
                return DrawOdds.Value;
            }
            else
            {
                return AwayOdds.Value;
            }
        }
    }
}
