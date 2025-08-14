namespace Test_Task_Inforce.Entity
{
	public class User
	{
		public User(int id, string name, string password, string? token, int roleID)
		{
			Id = id;
			Name = name;
			Password = password;
			Token = token;
			RoleID = roleID;
		}
		public int Id { get; set; }
		public string Name { get; set; }
		public string Password { get; set; }
		public string? Token { get; set; }

		public int RoleID { get; set; }

	}
}
