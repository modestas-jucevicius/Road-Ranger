using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
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

		public User ShallowCopy()
		{
			return (User)this.MemberwiseClone();
		}
	}
}
