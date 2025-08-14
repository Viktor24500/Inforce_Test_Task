using Test_Task_Inforce.BL;
using Test_Task_Inforce.Entity;

namespace UnitTests
{
	[TestClass]
	public sealed class LoginTests
	{
		private UserLogic _userLogic = new UserLogic();
		[TestInitialize]

		[TestMethod]
		public async Task Fail_Login_EmptyUserName()
		{
			LoginRequestParam loginRequest = new LoginRequestParam("", "aaaaaa");

			Result<LoginResponce> result = await _userLogic.Login(loginRequest);

			Assert.IsNotNull(result);
			Assert.AreEqual(1, result.ErrorCode);
			Assert.AreEqual("login or password can't be empty", result.ErrorMessage);
		}
	}
}
