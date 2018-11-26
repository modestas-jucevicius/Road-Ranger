using System;

namespace Models.Users
{
	public class User : IComparable<User>
	{
		public int Id { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public int Score { get; set; } = 0;
		public Boosts Boosts = new Boosts();

        public User(int id, string username, string password)
        {
			this.Id = id;
            this.Username = username;
            this.Password = password;
        }

        public void IncreaseScore(int evaluation)
        {
            this.Score += evaluation;
        }

        override public string ToString()
        {
            return this.Id + "," + this.Username + "," + this.Password + "," + this.Score + "," 
                + Boosts.boost30p + "," + Boosts.boost50p + "," + Boosts.boostDouble;
        }

        public int CompareTo(User other)
        {
            return this.Score.CompareTo(other.Score);
        }

		public void setBoost30p(Boolean boost30p)
		{
			this.Boosts.boost30p = boost30p;
		}

		public void setBoost50p(Boolean boost50p)
		{
			this.Boosts.boost50p = boost50p;
		}

		public void setBoostDouble(Boolean boostDouble)
		{
			this.Boosts.boostDouble = boostDouble;
		}

    }
}
