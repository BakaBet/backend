namespace BakaBack.Domain.Models
{
    public class SportEvent
    {
        public string Id { get; set; }
        public string SportKey { get; set; }
        public string SportTitle { get; set; }
        public DateTime CommenceTime { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public decimal? HomeOutcome { get; set; }
        public decimal? AwayOutcome { get; set; }

        public SportEvent(string id,string sportKey, string sportTitle, DateTime commenceTime, string homeTeam, string awayTeam, decimal? homeOutcome, decimal? awayOutcome)
        {
            if(homeOutcome != null && awayOutcome !=null)
            {
                ValidateOdds(homeOutcome, awayOutcome);
            }

            Id = id;
            SportKey = sportKey;
            SportTitle = sportTitle;
            CommenceTime = commenceTime;
            HomeTeam = homeTeam;
            AwayTeam = awayTeam;
            HomeOutcome = homeOutcome;
            AwayOutcome = awayOutcome;
        }

        public bool HasEnded()
        {
            return CommenceTime < DateTime.Now;
        }

        private void ValidateOdds(decimal? HomeOutcome , decimal? AwayOutcome)
        {
            if (HomeOutcome <= 0)
            {
                throw new ArgumentException("Odds must be positive");
            }

            if (AwayOutcome <= 0)
            {
                throw new ArgumentException("Odds must be positive");
            }
        }
    }
}
