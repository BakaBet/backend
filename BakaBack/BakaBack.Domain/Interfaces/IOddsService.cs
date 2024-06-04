namespace BakaBack.Domain.Interfaces
{
    public interface IOddsService
    {
        Task UpdateOddsAsync(string eventId);
        Task UpdateAwayOutcomeAsync(string eventId, decimal? value);
        Task UpdateHomeOutcomeAsync(string eventId, decimal? value);
        decimal CalculateOutcome(int homeBets, int totalBets);
    }
}
