using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Mnom_Mnom.Models;

namespace Mnom_Mnom.Pages.Dishes
{
    public class DetailsModel : PageModel
    {
        private readonly Mnom_Mnom.Models.Mnom_MnomContext _context;

        public DetailsModel(Mnom_Mnom.Models.Mnom_MnomContext context)
        {
            _context = context;
        }

        public Dish Dish { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Dish = await _context.Dish.FirstOrDefaultAsync(m => m.DishID == id);

            if (Dish == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
