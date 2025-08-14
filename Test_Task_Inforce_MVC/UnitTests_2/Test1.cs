using Microsoft.Testing.Platform.Configurations;
using Test_Task_Inforce.BL;

namespace UnitTests_2
{
	[TestClass]
	public sealed class Test1
	{
		private UserLogic _userLogic;
		[TestInitialize]
		public void Setup()
		{
			// Dependencies that are not actively tested here can be mocked/null for simplicity
			Mock<IConfiguration> _mockConfiguration = new Mock<IConfiguration>();
			Dictionary<string, string> inMemorySettings = new Dictionary<string, string>();
			inMemorySettings.Add("DefaultConnection", "Server=localhost\\SQLEXPRESS;Database=TestTaskShortener;Trusted_Connection=True;MultipleActiveResultSets=true");

			_mockConfiguration.Setup(c => c["DefaultConnection"])
							  .Returns(inMemorySettings["DefaultConnection"]);

			_userLogic = new UserLogic(
				_mockConfiguration.Object);
		}
		[TestMethod]
		public void Success_Login()
		{
		}

		[TestMethod]
		public async Task Fail_Login_EmptyUserName()
		{
			LoginRequest loginRequest = new LoginRequest("", "aaaaaa");

			Result<LoginResponce> result = await _userLogic.Login(loginRequest);

			Assert.IsNotNull(result);
			Assert.AreEqual(1, result.ErrorCode);
			Assert.AreEqual("login or password can't be empty", result.ErrorMessage);
		}
	}
}
}
