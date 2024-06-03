using BakaBack.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BakaBack.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BakaCoinController
    {
        private readonly BakaCoinRepository _coinRepository;

        public BakaCoinController(BakaCoinRepository coinRepository)
        {
            _coinRepository = coinRepository;
        }

        [HttpGet("{id}")]
        public Task<IActionResult> GetUserBakaCoins(string id) {
            return null;
        }

        [HttpPatch("{id}")]
        public Task<IActionResult> UpdateUserCoins(string id)
        {
            return null;
        }
    }
}
