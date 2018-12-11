namespace Models.Users
{
	public class User
	{
		public string ID { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public int Score { get; set; }
        public int BoostType { get; set; }
    }
}
