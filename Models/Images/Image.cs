using System.ComponentModel.DataAnnotations;

namespace Models.Images
{
    public class Image
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int CarId { get; set; }
        [Required]
        public long Timestamp { get; set; }
        public string Path { get; set; }
        public byte[] Picture { get; set; }
    }
}
