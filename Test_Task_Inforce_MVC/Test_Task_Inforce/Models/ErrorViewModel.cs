namespace Test_Task_Inforce.Models
{
	public class ErrorViewModel : BaseViewModel
	{
		public ErrorViewModel(int errorCode, string errorMessage, string username, int roleId) : base(username, roleId)
		{
			ErrorCode = errorCode;
			ErrorMessage = errorMessage;
		}
		public int ErrorCode { get; set; }
		public string? ErrorMessage { get; set; }
	}
}
