using Microsoft.AspNetCore.Mvc;
using Models.Cars;
using Models.Statistics;
using System.Collections.Generic;
using WebAPI.Services.Statistic.Statistics;
using System.Linq;
using WebAPI.Repository.Models;

namespace WebAPI.Controllers
{
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
            IEnumerable<CapturedCar> cars = from car in _userContext.Cars
                                                    join image in _userContext.Images on car.Id equals image.CarId
                                                    select CarFactory.GetInstance().CreateCapturedCar(car, image);

            return StatisticFactory.GetStatistic(type).Get(cars.ToList()); ;
        }
    }
}
 