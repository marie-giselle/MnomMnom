using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Mnom_Mnom.Models;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Mnom_Mnom.Code
{
	public class UserManager
	{
		public static async Task Authenticate(User user, HttpContext httpContext)
		{
			var claims = new List<Claim>
			{
				new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
				new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.ToString())
			};
			ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
				ClaimsIdentity.DefaultRoleClaimType);
			await httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
		}
	}
}
