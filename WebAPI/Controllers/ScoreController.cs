using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebAPI.Repository.Models;
using WebAPI.Services.Score;

namespace WebAPI.Controllers
{
    [Route("api/score")]
    [ApiController]
    public class ScoreController : ControllerBase
    {
        private HighscoresService highscores;
        private BoostShopService shop;
        private UserContext _userContext;

        public ScoreController(UserContext userContext)
        {
            _userContext = userContext;
            highscores = HighscoresService.Instance;
            shop = BoostShopService.GetInstance();
        }

        // GET: api/score/top
        [AllowAnonymous]
        [HttpGet("top")]
        public IEnumerable<Models.Users.User> GetTop()
        {
            IQueryable<User> query = from temp in _userContext.Users select temp;

            List<Models.Users.User> list = query.ToList().ConvertAll<Models.Users.User>(x => new Models.Users.User
            {
                Username = x.Username,
                Score = x.Score,
                BoostType = x.BoostType
            });

            List<Models.Users.User> users = HighscoresService.Instance.GetTops(list);
            return users.ConvertAll<Models.Users.User>(x => new Models.Users.User
            {
                Username = x.Username,
                Score = x.Score
            });
        }

        // POST: api/score/boost30p
        [AllowAnonymous]
        [HttpPost("boost30p")]
        public int Boost30p([FromBody]Models.Users.User user)
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
        public int Boost50p([FromBody]Models.Users.User user)
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
        public int BoostDouble([FromBody]Models.Users.User user)
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
