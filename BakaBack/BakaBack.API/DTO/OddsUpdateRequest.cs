namespace BakaBack.API.DTO
{
    public class OddsUpdateRequest
    {
        public string BetOption { get; set; }
        public decimal NewOdds { get; set; }
    }
}
