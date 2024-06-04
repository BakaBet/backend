using BakaBack.Domain.Models;
using BakaBack.Infrastructure.Contexts;
using BakaBack.Infrastructure.Models;
using BakaBack.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace BakaBack.Infrastructure.Test.Repositories
{
    public class UserRepositoryTests
    {
       /* [Fact]
        public async Task AddBonusAsync_Should_AddBonusToUser()
        {
            // Arrange
            var userId = "user1";
            var bonusAmount = 10m;
            var user = new ApplicationUser { Id = userId, Coins = 0 };
            var dbContextMock = new Mock<ApplicationDbContext>();
            var userDbSetMock = new Mock<DbSet<ApplicationUser>>();
            userDbSetMock.Setup(x => x.FindAsync(userId)).ReturnsAsync(user);
            dbContextMock.Setup(x => x.Users).Returns(userDbSetMock.Object);
            var userRepository = new UserRepository(dbContextMock.Object);

            // Act
            var result = await userRepository.AddBonusAsync(userId, bonusAmount);

            // Assert
            Assert.True(result);
            Assert.Equal(bonusAmount, user.Coins);
            //dbContextMock.Verify(x => x.SaveChangesAsync(), Times.Once);
        }

        [Fact]
        public async Task AddBonusAsync_Should_ReturnFalse_WhenUserNotFound()
        {
            // Arrange
            var userId = "user1";
            var bonusAmount = 10m;
            ApplicationUser user = null;
            var dbContextMock = new Mock<ApplicationDbContext>();
            var userDbSetMock = new Mock<DbSet<ApplicationUser>>();
            userDbSetMock.Setup(x => x.FindAsync(userId)).ReturnsAsync(user);
            dbContextMock.Setup(x => x.Users).Returns(userDbSetMock.Object);
            var userRepository = new UserRepository(dbContextMock.Object);

            // Act
            var result = await userRepository.AddBonusAsync(userId, bonusAmount);

            // Assert
            Assert.False(result);
            //dbContextMock.Verify(x => x.SaveChangesAsync(), Times.Never);
        }

        [Fact]
        public async Task GetUserByIdAsync_Should_ReturnUser()
        {
            // Arrange
            var userId = "user1";
            var user = new ApplicationUser { Id = userId };
            var dbContextMock = new Mock<ApplicationDbContext>();
            var userDbSetMock = new Mock<DbSet<ApplicationUser>>();
            userDbSetMock.Setup(x => x.FindAsync(userId)).ReturnsAsync(user);
            dbContextMock.Setup(x => x.Users).Returns(userDbSetMock.Object);
            var userRepository = new UserRepository(dbContextMock.Object);

            // Act
            var result = await userRepository.GetUserByIdAsync(userId);

            // Assert
            Assert.Equal(user, result);
        }

        [Fact]
        public async Task GetUserBalanceAsync_Should_ReturnUserBalance()
        {
            // Arrange
            var userId = "user1";
            var coins = 100m;
            var user = new ApplicationUser { Id = userId, Coins = coins };
            var dbContextMock = new Mock<ApplicationDbContext>();
            var userDbSetMock = new Mock<DbSet<ApplicationUser>>();
            userDbSetMock.Setup(x => x.FindAsync(userId)).ReturnsAsync(user);
            dbContextMock.Setup(x => x.Users).Returns(userDbSetMock.Object);
            var userRepository = new UserRepository(dbContextMock.Object);

            // Act
            var result = await userRepository.GetUserBalanceAsync(userId);

            // Assert
            Assert.Equal(coins, result);
        }

        [Fact]
        public async Task GetUserBalanceAsync_Should_ReturnNull_WhenUserNotFound()
        {
            // Arrange
            var userId = "user1";
            ApplicationUser user = null;
            var dbContextMock = new Mock<ApplicationDbContext>();
            var userDbSetMock = new Mock<DbSet<ApplicationUser>>();
            userDbSetMock.Setup(x => x.FindAsync(userId)).ReturnsAsync(user);
            dbContextMock.Setup(x => x.Users).Returns(userDbSetMock.Object);
            var userRepository = new UserRepository(dbContextMock.Object);

            // Act
            var result = await userRepository.GetUserBalanceAsync(userId);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task GetUserBetHistoryAsync_Should_ReturnUserBetHistory()
        {
            // Arrange
            var userId = "user1";
            var bets = new List<Bet> { new Bet { UserId = userId }, new Bet { UserId = userId } };
            var dbContextMock = new Mock<ApplicationDbContext>();
            var betDbSetMock = new Mock<DbSet<Bet>>();
            betDbSetMock.Setup(x => x.Where(b => b.UserId == userId)).Returns(bets.AsQueryable());
            dbContextMock.Setup(x => x.Bets).Returns(betDbSetMock.Object);
            var userRepository = new UserRepository(dbContextMock.Object);

            // Act
            var result = await userRepository.GetUserBetHistoryAsync(userId);

            // Assert
            Assert.Equal(bets, result);
        }

        [Fact]
        public async Task UpdateUserAsync_Should_UpdateUser()
        {
            // Arrange
            var userId = "user1";
            var firstName = "John";
            var lastName = "Doe";
            var email = "john.doe@example.com";
            var user = new ApplicationUser { Id = userId };
            var dbContextMock = new Mock<ApplicationDbContext>();
            var userDbSetMock = new Mock<DbSet<ApplicationUser>>();
            userDbSetMock.Setup(x => x.FindAsync(userId)).ReturnsAsync(user);
            dbContextMock.Setup(x => x.Users).Returns(userDbSetMock.Object);
            var userRepository = new UserRepository(dbContextMock.Object);

            // Act
            var result = await userRepository.UpdateUserAsync(userId, firstName, lastName, email);

            // Assert
            Assert.True(result);
            Assert.Equal(firstName, user.FirstName);
            Assert.Equal(lastName, user.LastName);
            Assert.Equal(email, user.Email);
            //dbContextMock.Verify(x => x.SaveChangesAsync(), Times.Once);
        }

        [Fact]
        public async Task UpdateUserAsync_Should_ReturnFalse_WhenUserNotFound()
        {
            // Arrange
            var userId = "user1";
            var firstName = "John";
            var lastName = "Doe";
            var email = "john.doe@example.com";
            ApplicationUser user = null;
            var dbContextMock = new Mock<ApplicationDbContext>();
            var userDbSetMock = new Mock<DbSet<ApplicationUser>>();
            userDbSetMock.Setup(x => x.FindAsync(userId)).ReturnsAsync(user);
            dbContextMock.Setup(x => x.Users).Returns(userDbSetMock.Object);
            var userRepository = new UserRepository(dbContextMock.Object);

            // Act
            var result = await userRepository.UpdateUserAsync(userId, firstName, lastName, email);

            // Assert
            Assert.False(result);
            //dbContextMock.Verify(x => x.SaveChangesAsync(), Times.Never);
        }

        [Fact]
        public async Task SubtractCoinsAsync_Should_SubtractCoinsFromUser()
        {
            // Arrange
            var userId = "user1";
            var amount = 10m;
            var user = new ApplicationUser { Id = userId, Coins = 20m };
            var dbContextMock = new Mock<ApplicationDbContext>();
            var userDbSetMock = new Mock<DbSet<ApplicationUser>>();
            userDbSetMock.Setup(x => x.FindAsync(userId)).ReturnsAsync(user);
            dbContextMock.Setup(x => x.Users).Returns(userDbSetMock.Object);
            var userRepository = new UserRepository(dbContextMock.Object);

            // Act
            var result = await userRepository.SubtractCoinsAsync(userId, amount);

            // Assert
            Assert.True(result);
            Assert.Equal(10m, user.Coins);
            //dbContextMock.Verify(x => x.SaveChangesAsync(), Times.Once);
        }

        [Fact]
        public async Task SubtractCoinsAsync_Should_ReturnFalse_WhenUserNotFound()
        {
            // Arrange
            var userId = "user1";
            var amount = 10m;
            ApplicationUser user = null;
            var dbContextMock = new Mock<ApplicationDbContext>();
            var userDbSetMock = new Mock<DbSet<ApplicationUser>>();
            userDbSetMock.Setup(x => x.FindAsync(userId)).ReturnsAsync(user);
            dbContextMock.Setup(x => x.Users).Returns(userDbSetMock.Object);
            var userRepository = new UserRepository(dbContextMock.Object);

            // Act
            var result = await userRepository.SubtractCoinsAsync(userId, amount);

            // Assert
            Assert.False(result);
            //dbContextMock.Verify(x => x.SaveChangesAsync(), Times.Never);
        } */
    }
}
