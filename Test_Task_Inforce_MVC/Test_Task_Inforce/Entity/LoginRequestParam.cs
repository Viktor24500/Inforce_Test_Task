namespace Test_Task_Inforce.Entity
{
	public class LoginRequestParam
	{
		public LoginRequestParam(string userName, string userPassword)
		{
			UserName = userName;
			UserPassword = userPassword;
		}
		public string UserName { get; set; }
		public string UserPassword { get; set; }
	}
}
