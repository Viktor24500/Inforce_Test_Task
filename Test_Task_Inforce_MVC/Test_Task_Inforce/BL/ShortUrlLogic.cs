using Test_Task_Inforce.DAL;
using Test_Task_Inforce.DTO;
using Test_Task_Inforce.Entity;

namespace Test_Task_Inforce.BL
{
	public class ShortUrlLogic
	{
		public async Task<Result<List<ShortUrl>>> GetAllShortUrls()
		{
			Result<List<ShortUrl>> result = new Result<List<ShortUrl>>();
			result.Data = new List<ShortUrl>();
			ShortUrlDAL shortUrlDAL = new ShortUrlDAL();
			Result<List<ShortUrlDTO>> resShortUrl = await shortUrlDAL.GetAllShortUrls();
			if (resShortUrl != null)
			{
				for (int i = 0; i < resShortUrl.Data.Count; i++)
				{
					ShortUrl shortUrl = new ShortUrl(resShortUrl.Data[i].Id, resShortUrl.Data[i].MainUrl,
						resShortUrl.Data[i].ShortUrl,
						new User(resShortUrl.Data[i].User.Id, resShortUrl.Data[i].User.Name, resShortUrl.Data[i].User.Password,
						resShortUrl.Data[i].User.Token, resShortUrl.Data[i].User.RoleId));
				}
			}
			return result;
		}

		public async Task<Result<List<ShortUrl>>> GetShortUrlById(int id)
		{
			Result<List<ShortUrl>> result = new Result<List<ShortUrl>>();
			result.Data = new List<ShortUrl>();
			if (int.IsNegative(id))
			{
				result.ErrorCode = 1;
				result.ErrorMessage = "id cna't be negative";
				return result;
			}
			ShortUrlDAL shortUrlDAL = new ShortUrlDAL();
			Result<ShortUrlDTO> resDTO = await shortUrlDAL.GetShortUrlById(id);
			if (resDTO.ErrorCode == 1)
			{
				result.ErrorCode = resDTO.ErrorCode;
				result.ErrorMessage = resDTO.ErrorMessage;
				return result;
			}
			result.Data.Add(new ShortUrl(resDTO.Data.Id, resDTO.Data.ShortUrl, resDTO.Data.MainUrl,
				new User(resDTO.Data.User.Id, resDTO.Data.User.Name, resDTO.Data.User.Password, resDTO.Data.User.Token, resDTO.Data.User.RoleId)));
			return result;
		}
	}
}
