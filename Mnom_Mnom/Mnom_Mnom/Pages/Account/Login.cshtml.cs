using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Mnom_Mnom.Models;

namespace Mnom_Mnom.Pages.Account
{
    public class LoginModel : PageModel
    {
		private readonly Mnom_MnomContext _context;

		public LoginModel(Mnom_MnomContext context)
		{
			_context = context;
		}

		public void OnGet()
        { }

		public async void OnPost(Login model)
		{
			if (ModelState.IsValid)
			{
				User user = await _context.User
					.FirstOrDefaultAsync(u => (u.Email == model.UserKey || u.TelNumber == model.UserKey) && u.Password == model.Password);
				if (user != null)
				{
					await Authenticate(user);
					RedirectToPage("Index");
				}
				ModelState.AddModelError("", "Некорректные логин и/или пароль.");
			}
		}

		private async Task Authenticate(User user)
		{
			var claims = new List<Claim>
			{
				new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
				new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.ToString())
			};
			ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
				ClaimsIdentity.DefaultRoleClaimType);
			await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
		}
	}
}