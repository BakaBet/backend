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
        public List<Outcome> Outcomes { get; set; }
    }
}
