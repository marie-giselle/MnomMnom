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
			if (SessionHelper.GetObjectFromJson<List<DishInCart>>(HttpContext.Session, "cart") == null)
			{
				List<DishInCart> cart = new List<DishInCart>
				{
					new DishInCart
					{
						DishID = id,
						Dish = _context.Dishes.FirstOrDefault(s => s.DishID == id),
						Quantity = 1
					}
				};
				SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
			}
			else
			{
				List<DishInCart> cart = SessionHelper.GetObjectFromJson<List<DishInCart>>(HttpContext.Session, "cart");
				int index = cart.FindIndex(s => s.DishID == id);
				if(index != -1)
				{
					cart[index].Quantity++;
				}
				else
				{
					cart.Add(new DishInCart
					{
						DishID = id,
						Dish = _context.Dishes.FirstOrDefault(s => s.DishID == id),
						Quantity = 1
					});
				}
				SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
			}
			return RedirectToAction("Index");
		}
	}
}
