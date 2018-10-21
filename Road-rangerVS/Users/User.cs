
namespace Road_rangerVS.Users
{
    class User
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public int score = 0;

        public User(string username, string password, string name)
        {
            this.username = username;
            this.password = password;
            this.name = name;
        }

        public User(int id, string username, string password, string name, int score) : this(username, password, name)
        {
            this.id = id;
            this.score = score;
        }

        public void IncreaseScore(int evaluation)
        {
            this.score += evaluation;
        }

        override public string ToString()
        {
            return this.id + "," + this.username + "," + this.password + "," + this.name + "," + this.score;
        }
    }
}
