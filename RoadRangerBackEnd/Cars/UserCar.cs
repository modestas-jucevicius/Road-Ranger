using RoadRangerBackEnd.OutsideAPI;

namespace RoadRangerBackEnd.Cars
{
    public class UserCar
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string LicensePlate { get; set; }    // automobilio registracijos numeris
        public CarStatus Status { get; set; }
        public long Timestamp { get; set; }

        public UserCar(string licensePlate, CarStatus status, long timestamp)
        {
            this.LicensePlate = licensePlate;
            this.Status = status;
            this.Timestamp = timestamp;
        }

        public UserCar(int id, int userId, string licensePlate,
            CarStatus status, long timestamp) : this(licensePlate, status, timestamp)
        {
            this.Id = id;
            this.UserId = userId;
        }
    }
}
