using BakaBack.Domain.Test.Fixtures;
using System;
using Xunit;

namespace BakaBack.Domain.Models.Tests
{
    public class SportEventTests
    {
        [Fact]
        public void Constructor_ThrowsException_WhenOddsAreNonPositive()
        {
            var fakeClock = new FakeClock(new DateTime(2024, 3, 10));

            // Arrange
            var id = "1";
            var sportKey = "soccer";
            var sportTitle = "Soccer Match";
            var commenceTime = fakeClock.Now;
            var homeTeam = "Team A";
            var awayTeam = "Team B";

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new SportEvent(id, sportKey, sportTitle, commenceTime, homeTeam, awayTeam, -1m, 2.5m));
            Assert.Throws<ArgumentException>(() => new SportEvent(id, sportKey, sportTitle, commenceTime, homeTeam, awayTeam, 1.5m, 0m));
        }

        [Fact]
        public void HasEnded_ReturnsTrue_WhenEventIsInThePast()
        {
            var fakeClock = new FakeClock(new DateTime(2024, 3, 10));

            // Arrange
            var sportEvent = new SportEvent("1",
                "soccer",
                "Soccer Match",
                fakeClock.Now,
                "Team A",
                "Team B",
                1.5m,
                2.5m);

            // Act
            var result = sportEvent.HasEnded();

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void HasEnded_ReturnsFalse_WhenEventIsInTheFuture()
        {
            var fakeClock = new FakeClock(new DateTime(2025, 3, 10));

            // Arrange
            var sportEvent = new SportEvent("1",
                "soccer",
                "Soccer Match",
                fakeClock.Now,
                "Team A",
                "Team B",
                1.5m,
                2.5m);

            // Act
            var result = sportEvent.HasEnded();

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void MarkAsFinished_SetsIsFinished_WhenEventHasEnded()
        {
            var fakeClock = new FakeClock(new DateTime(2022, 3, 10));

            // Arrange
            var sportEvent = new SportEvent("1",
                "soccer",
                "Soccer Match",
                fakeClock.Now,
                "Team A",
                "Team B",
                1.5m,
                2.5m);

            // Act
            sportEvent.MarkAsFinished();

            // Assert
            Assert.True(sportEvent.IsFinished);
        }

        [Fact]
        public void MarkAsFinished_DoesNotSetIsFinished_WhenEventHasNotEnded()
        {
            var fakeClock = new FakeClock(new DateTime(2025, 3, 10));

            // Arrange
            var sportEvent = new SportEvent("1",
                "soccer",
                "Soccer Match",
                fakeClock.Now,
                "Team A",
                "Team B",
                1.5m,
                2.5m);

            // Act
            sportEvent.MarkAsFinished();

            // Assert
            Assert.False(sportEvent.IsFinished);
        }
    }
}
