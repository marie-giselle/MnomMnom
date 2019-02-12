using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Mnom_Mnom.Code;
using Mnom_Mnom.Models;

namespace Mnom_Mnom.Pages.Account
{
    public class LoginModel : PageModel
    {
		private readonly Mnom_MnomContext _context;

		[BindProperty]
		public Login Login { get; set; }

		public LoginModel(Mnom_MnomContext context)
		{
			_context = context;
		}

		public IActionResult OnGet()
		{
			return Page();
		}

		public async Task<IActionResult> OnPost()
		{
			if (!ModelState.IsValid)
			{
				ModelState.AddModelError("", "Некорректные логин и/или пароль.");
				return Page();
			}
			User user = await _context.User
				.FirstOrDefaultAsync(u => (u.Email == Login.UserKey || u.TelNumber == Login.UserKey) && u.Password == Login.Password);
			if (user != null)
			{
				await UserManager.Authenticate(user, HttpContext);
				RedirectToPage("Index");
			}
			return RedirectToPage("../Index");
		}
	}
}