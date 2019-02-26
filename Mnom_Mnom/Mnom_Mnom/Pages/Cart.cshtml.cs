using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mnom_Mnom.Code;
using Mnom_Mnom.Models;

namespace Mnom_Mnom.Pages
{
    public class CartModel : PageModel
	{
		private readonly Mnom_MnomContext _context;

		public CartModel(Mnom_MnomContext context)
		{
			_context = context;
		}

		public Cart Cart { get; set; }
		public int Total { get; set; }

		public void OnGet()
        {
			Cart = new CartWrapper(HttpContext.Session, _context).Cart;
			if (Cart.Dishes.Any())
			{
				Total = Cart.Dishes.Sum(item => item.Dish.Price * item.Quantity);
			}
			else
			{
				Total = 0;
			}
		}

		public IActionResult OnPostAddQuantity(int id)
		{
			CartWrapper wrapper = new CartWrapper(HttpContext.Session, _context);
			wrapper.AddQuantity(id);
			return RedirectToPage();
		}

		public IActionResult OnPostReduceQuantity(int id)
		{
			CartWrapper wrapper = new CartWrapper(HttpContext.Session, _context);
			wrapper.ReduceQuantity(id);
			return RedirectToPage();
		}

		public void OnPostMakeOrder()
		{

		}
	}
}