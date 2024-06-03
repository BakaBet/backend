namespace BakaBack.Domain.Models
{
    public class Match
    {
        public string Id { get; set; }
        public string SportKey { get; set; }
        public DateTime CommenceTime { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public List<Outcome> Outcomes { get; set; }
    }
}
