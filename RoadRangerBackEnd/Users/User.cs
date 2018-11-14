using RoadRangerBackEnd.Score;
using System;

namespace RoadRangerBackEnd.Users
{
    public class User : IComparable<User>
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
        public Boosts boosts = new Boosts();

        public User(string username, string password, string name)
        {
            this.Username = username;
            this.Password = password;
            this.Name = name;
            this.Score = 0;
        }

        public User(int id, string username, string password, string name, int score) : this(username, password, name)
        {
            this.Id = id;
            this.Score = score;
        }

        public User(int id, string username, string password, string name, int score, Boolean boost30p, Boolean boost50p, Boolean boostDouble) : this(id, username, password, name, score)
        {
            this.boosts.boost30p = boost30p;
            this.boosts.boost50p = boost50p;
            this.boosts.boostDouble = boostDouble;
        }

        public void IncreaseScore(int evaluation)
        {
            this.Score += evaluation;
        }

        override public string ToString()
        {
            return this.Id + "," + this.Username + "," + this.Password + "," + this.Name + "," + this.Score + "," 
                + boosts.boost30p + "," + boosts.boost50p + "," + boosts.boostDouble;
        }

        public int CompareTo(User other)
        {
            return this.Score.CompareTo(other.Score);
        }
    }
}
