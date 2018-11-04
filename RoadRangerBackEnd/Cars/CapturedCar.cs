using RoadRangerBackEnd.Images;

<<<<<<< HEAD:RoadRangerBackEnd/Cars/CapturedCar.cs
namespace RoadRangerBackEnd.Cars
=======
namespace Road_rangerVS.Cars
>>>>>>> 14143fd53e9df87f9d61baa2872c61231ac6452d:Road-rangerVS/Cars/CapturedCar.cs
{
    public class CapturedCar : Car
    {
        public Image Image { get; set; }
        public CapturedCar(Car car, Image image) : base(car)
        {
            this.Image = image;
        }
    }
}
