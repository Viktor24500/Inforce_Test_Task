namespace Test_Task_Inforce.Models
{
	public class AboutViewModel : BaseViewModel
	{
		public AboutViewModel(string description, string username, int roleID) : base(username, roleID)
		{
			Description = description;
		}
		public string Description { get; set; }
	}
}
