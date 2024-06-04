using BakaBack.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakaBack.Domain.Test.Models
{
    public class BetEventTests
    {
        [Fact]
        public void EndBet_ShouldEndBetAfterEndTime()
        {
            // Arrange
            var bet = new Bet
            {
                Id = 1,
                UserId = "user1",
                EventId = "event1",
                Amount = 100,
                DatePlaced = DateTime.Now,
                Odd = 2.5m,
                Team = "TeamA",
                EndTime = DateTime.Now.AddSeconds(-1)
            };

            // Act
            var result = bet.EndBet();

            // Assert
            Assert.True(result);
            Assert.True(bet.IsEnded);
        }

        [Fact]
        public void EndBet_ShouldNotEndBetBeforeEndTime()
        {
            // Arrange
            var bet = new Bet
            {
                Id = 1,
                UserId = "user1",
                EventId = "event1",
                Amount = 100,
                DatePlaced = DateTime.Now,
                Odd = 2.5m,
                Team = "TeamA",
                EndTime = DateTime.Now.AddMinutes(1)
            };

            // Act
            var result = bet.EndBet();

            // Assert
            Assert.False(result);
            Assert.False(bet.IsEnded);
        }

        [Fact]
        public void EndBet_ShouldCalculateGainsWhenWon()
        {
            // Arrange
            var bet = new Bet
            {
                Id = 1,
                UserId = "user1",
                EventId = "event1",
                Amount = 100,
                DatePlaced = DateTime.Now,
                Odd = 2.5m,
                Team = "TeamA",
                EndTime = DateTime.Now.AddSeconds(-1)
            };

            // Act
            bet.EndBet();
            if (bet.IsWon)
            {
                Assert.Equal(250, bet.Gains);
            }
            else
            {
                Assert.Equal(0, bet.Gains);
            }
        }
    }
}
