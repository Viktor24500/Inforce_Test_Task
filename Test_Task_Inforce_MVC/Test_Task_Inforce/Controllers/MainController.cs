using Microsoft.AspNetCore.Mvc;
using Test_Task_Inforce.BL;
using Test_Task_Inforce.Entity;
using Test_Task_Inforce.Models;

namespace Test_Task_Inforce.Controllers
{
	public class MainController : Controller
	{
		private string _username = " ";
		private int _roleId = -1;
		[HttpGet]
		[Route("/login")]
		public IActionResult GetLoginForm()
		{
			return View("/Views/Form/Login.cshtml");
		}

		[HttpPost]
		[Route("/login")]
		public async Task<IActionResult> Login(string userName, string userPassword)
		{
			HttpContext.Response.Cookies.Delete("token");
			LoginRequestParam loginRequest = new LoginRequestParam(userName, userPassword);
			UserLogic userLogic = new UserLogic();
			Result<LoginResponce> result = await userLogic.Login(loginRequest);
			if (result.ErrorCode == 0)
			{
				ErrorViewModel errorViewModel = new ErrorViewModel(result.ErrorCode, result.ErrorMessage, _username, _roleId);
				return View("/Views/Shared/Error.cshtml", errorViewModel);
			}
			BaseViewModel model = new BaseViewModel(result.Data.UserName, result.Data.RoleId);
			HttpContext.Session.SetString("Username", result.Data.UserName);
			HttpContext.Session.SetInt32("RoleId", result.Data.RoleId);
			HttpContext.Response.Cookies.Append("token", result.Data.Token);

			return View(model);
		}
	}
}
