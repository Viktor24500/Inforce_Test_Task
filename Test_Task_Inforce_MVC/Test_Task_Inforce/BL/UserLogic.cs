using System.Security.Cryptography;
using System.Text;
using Test_Task_Inforce.DAL;
using Test_Task_Inforce.DTO;
using Test_Task_Inforce.Entity;

namespace Test_Task_Inforce.BL
{
	public class UserLogic
	{
		public async Task<Result<LoginResponce>> Login(LoginRequestParam loginRequest)
		{
			Result<LoginResponce> result = new Result<LoginResponce>();
			if (string.IsNullOrEmpty(loginRequest.UserName) || string.IsNullOrEmpty(loginRequest.UserPassword))
			{
				result.ErrorCode = 1;
				result.ErrorMessage = "login or password can't be empty";
				return result;
			}

			//get user from db
			UserDAL userDAL = new UserDAL();
			Result<UserDTO> DBResult = await userDAL.GetUserByUserName(loginRequest.UserName);
			if (DBResult.Data == null)
			{
				result.ErrorCode = 1;
				result.ErrorMessage = "user not found";
				return result;
			}

			string hashedPassword = HashPassword(loginRequest.UserPassword);
			if (DBResult.Data.Password != hashedPassword)
			{
				result.ErrorCode = 1;
				result.ErrorMessage = "invalid login or password";
				return result;
			}

			string token = Guid.NewGuid().ToString();

			//update token
			Result updateResult = await userDAL.UpdateUser(loginRequest.UserName, token);
			if (updateResult.ErrorCode == 1)
			{
				result.ErrorCode = updateResult.ErrorCode;
				result.ErrorMessage = updateResult.ErrorMessage;
				return result;
			}
			result.ErrorCode = 0;
			result.Data = new LoginResponce(DBResult.Data.Id, token, DBResult.Data.Name, DBResult.Data.RoleId);
			return result;
		}

		public async Task<Result<User>> GetUserByToken(string token)
		{
			Result<User> result = new Result<User>();
			if (string.IsNullOrEmpty(token))
			{
				result.ErrorCode = 1;
				result.ErrorMessage = "token can't be empty";
				return result;
			}
			UserDAL userDAL = new UserDAL();
			Result<UserDTO> DBResult = await userDAL.GetUserByToken(token);
			if (DBResult.Data == null)
			{
				result.ErrorCode = 1;
				result.ErrorMessage = "user not found";
				return result;
			}
			User user = new User(DBResult.Data.Id, DBResult.Data.Name, DBResult.Data.Password, DBResult.Data.Token, DBResult.Data.Id);
			result.Data = user;
			return result;
		}

		private string HashPassword(string password)
		{
			string hashedPassword;
			//Hash password 
			using (SHA256 sha256Hash = SHA256.Create())
			{
				// Convert the password to a byte array
				byte[] bytes = Encoding.UTF8.GetBytes(password);

				// Compute the hash
				byte[] hashBytes = sha256Hash.ComputeHash(bytes);

				// Convert the byte array to a hexadecimal string
				StringBuilder sb = new StringBuilder();
				foreach (byte b in hashBytes)
				{
					sb.Append(b.ToString("x2")); // Converts byte to hexadecimal string
				}
				hashedPassword = sb.ToString();
			}
			return hashedPassword;
		}
	}
}
