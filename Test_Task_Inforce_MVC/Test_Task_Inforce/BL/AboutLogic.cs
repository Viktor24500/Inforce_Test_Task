using Test_Task_Inforce.DAL;
using Test_Task_Inforce.Entity;

namespace Test_Task_Inforce.BL
{
	public class AboutLogic
	{
		public async Task<Result<string>> EditAbout(Description description)
		{
			Result<string> result = new Result<string>();
			AboutDAL aboutDAL = new AboutDAL();
			Result DBResult = await aboutDAL.EditAbout(description);
			if (DBResult.ErrorCode == 1)
			{
				result.ErrorCode = 1;
				result.ErrorMessage = "oops";
				return result;
			}
			Result<string> resNewDescription = await aboutDAL.GetAboutDescription();
			if (resNewDescription.ErrorCode == 1)
			{
				result.ErrorCode = 1;
				result.ErrorMessage = "oops";
				return result;
			}
			result.Data = resNewDescription.Data;
			return result;
		}

		public async Task<Result<string>> GetAbout()
		{
			Result<string> result = new Result<string>();
			AboutDAL aboutDAL = new AboutDAL();
			Result<string> resDescription = await aboutDAL.GetAboutDescription();
			if (resDescription.ErrorCode == 1)
			{
				result.ErrorCode = 1;
				result.ErrorMessage = "oops";
				return result;
			}
			result.Data = resDescription.Data;
			return result;
		}
	}
}
