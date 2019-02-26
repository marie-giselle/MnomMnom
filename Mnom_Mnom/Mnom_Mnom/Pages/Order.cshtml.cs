using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mnom_Mnom.Code;
using Mnom_Mnom.Models;

namespace Mnom_Mnom.Pages
{
    public class OrderModel : PageModel
    {
		Mnom_MnomContext _context;

		public Cart Cart;

		public OrderModel(Mnom_MnomContext context)
		{
			_context = context;
		}

        public void OnGet()
        {			
			Cart = new CartWrapper(HttpContext.Session, _context).Cart;
        }
    }
}