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
        public Boosts Boosts { get; set; }

        public User(string username, string password, string name)
        {
            this.Username = username;
            this.Password = password;
            this.Name = name;
            this.Score = 0;
            this.Boosts = new Boosts();
        }

        public User(int id, string username, string password, string name, int score) : this(username, password, name)
        {
            this.Id = id;
            this.Score = score;
        }

        public User(int id, string username, string password, string name, int score, Boolean boost30p, Boolean boost50p, Boolean boostDouble) : this(id, username, password, name, score)
        {
            this.Boosts.boost30p = boost30p;
            this.Boosts.boost50p = boost50p;
            this.Boosts.boostDouble = boostDouble;
        }

        public void IncreaseScore(int evaluation)
        {
            this.Score += evaluation;
        }

        override public string ToString()
        {
            return this.Id + "," + this.Username + "," + this.Password + "," + this.Name + "," + this.Score + "," 
                + Boosts.boost30p + "," + Boosts.boost50p + "," + Boosts.boostDouble;
        }

        public int CompareTo(User other)
        {
            return this.Score.CompareTo(other.Score);
        }
    }
}
