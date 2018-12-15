using Microsoft.AspNetCore.Mvc;
using Models.Cars;
using Models.Statistics;
using System.Collections.Generic;
using WebAPI.Services.Statistic.Statistics;
using System.Linq;
using WebAPI.Repository.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace WebAPI.Controllers
{
    [Authorize]
    [Route("api/statistic")]
    [ApiController]
    public class StatisticController : ControllerBase
    {
        private readonly UserContext _userContext;

        public StatisticController(UserContext context)
        {
            this._userContext = context;
        }

        // GET: api/statistic/entries?type={type}
        /*
         * 0 - by date
         * 1 - by years
         * 2 - by model
         * > 2 - by status
         */
        [HttpGet("entries")]
        public IEnumerable<StatisticEntry> GetEntries([FromQuery] int type)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity; //Gets Information from Token
            string ID = identity.FindFirst(ClaimTypes.Name).Value; //Takes Token field "Name" value
            IEnumerable<CapturedCar> cars = from car in _userContext.Cars
                                            where car.UserId == ID
                                            join image in _userContext.Images on car.Id equals image.CarId
                                            select CarFactory.GetInstance().CreateCapturedCar(car, image);

            return StatisticFactory.GetStatistic(type).Get(cars.ToList()); ;
        }
    }
}
 