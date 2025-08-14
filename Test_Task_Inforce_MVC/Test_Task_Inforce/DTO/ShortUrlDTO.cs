using System.ComponentModel.DataAnnotations.Schema;

namespace Test_Task_Inforce.DTO
{
	public class ShortUrlDTO
	{
		public int Id { get; set; }
		public string MainUrl { get; set; }

		public string ShortUrl { get; set; }


		public int CreatedBy { get; set; }
		[ForeignKey("CreatedBy")]
		public UserDTO User { get; set; }
	}
}
