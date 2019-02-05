using System;
using System.Collections.Generic;

namespace Mnom_Mnom.Models
{
    public class AdditionalIngredients
    {
        public int IngredientID { get; set; }
        public int DishID { get; set; }
        public int Max { get; set; }
        public bool Available { get; set; }

        public Ingredient Ingredient { get; set; }
        public Dish Dish { get; set; }
    }
}
