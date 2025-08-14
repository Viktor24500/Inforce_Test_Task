using Microsoft.AspNetCore.Mvc;
using System.Data;
using Test_Task_Inforce.BL;
using Test_Task_Inforce.Entity;
using Test_Task_Inforce.Models;

namespace Test_Task_Inforce.Controllers
{
	public class AboutController : Controller
	{
		private string _username = " ";
		private int _roleId = -1;

		[HttpGet]
		[Route("/about")]
		public IActionResult GetAboutForm()
		{
			return View("/Views/Form/EditAboutForm.cshtml");
		}

		[HttpGet]
		[Route("/aboutPage")]
		public async Task<IActionResult> GetAbout()
		{
			Result<string> tokenRes = GetTokenFromCookies();
			if (tokenRes.ErrorCode == 1)
			{
				ErrorViewModel errorViewModel = new ErrorViewModel(tokenRes.ErrorCode, tokenRes.ErrorMessage, _username, _roleId);
				return View("/Views/Shared/Error.cshtml", errorViewModel);
			}
			UserLogic userLogic = new UserLogic();
			Result<User> resultUser = await userLogic.GetUserByToken(tokenRes.Data);
			if (resultUser.ErrorCode == 1)
			{
				ErrorViewModel errorViewModel = new ErrorViewModel(resultUser.ErrorCode, resultUser.ErrorMessage, _username, _roleId);
				return View("/Views/Shared/Error.cshtml", errorViewModel);
			}

			Result<string> usernameRes = GetUsernameFromSession();
			if (usernameRes.ErrorCode == 1)
			{
				ErrorViewModel errorViewModel = new ErrorViewModel(usernameRes.ErrorCode, usernameRes.ErrorMessage, _username, _roleId);
				return View("/Views/Shared/Error.cshtml", errorViewModel);
			}
			Result<int> roleIdRes = GetRoleIdFromSession();
			if (roleIdRes.ErrorCode == 1)
			{
				ErrorViewModel errorViewModel = new ErrorViewModel(roleIdRes.ErrorCode, roleIdRes.ErrorMessage, _username, _roleId);
				return View("/Views/Shared/Error.cshtml", errorViewModel);
			}
			AboutLogic about = new AboutLogic();
			Result<string> resDescription = await about.GetAbout();
			if (resDescription.ErrorCode == 1)
			{
				ErrorViewModel errorViewModel = new ErrorViewModel(resDescription.ErrorCode, resDescription.ErrorMessage, _username, _roleId);
				return View("/Views/Shared/Error.cshtml", errorViewModel);
			}
			AboutViewModel model = new AboutViewModel(resDescription.Data, usernameRes.Data, roleIdRes.Data);
			return View("/Views/About.cshtml", model);
		}
		[HttpPut]
		[Route("/about")]
		public async Task<IActionResult> EditAbout([FromBody] Description description)
		{
			Result<string> tokenRes = GetTokenFromCookies();
			if (tokenRes.ErrorCode == 1)
			{
				ErrorViewModel errorViewModel = new ErrorViewModel(tokenRes.ErrorCode, tokenRes.ErrorMessage, _username, _roleId);
				return View("/Views/Shared/Error.cshtml", errorViewModel);
			}
			UserLogic userLogic = new UserLogic();
			Result<User> resultUser = await userLogic.GetUserByToken(tokenRes.Data);
			if (resultUser.ErrorCode == 1)
			{
				ErrorViewModel errorViewModel = new ErrorViewModel(resultUser.ErrorCode, resultUser.ErrorMessage, _username, _roleId);
				return View("/Views/Shared/Error.cshtml", errorViewModel);
			}
			Result<string> usernameRes = GetUsernameFromSession();
			if (usernameRes.ErrorCode == 1)
			{
				ErrorViewModel errorViewModel = new ErrorViewModel(usernameRes.ErrorCode, usernameRes.ErrorMessage, _username, _roleId);
				return View("/Views/Shared/Error.cshtml", errorViewModel);
			}
			Result<int> roleIdRes = GetRoleIdFromSession();
			if (roleIdRes.ErrorCode == 1)
			{
				ErrorViewModel errorViewModel = new ErrorViewModel(roleIdRes.ErrorCode, roleIdRes.ErrorMessage, _username, _roleId);
				return View("/Views/Shared/Error.cshtml", errorViewModel);
			}
			AboutLogic about = new AboutLogic();
			Result<string> resDescription = await about.EditAbout(description);
			if (resDescription.ErrorCode == 1)
			{
				ErrorViewModel errorViewModel = new ErrorViewModel(resDescription.ErrorCode, resDescription.ErrorMessage, _username, _roleId);
				return View("/Views/Shared/Error.cshtml", errorViewModel);
			}
			AboutViewModel model = new AboutViewModel(resDescription.Data, usernameRes.Data, roleIdRes.Data);
			return View("/Views/About.cshtml", model);
		}
		private Result<string> GetTokenFromCookies()
		{
			Result<string> result = new Result<string>();
			if (!HttpContext.Request.Cookies.TryGetValue("token", out string token))
			{
				result.ErrorMessage = "Authentication token is missing";
				result.ErrorCode = 1;
			}
			result.Data = token;
			return result;
		}
		private Result<string> GetUsernameFromSession()
		{
			Result<string> result = new Result<string>();
			string? username = HttpContext.Session.GetString("Username");
			if (string.IsNullOrEmpty(username))
			{
				result.ErrorMessage = "Can't get username from session";
				result.ErrorCode = 1;
			}
			else
			{
				result.Data = username;
			}
			return result;
		}
		private Result<int> GetRoleIdFromSession()
		{
			Result<int> result = new Result<int>();
			int? roleId = HttpContext.Session.GetInt32("RoleId");
			if (!roleId.HasValue)
			{
				result.ErrorMessage = "Can't get roleId from session";
				result.ErrorCode = 1;
			}
			else
			{
				result.Data = roleId.Value;
			}
			return result;
		}
	}
}
