using System.ComponentModel.DataAnnotations;

namespace Models.Images
{
    public class Image
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int CarId { get; set; }
        public long Timestamp { get; set; }
        public string Path { get; set; }
    }
}
