namespace Mnom_Mnom.Models
{
	public class AdditionInCart
	{
		public int CartID { get; set; }
		public int DishID { get; set; }
		public int IngredientID { get; set; }
		public int Quantity { get; set; }

		public Cart Cart { get; set; }
		public Dish Dish { get; set; }
		public Ingredient Ingredient { get; set; }
	}
}
