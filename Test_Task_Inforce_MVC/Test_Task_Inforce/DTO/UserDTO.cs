using System.ComponentModel.DataAnnotations.Schema;

namespace Test_Task_Inforce.DTO
{
	public class UserDTO
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Password { get; set; }
		public string? Token { get; set; }

		public int RoleId { get; set; }
		[ForeignKey("RoleId")]
		public RoleDTO Role { get; set; }

		public ICollection<ShortUrlDTO> ShortUrls { get; set; }
	}
}
