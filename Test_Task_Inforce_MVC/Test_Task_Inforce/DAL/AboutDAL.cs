using Test_Task_Inforce.Entity;

namespace Test_Task_Inforce.DAL
{
	public class AboutDAL
	{
		private const string _connectionString = "Server=localhost\\SQLEXPRESS;Database=TestTaskShortener;Trusted_Connection=True;MultipleActiveResultSets=true";
		public async Task<Result> EditAbout(Description description)
		{
			Result result = new Result();
			//await using (SqlConnection connection = new SqlConnection(_connectionString))
			//{
			//	connection.Open();

			//	SqlCommand command = new SqlCommand("UPDATE AboutDescriptionTable SET AboutDescription=@newDescription WHERE AboutDescription=@oldDescription", connection);
			//	command.CommandType = System.Data.CommandType.Text;
			//	command.Parameters.AddWithValue("newDescription", description.newDescription);
			//	command.Parameters.AddWithValue("oldDescription", description.oldDescription);

			//	await using (SqlDataReader reader = command.ExecuteReader())
			//	{
			//		if (command.ExecuteNonQuery() <= 0)
			//		{
			//			result.ErrorCode = 1;
			//			result.ErrorMessage = "oops";
			//		}
			//	}
			//}
			await using (AppDBContext dbContext = new AppDBContext())
			{
				var descriptionOld = dbContext.Description.FirstOrDefault(d => d.oldDescription == description.oldDescription);
				if (descriptionOld != null)
				{
					descriptionOld.oldDescription = descriptionOld.newDescription;
					descriptionOld.newDescription = description.newDescription;
					dbContext.SaveChanges();
				}
			}
			return result;

		}

		//public async Task<Result<string>> GetAboutDescription()
		//{
		//	Result<string> result = new Result<string>();
		//	await using (SqlConnection connection = new SqlConnection(_connectionString))
		//	{
		//		connection.Open();

		//		SqlCommand command = new SqlCommand("SELECT AboutDescription FROM AboutDescriptionTable", connection);
		//		command.CommandType = System.Data.CommandType.Text;
		//		//command.Parameters.AddWithValue("newDescription", newDescription);

		//		await using (SqlDataReader reader = command.ExecuteReader())
		//		{
		//			while (reader.Read())
		//			{
		//				result.Data = reader.GetString(reader.GetOrdinal("AboutDescription"));
		//			}
		//		}
		//	}
		//	return result;
		//}

		public async Task<Result<string>> GetAboutDescription()
		{
			Result<string> result = new Result<string>();
			await using (AppDBContext dbContext = new AppDBContext())
			{
				var description = dbContext.Description.FirstOrDefault();
				if (description == null)
				{
					result.ErrorCode = 1;
					result.ErrorMessage = "oops";
					return result;
				}
				result.Data = description.newDescription;
				return result;
			}
		}
	}
}
