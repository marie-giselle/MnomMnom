using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Mnom_Mnom.Code;
using Mnom_Mnom.Models;

namespace Mnom_Mnom.Pages.Account
{
    public class RegisterModel : PageModel
    {
		private readonly Mnom_MnomContext _context;

		[BindProperty]
		public Register Register { get; set; }

		public RegisterModel(Mnom_MnomContext context)
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
				return Page();
			}
			User user = await _context.User
				.FirstOrDefaultAsync(u => u.Email == Register.Email || u.TelNumber != null && u.TelNumber == Register.TelNumber);
			if (user == null)
			{
				user = new User
				{
					Name = Register.Name,	//TODO Имя не записывается в базу?
					Email = Register.Email,
					Password = Register.Password,
					TelNumber = Register.TelNumber,
					RegistrationDate = DateTime.Today,
					Role = Role.User
				};

				_context.User.Add(user);
				await _context.SaveChangesAsync();
				await UserManager.Authenticate(user, HttpContext);
				return RedirectToPage("../Index");
			}
			else
			{
				ModelState.AddModelError("", "Такой Email или телефон уже используются");
				return Page();
			}
		}
	}
}