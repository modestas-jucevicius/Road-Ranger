using Microsoft.AspNetCore.Mvc;
using Models.Cars;
using System.Threading.Tasks;
using WebAPIService.EPolicija;
using WebAPIService.Score;

namespace WebAPI.Controllers
{
    [Route("api/numbers")]
    [ApiController]
    public class LicensePlateController : ControllerBase
    {
        private ICarStatusRequester reguester;

        public LicensePlateController()
        {
            reguester = EPolicijaAPIRequester.GetInstance();
        }

        // POST: api/numbers/check?licensePlate={licensePlate}
        [HttpPost("check")]
        public async Task<CarStatus> Check([FromQuery] string licensePlate)
        {
            CarStatus status = await reguester.AskCarStatus(licensePlate);
            Evaluation.Instance.IncreaseScore(status);
            return status;
        }
    }
}