using Test_Task_Inforce.DTO;
using Test_Task_Inforce.Entity;

namespace Test_Task_Inforce.DAL
{
	public class ShortUrlDAL
	{
		public async Task<Result<List<ShortUrlDTO>>> GetAllShortUrls()
		{
			Result<List<ShortUrlDTO>> result = new Result<List<ShortUrlDTO>>();
			await using (AppDBContext appDBContext = new AppDBContext())
			{
				result.Data = appDBContext.ShortUrl.ToList();
			}
			return result;
		}

		public async Task<Result<ShortUrlDTO>> GetShortUrlById(int id)
		{
			Result<ShortUrlDTO> result = new Result<ShortUrlDTO>();
			await using (AppDBContext appDBContext = new AppDBContext())
			{
				result.Data = appDBContext.ShortUrl.Find(id);
			}
			return result;
		}
	}
}
