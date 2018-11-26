using System.ComponentModel.DataAnnotations;

namespace Models.Cars
{
    public class Car
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public string LicensePlate { get; set; }    
        public string ColorName { get; set; }    
        public string MakeName { get; set; }       
        public string Model { get; set; }          
        public string BodyType { get; set; }        
        public string Year { get; set; }
        [Required]
        public CarStatus Status { get; set; }
        public bool IsReported {get; set;}
    }
}
