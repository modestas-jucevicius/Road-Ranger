using System;

namespace RoadRangerBackEnd.Users
{
    public class User : IComparable<User>
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public int score = 0;

        public User(string username, string password, string name)
        {
            this.Username = username;
            this.Password = password;
            this.Name = name;
        }

        public User(int id, string username, string password, string name, int score) : this(username, password, name)
        {
            this.Id = id;
            this.score = score;
        }

        public void IncreaseScore(int evaluation)
        {
            this.score += evaluation;
        }

        override public string ToString()
        {
            return this.Id + "," + this.Username + "," + this.Password + "," + this.Name + "," + this.score;
        }

        public int CompareTo(User other)
        {
            return this.score.CompareTo(other.score);
        }
    }
}
