using BakaBack.Domain.Test.Fixtures;
using System;
using Xunit;

namespace BakaBack.Domain.Models.Tests
{
    public class SportEventTests
    {
        [Fact]
        public void HasEnded_ReturnsTrue_WhenEventIsInThePast()
        {
            // Arrange
            var fakeClock = new FakeClock(new DateTime(2024, 3, 10));
            var commenceTime = fakeClock.Now;
            var sportEvent = new SportEvent("1",
                "soccer",
                "Soccer Match",
                commenceTime,
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
            // Arrange
            var fakeClock = new FakeClock(new DateTime(2025, 3, 10));
            var commenceTime = fakeClock.Now;
            var sportEvent = new SportEvent("1",
                "soccer",
                "Soccer Match",
                commenceTime,
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
            // Arrange
            var fakeClock = new FakeClock(new DateTime(2022, 3, 10));
            var commenceTime = fakeClock.Now;
            var sportEvent = new SportEvent("1",
                "soccer",
                "Soccer Match",
                commenceTime,
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
            // Arrange
            var fakeClock = new FakeClock(new DateTime(2025, 3, 10));
            var commenceTime = fakeClock.Now;
            var sportEvent = new SportEvent("1",
                "soccer",
                "Soccer Match",
                commenceTime,
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
