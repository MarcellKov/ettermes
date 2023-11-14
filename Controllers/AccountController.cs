using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using System.Text.Encodings.Web;
using webapp.DataModels;
using webapp.DB;
using webapp.Email;
using webapp.Models;

namespace webapp.Controllers
{
	public class AccountController : Controller
	{
		private readonly UserManager<IdentityUser> _userManager;
		private readonly ILogger<AccountController> _logger;
		private readonly IEmailSenderService _emailSenderService;
		public AccountController(UserManager<IdentityUser> userManager, ILogger<AccountController> logger,IEmailSenderService email)
		{
			_emailSenderService = email;
			_userManager = userManager;
			_logger = logger;
			
		}
		
		public IActionResult Register()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Register(User u)
		{
			if (ModelState.IsValid)
			{
				var user=new IdentityUser { UserName=u.uname, Email=u.email};
				var res=await _userManager.CreateAsync(user, "Test_12345");
				
				if (res.Succeeded)
				{
					var token=await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    

                   var callbackurl= Url.Action("EmailConfirmation", "Account", new { id = user.Id, token = token });
                    await _emailSenderService.SendEmailAsync(u.email, "Registration", $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackurl)}'>clicking here</a>.");
                    return RedirectToAction("Index", "Home");
                }

                foreach (var item in res.Errors)
                {
					_logger.LogCritical(message: item.Description.ToString());
                }

                return RedirectToAction("Contact", "Home");
			}
			return View(u);
		}
		public async Task<IActionResult> EmailConfirmation(string id,string token)
		{
			var user = await _userManager.FindByIdAsync(id);
			if (user != null) {
				_logger.LogCritical("MEGVAN A USER");
				ViewData["result"] = "Succesfully confirmed email";
				await _userManager.ConfirmEmailAsync(user, token); }
			else
			{
				_logger.LogCritical("Nincs meg a user");
				ViewData["result"] = "Failed to confirm email";
				return RedirectToAction("Index", "Home");
			}

            return RedirectToAction("Index", "Home");
        }
	}

}
