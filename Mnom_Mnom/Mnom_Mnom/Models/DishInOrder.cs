using System;
using System.Collections.Generic;

namespace Mnom_Mnom.Models
{
    public class DishInOrder
    {
        public int DishID { get; set; }
        public int OrderID { get; set; }
        public int Quantity { get; set; }
        public int UnitPrice { get; set; }
        public int Discount { get; set; }

        public Dish Dish { get; set; }
        public Order Order { get; set; }
    }
}
