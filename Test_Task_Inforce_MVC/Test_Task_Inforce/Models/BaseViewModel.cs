namespace Test_Task_Inforce.Models
{
	public class BaseViewModel
	{
		public BaseViewModel(string username, int roleID)
		{
			UserName = username;
			RoleId = roleID;
		}
		public string UserName { get; set; }
		//public string Token { get; set; }

		public int RoleId { get; set; }
	}
}
