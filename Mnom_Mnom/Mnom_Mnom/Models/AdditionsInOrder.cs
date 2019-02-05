using System;
using System.Collections.Generic;

namespace Mnom_Mnom.Models
{
    public class AdditionsInOrder
    {
        public int IngredientID { get; set; }
        public int DishID { get; set; }
        public int OrderID { get; set; }
        public int Quantity { get; set; }

        public Ingredient Ingredient { get; set; }
        public Dish Dish { get; set; }
        public Order Order { get; set; }
    }
}
