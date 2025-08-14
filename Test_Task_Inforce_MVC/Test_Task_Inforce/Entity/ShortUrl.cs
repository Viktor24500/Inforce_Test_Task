namespace Test_Task_Inforce.Entity
{
	public class ShortUrl
	{
		public ShortUrl(int shortUrlId, string mainUrl, string shortVariant, User user)
		{
			ShortUrlID = shortUrlId;
			MainUrl = mainUrl;
			ShortVariant = shortVariant;
			User = user;
		}
		public int ShortUrlID { get; set; }
		public string MainUrl { get; set; }

		public string ShortVariant { get; set; }

		public User User { get; set; }
	}
}
