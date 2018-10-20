
namespace Road_rangerVS.Users
{
    class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        private int score = 0;

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
      
        public int GetScore()
        {
            return score;
        }

        public void IncreaseScore(int evaluation)
        {
            this.score += evaluation;
        }
    }
}
