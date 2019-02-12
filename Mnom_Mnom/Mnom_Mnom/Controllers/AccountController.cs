using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mnom_Mnom.Models;

namespace Mnom_Mnom.Controllers
{
    public class AccountController : Controller
    {
		private readonly Mnom_MnomContext _context;
		public AccountController(Mnom_MnomContext context)
		{
			_context = context;
		}

		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Register (Register model)
		{
			if (ModelState.IsValid)
			{
				User user = await _context.User
					.FirstOrDefaultAsync(u => u.Email == model.Email || u.TelNumber != null && u.TelNumber == model.TelNumber);
				if (user == null)
				{
					user = new User {
						Name = model.Name,
						Email = model.Email,
						Password = model.Password,
						TelNumber = model.TelNumber,
						RegistrationDate = DateTime.Today,
						Role = Role.User
					};

					_context.User.Add(user);
					await _context.SaveChangesAsync();
					await Authenticate(user);
					return RedirectToPage("Index");
				}
				else
				{
					ModelState.AddModelError("", "Такой Email или телефон уже используются");
				}
			}
			return View(model);
		}

		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Login(Login model)
		{
			if (ModelState.IsValid)
			{
				User user = await _context.User
					.FirstOrDefaultAsync(u => (u.Email == model.UserKey || u.TelNumber == model.UserKey) && u.Password == model.Password);
				if(user != null)
				{
					await Authenticate(user);
					return RedirectToPage("Index");
				}
				ModelState.AddModelError("", "Некорректные логин и/или пароль.");
			}
			return View(model);
		}

		public async Task Authenticate(User user)
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