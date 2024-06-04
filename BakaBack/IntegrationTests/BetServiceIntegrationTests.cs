using BakaBack.Domain.Interfaces;
using BakaBack.Domain.Models;
using BakaBack.Domain.Services;
using BakaBack.Infrastructure.Contexts;
using BakaBack.Infrastructure.Models;
using BakaBack.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace IntegrationTests
{
    public class BetServiceIntegrationTests
    {
        private readonly IBetService _betService;
        private readonly IBetRepository _betRepository;
        private readonly ApplicationDbContext _context;
        private readonly IUserService _userService;
        private readonly IUserRepository _userRepository;
        private readonly IEventRepository _eventRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEventService _eventService;

        public BetServiceIntegrationTests()
        {
            // Set up the DI container
            var serviceProvider = new ServiceCollection()
                .AddTransient<IBetService, BetService>()
                .AddTransient<IBetRepository, BetRepository>()
                .AddDbContext<ApplicationDbContext>(options =>
                {
                    options.UseInMemoryDatabase("TestDb");
                })
                .AddTransient<IUserService, UserService>()
                .AddTransient<IUserRepository, UserRepository>()
                .AddTransient<IEventRepository, EventRepository>()
                .AddTransient<UserManager<ApplicationUser>>()
                .AddTransient<IEventService, EventService>()
                .BuildServiceProvider();

            // Resolve the dependencies
            _betService = serviceProvider.GetService<IBetService>();
            _betRepository = serviceProvider.GetService<IBetRepository>();
            _context = serviceProvider.GetService<ApplicationDbContext>();
            _userService = serviceProvider.GetService<IUserService>();
            _userRepository = serviceProvider.GetService<IUserRepository>();
            _eventRepository = serviceProvider.GetService<IEventRepository>();
            _userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();
            _eventService = serviceProvider.GetService<IEventService>();
        }

        [Fact]
        public async Task PlaceBetAsync_ShouldPlaceBetAndReturnBet()
        {
            // Arrange
            // Create user
            var user = new ApplicationUser
            {
                Id = "user1",
                UserName = "user1",
                Email = "user1@user1.com",
                FirstName = "User",
                LastName = "One",
                Bets = new List<Bet>(),
                Coins = 1000,
                PhoneNumber = "1234567890"
            };
            await _userManager.CreateAsync(user, "password");
            var bet = new Bet
            {
                UserId = user.Id,
                EventId = "event1",
                Amount = 100,
                Team = "Team A"
            };
            // Act
            var result = await _betService.PlaceBetAsync(bet);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(bet.UserId, result.UserId);
            Assert.Equal(bet.EventId, result.EventId);
            Assert.Equal(bet.Amount, result.Amount);
            Assert.Equal(bet.Team, result.Team);
        }

        [Fact]
        public async Task GetUserBetsAsync_ShouldReturnUserBets()
        {
            // Arrange
            // Create user
            var user = new ApplicationUser
            {
                Id = "user1",
                UserName = "user1",
                Email = "user1@user1.com",
                FirstName = "User",
                LastName = "One",
                Bets = new List<Bet>(),
                Coins = 1000,
                PhoneNumber = "1234567890"
            };
            await _userManager.CreateAsync(user, "password");

            // Act
            var result = await _betService.GetUserBetsAsync(user.Id);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var bet in result)
            {
                Assert.Equal(user.Id, bet.UserId);
            }
        }
    }
}
