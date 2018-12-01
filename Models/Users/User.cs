using System;

namespace Models.Users
{
	public class User : IComparable<User>
	{
		public int Id { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public int Score { get; set; } = 0;
        public Boosts Boosts { get; set; }

        public int CompareTo(User other)
        {
            return Score.CompareTo(other.Score);
        }
    }
}
