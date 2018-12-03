using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Users;
using Storage.Data;
using System;
using System.Collections.Generic;
using WebAPIService.Score;

namespace WebAPI.Controllers
{
    [Route("api/score")]
    [ApiController]
    public class ScoreController : ControllerBase
    {
        private HighscoresService highscores;
        private BoostShopService shop;

        public ScoreController()
        {
            highscores = HighscoresService.Instance;
            shop = BoostShopService.GetInstance();
            MemoryRepository.GetInstance();
        }

        // GET: api/score/top
        [AllowAnonymous]
        [HttpGet("top")]
        public IEnumerable<User> GetTop()
        {
            List<User> users = HighscoresService.Instance.GetTops(MemoryRepository.users);
            return users.ConvertAll<User>(x => new User
            {
                Username = x.Username,
                Score = x.Score
            });
        }

        // POST: api/score/boost30p
        [AllowAnonymous]
        [HttpPost("boost30p")]
        public int Boost30p([FromBody]User user)
        {
            try
            {
                shop.BuyBoost30p(user);
                return 0;
            }
            catch (NotEnoughScorePointsException ex)
            {
                return 1;
            }
            catch (Exception ex)
            {
                return 2;
            }
        }

        // POST: api/score/boost50p
        [AllowAnonymous]
        [HttpPost("boost50p")]
        public int Boost50p([FromBody]User user)
        {
            try
            {
                shop.BuyBoost50p(user);
                return 0;
            }
            catch (NotEnoughScorePointsException ex)
            {
                return 1;
            }
            catch (Exception ex)
            {
                return 2;
            }
        }

        // POST: api/score/boost30p
        [AllowAnonymous]
        [HttpPost("boostdouble")]
        public int BoostDouble([FromBody]User user)
        {
            try
            {
                shop.BuyBoostDouble(user);
                return 0;
            }
            catch (NotEnoughScorePointsException ex)
            {
                return 1;
            }
            catch (Exception ex)
            {
                return 2;
            }
        }

    }
}