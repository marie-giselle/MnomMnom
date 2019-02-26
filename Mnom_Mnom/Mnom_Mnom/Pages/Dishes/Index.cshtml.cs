using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Mnom_Mnom.Code;
using Mnom_Mnom.Models;

namespace Mnom_Mnom.Pages.Dishes
{
    public class IndexModel : PageModel
    {
        private readonly Mnom_Mnom.Models.Mnom_MnomContext _context;

        public IndexModel(Mnom_Mnom.Models.Mnom_MnomContext context)
        {
            _context = context;
        }

        public IList<Dish> Dish { get;set; }

        public async Task OnGetAsync(int? type)
        {
			if (type.HasValue)
			{
				Dish = await _context.Dishes.Where(s => s.Type == (DishType)type).ToListAsync();
			}
			else
			{
				Dish = await _context.Dishes.ToListAsync();
			}
        }

		public IActionResult OnPostAddToCart(int id)
		{
			CartWrapper cartWrapper = new CartWrapper(HttpContext.Session, _context);
			cartWrapper.AddDish(id);
			return RedirectToAction("Index");
		}
	}
}
