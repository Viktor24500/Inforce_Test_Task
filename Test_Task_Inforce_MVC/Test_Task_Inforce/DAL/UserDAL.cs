using Test_Task_Inforce.DTO;
using Test_Task_Inforce.Entity;

namespace Test_Task_Inforce.DAL
{
	public class UserDAL
	{
		private const string _connectionString = "Server=localhost\\SQLEXPRESS;Database=TestTaskShortener;Trusted_Connection=True;MultipleActiveResultSets=true";

		//public UserDAL(IConfiguration configuration)
		//{
		//	_connectionString = configuration.GetConnectionString("DefaultConnection");
		//}

		public virtual async Task<Result<UserDTO>> GetUserByUserName(string username)
		{
			Result<UserDTO> DBResult = new Result<UserDTO>();
			//await using (SqlConnection connection = new SqlConnection(_connectionString))
			//{
			//	connection.Open();

			//	SqlCommand command = new SqlCommand("SELECT UserId, UserName, UserPassword, Token, RoleId" +
			//		"FROM Users" +
			//		"JOIN UserRoles ON Users.UserId=UserRoles.UserId" +
			//		"Where UserName=@username", connection);
			//	command.CommandType = System.Data.CommandType.Text;
			//	command.Parameters.AddWithValue("username", username);

			//	await using (SqlDataReader reader = command.ExecuteReader())
			//	{
			//		while (reader.Read())
			//		{
			//			DBResult.Data = new User(
			//			reader.GetInt32(reader.GetOrdinal("UserId")),
			//			reader.GetString(reader.GetOrdinal("UserName")),
			//			reader.GetString(reader.GetOrdinal("UserPassword")),
			//			reader.GetString(reader.GetOrdinal("Token")),
			//			reader.GetInt32(reader.GetOrdinal("RoleId"))
			//				);
			//		}
			//	}
			//}
			await using (AppDBContext dbContext = new AppDBContext())
			{
				UserDTO? userDTO = dbContext.User.FirstOrDefault<UserDTO>(u => u.Name == username);
				if (userDTO == null)
				{
					DBResult.ErrorCode = 1;
					DBResult.ErrorMessage = "user not found";
					return DBResult;
				}
				RoleDTO? roleDTO = dbContext.Role.FirstOrDefault<RoleDTO>(r => r.Id == userDTO.Id);
				if (roleDTO == null)
				{
					DBResult.ErrorCode = 1;
					DBResult.ErrorMessage = "user not found";
					return DBResult;
				}
			}
			return DBResult;
		}
		public virtual async Task<Result> UpdateUser(string username, string token)
		{
			Result result = new Result();
			//update token
			//await using (SqlConnection connection = new SqlConnection(_connectionString))
			//{
			//	connection.Open();

			//	SqlCommand command = new SqlCommand("UPDATE Users SET Token=@token Where UserId=@username", connection);
			//	command.CommandType = System.Data.CommandType.Text;
			//	command.Parameters.AddWithValue("username", userName);
			//	command.Parameters.AddWithValue("token", token);

			//	if (command.ExecuteNonQuery() <= 0)
			//	{
			//		result.ErrorCode = 1;
			//		result.ErrorMessage = "oops";
			//	}
			//}
			await using (AppDBContext dbContext = new AppDBContext())
			{
				UserDTO? userDTO = dbContext.User.FirstOrDefault<UserDTO>(u => u.Name == username);
				if (userDTO == null)
				{
					result.ErrorCode = 1;
					result.ErrorMessage = "user not found";
					return result;
				}
				userDTO.Token = token;
				dbContext.SaveChanges();
			}
			return result;
		}

		public virtual async Task<Result<UserDTO>> GetUserByToken(string token)
		{
			Result<UserDTO> DBResult = new Result<UserDTO>();
			//await using (SqlConnection connection = new SqlConnection(_connectionString))
			//{
			//	connection.Open();

			//	SqlCommand command = new SqlCommand("SELECT UserId, UserName, UserPassword, Token, RoleId" +
			//		"FROM Users" +
			//		"JOIN UserRoles ON Users.UserId=UserRoles.UserId" +
			//		"Where Token=@token", connection);
			//	command.CommandType = System.Data.CommandType.Text;
			//	command.Parameters.AddWithValue("token", token);

			//	await using (SqlDataReader reader = command.ExecuteReader())
			//	{
			//		while (reader.Read())
			//		{
			//			DBResult.Data = new User(
			//			reader.GetInt32(reader.GetOrdinal("UserId")),
			//			reader.GetString(reader.GetOrdinal("UserName")),
			//			reader.GetString(reader.GetOrdinal("UserPassword")),
			//			reader.GetString(reader.GetOrdinal("Token")),
			//			reader.GetInt32(reader.GetOrdinal("RoleId"))
			//				);
			//		}
			//	}
			//}
			await using (AppDBContext dbContext = new AppDBContext())
			{
				UserDTO? userDTO = dbContext.User.FirstOrDefault<UserDTO>(u => u.Token == token);
				if (userDTO == null)
				{
					DBResult.ErrorCode = 1;
					DBResult.ErrorMessage = "user not found";
					return DBResult;
				}
				RoleDTO? roleDTO = dbContext.Role.FirstOrDefault<RoleDTO>(r => r.Id == userDTO.Id);
				if (roleDTO == null)
				{
					DBResult.ErrorCode = 1;
					DBResult.ErrorMessage = "user not found";
					return DBResult;
				}
			}
			return DBResult;
		}
	}
}
