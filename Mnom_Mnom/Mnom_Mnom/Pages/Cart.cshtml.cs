using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Mnom_Mnom.Code;
using Mnom_Mnom.Models;

namespace Mnom_Mnom.Pages
{
    public class CartModel : PageModel
	{
		private readonly Mnom_Mnom.Models.Mnom_MnomContext _context;

		public CartModel(Mnom_Mnom.Models.Mnom_MnomContext context)
		{
			_context = context;
		}

		public IList<DishInCart> DishesInCart { get; set; }
		public int Total { get; set; }

		public void OnGet()
        {
			var cart = SessionHelper.GetObjectFromJson<List<DishInCart>>(HttpContext.Session, "cart");
			if (cart != null)
			{
				DishesInCart = cart;
				Total = cart.Sum(item => item.Dish.Price * item.Quantity);
			}
			else
			{
				Total = 0;
			}
		}

		public void OnGetAddQuantity(int id)
		{

		}

		public void OnGetReduceQuantity(int id)
		{

		}
	}
}