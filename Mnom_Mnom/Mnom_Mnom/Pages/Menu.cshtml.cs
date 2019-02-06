using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mnom_Mnom.Models;

namespace Mnom_Mnom.Pages
{
    public class MenuModel : PageModel
    {
        public void OnGet()
        {
			MenuSections = new List<Tuple<int,string, string>>();
			foreach (DishType type in Enum.GetValues(typeof(DishType)))
			{
				string path = $"/images/Menu/{type.ToString()}.jpg";
				MenuSections.Add(new Tuple<int, string, string> ((int)type,type.ToString(), path));
			}
		}

		public List<Tuple<int,string, string>> MenuSections { get; set; }
    }
}