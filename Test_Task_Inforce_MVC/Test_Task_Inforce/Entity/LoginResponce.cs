namespace Test_Task_Inforce.Entity
{
	public class LoginResponce
	{
		public LoginResponce(int userId, string token, string userName, int roleId)
		{
			UserId = userId;
			Token = token;
			UserName = userName;
			RoleId = roleId;
		}
		public int UserId { get; set; }
		public string UserName { get; set; }
		public int RoleId { get; set; }
		public string Token { get; set; }
	}
}
