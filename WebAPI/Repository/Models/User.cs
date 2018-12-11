using System.ComponentModel.DataAnnotations;

namespace WebAPI.Repository.Models
{
	public class User
	{
		[Required]
		public string ID { get; set; }

		[Required]
		public string Username { get; set; }

		[Required]
		public string Password { get; set; }

		[Required]
		public string Salt { get; set; }

		[Required]
		public int Score { get; set; }
        public int BoostType { get; set; }
    }
}
