using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Cars;
using WebAPI.Repository.Models;
using System.Linq;
using Models.Images;
using WebAPI.Services.Score;

namespace WebAPI.Controllers
{
    [Route("api/cars")]
    [ApiController]
    public class CapturedCarController : ControllerBase
    {
        private UserContext _userContext;

        public CapturedCarController(UserContext userContext)
        {
            _userContext = userContext;
        }

        // GET: api/cars/all
        [HttpGet("all")]
        public IEnumerable<CapturedCar> GetAll()
        {
            IEnumerable<CapturedCar> capturedCars = from car in _userContext.Cars
                                                    join image in _userContext.Images on car.Id equals image.CarId
                                                    select CarFactory.GetInstance().CreateCapturedCar(car, image);
            return capturedCars.ToList();
        }

        // GET: api/cars/get?licenseplate={licensePlate}
        [HttpGet("get")]
        public IEnumerable<CapturedCar> GetByLicensePlate([FromQuery] string LicensePlate)
        {
            IEnumerable<CapturedCar> capturedCars = from car in _userContext.Cars
                           join image in _userContext.Images on car.Id equals image.CarId
                           where car.LicensePlate.Equals(LicensePlate)
                           orderby image.Timestamp descending
                           select CarFactory.GetInstance().CreateCapturedCar(car, image);

            return capturedCars.ToList();
        }

        // GET: api/cars/byuser?id={id}
        [HttpGet("byuser")]
        public IEnumerable<CapturedCar> Get([FromQuery] string id)
        {
            IEnumerable<CapturedCar> capturedCars = from car in _userContext.Cars
                                                    join image in _userContext.Images on car.Id equals image.CarId
                                                    where car.UserId == id
                                                    orderby image.Timestamp descending
                                                    select CarFactory.GetInstance().CreateCapturedCar(car, image);

            return capturedCars.ToList();
        }

        // POST: api/cars/add
        [AllowAnonymous]
        [HttpPost("add")]
        public void Add([FromBody] CapturedCar car)
        {
            _userContext.Cars.Add(car);
            _userContext.Images.Add(car.Image);
            _userContext.SaveChanges();
            Evaluation evaluation = Evaluation.Instance;
            User user = _userContext.Users.FirstOrDefault(o => o.ID == car.UserId.ToString());
            user.Score = evaluation.Evaluate(user, car.Status);
            _userContext.SaveChanges();
        }

        // DELETE: api/cars/remove?id={id}
        [HttpDelete("remove")]
        public void Remove([FromQuery] string id)
        {
            Car car = _userContext.Cars.FirstOrDefault(o => o.Id == id);
            if (car != null)
            {
                IEnumerable<Image> imgs = from image in _userContext.Images
                                          where car.Id == image.CarId
                                          select image;
                _userContext.Remove<Car>(car);
                foreach (var img in imgs.ToList())
                {
                    _userContext.Remove<Image>(img);
                }
            }
             _userContext.SaveChanges();
        }
    }
}
