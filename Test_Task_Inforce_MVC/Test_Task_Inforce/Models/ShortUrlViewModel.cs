using Test_Task_Inforce.Entity;

namespace Test_Task_Inforce.Models
{
	public class ShortUrlViewModel : BaseViewModel
	{
		public ShortUrlViewModel(List<ShortUrl> shortUrls, string username, int roleId) : base(username, roleId)
		{
			ShortUrls = shortUrls;
		}

		public List<ShortUrl> ShortUrls { get; set; }
	}
}
