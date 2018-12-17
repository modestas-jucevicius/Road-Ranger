using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Xamarin.Forms.Maps;

namespace Models.Images
{
    public class Image
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string CarId { get; set; }
        public long Timestamp { get; set; }
        public string Path { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }

        [NotMapped]
        public Position Position {
            get
            {
                return new Position(this.Latitude, this.Longitude);
            }
            set
            {
                Latitude = value.Latitude;
                Longitude = value.Longitude;
            }
        }
    }
}
