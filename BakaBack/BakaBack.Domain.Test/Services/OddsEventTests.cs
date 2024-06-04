using BakaBack.Domain.Services;


namespace BakaBack.Domain.Test.Services
{
    public class OddsEventTests
    {
        [Theory]
        [InlineData(2, 4, 2)]
        [InlineData(4, 4, 1)]
        [InlineData(1, 1, 1)]
        [InlineData(1, 2, 2)]
        public void CalculateHomeOutcomeAsync_ReturnsCorrectValue(int bets, int totalBets, decimal expectedOutcome)
        {
            // Arrange
            var oddsService = new OddsService(null, null);

            // Act
            var result = oddsService.CalculateOutcome(bets, totalBets);

            // Assert
            Assert.Equal(expectedOutcome, result);
        }

        [Theory]
        [InlineData(1, 5, 3)]
        [InlineData(2, 5, 2)]
        [InlineData(1, 1, 2)]
        public void CalculateAwayOutcomeAsync_ReturnsInvalidValue(int bets, int totalBets, decimal expectedOutcome)
        {
            // Arrange
            var oddsService = new OddsService(null, null);

            // Act
            var result = oddsService.CalculateOutcome(bets, totalBets);

            // Assert
            Assert.NotEqual(expectedOutcome, result);
        }

    }
}
