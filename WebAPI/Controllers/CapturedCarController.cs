using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Cars;
using Storage.Data;

namespace WebAPI.Controllers
{
    [Route("api/cars")]
    [ApiController]
    public class CapturedCarController : ControllerBase
    {
        private CapturedCarService service = new CapturedCarService();

        public CapturedCarController()
        {
            MemoryRepository.GetInstance();
        }

        // GET: api/cars/all
        [HttpGet("all")]
        public IEnumerable<CapturedCar> GetAll()
        {
            return service.FindAll();
        }

        // GET: api/cars/get?licenseplate={licensePlate}
        [HttpGet("get")]
        public IEnumerable<CapturedCar> Get([FromQuery] string LicensePlate)
        {
            return service.FindByPlate(LicensePlate);
        }

        // GET: api/cars/byuser?id={id}
        [HttpGet("byuser")]
        public IEnumerable<CapturedCar> Get([FromQuery] int id)
        {
            return service.FindByUserId(id);
        }

        // POST: api/cars/add
        [AllowAnonymous]
        [HttpPost("add")]
        public void Add([FromBody] CapturedCar car)
        {
            service.Add(car);
        }

        // DELETE: api/cars/remove?id={id}
        [HttpDelete("remove")]
        public void Remove([FromQuery] int id)
        {
            service.RemoveByCarId(id);
        }
    }
}
