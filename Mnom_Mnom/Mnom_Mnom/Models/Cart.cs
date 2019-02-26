using System;
using System.Collections.Generic;

namespace Mnom_Mnom.Models
{
	public class Cart
	{
		public int CartID { get; set; }
		public DateTime CreateDate { get; set; }
		public int UserID { get; set; }
		public int PaymentMethodID { get; set; }
		public int AddressID { get; set; }

		public User User { get; set; }
		public PaymentMethod PaymentMethod { get; set; }
		public Address Address { get; set; }

		public List<DishInCart> Dishes { get; set; }
		public List<AdditionInCart> Additions { get; set; }
	}
}
