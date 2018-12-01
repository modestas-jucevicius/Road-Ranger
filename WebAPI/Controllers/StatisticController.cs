using Microsoft.AspNetCore.Mvc;
using Models.Statistics;
using Storage.Data;
using System.Collections.Generic;
using WebAPIServices.Statistic.Statistics;

namespace WebAPI.Controllers
{
    [Route("api/statistic")]
    [ApiController]
    public class StatisticController : ControllerBase
    {
        private readonly CapturedCarService service;

        public StatisticController()
        {
            MemoryRepository.GetInstance();
            service = new CapturedCarService();
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
            return StatisticFactory.GetStatistic(type).Get(service.FindAll()); ;
        }
    }
}
 