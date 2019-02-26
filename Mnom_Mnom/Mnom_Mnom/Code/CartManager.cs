using Microsoft.AspNetCore.Http;
using Mnom_Mnom.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Mnom_Mnom.Code
{
	public class CartWrapper
	{
		ISession session;
		private readonly Mnom_MnomContext _context;
		const string ingredientsError = "Дополнительные ингредиенты еще не реализованы.";

		public Cart Cart { get; }

		public CartWrapper(ISession session, Mnom_MnomContext context)
		{
			this.session = session;
			_context = context;
			if (SessionHelper.GetObjectFromJson<Cart>(session, "cart") == null)
			{
				Cart = new Cart();
				Cart.Dishes = new List<DishInCart>();
				Cart.Additions = new List<AdditionInCart>();
				SessionHelper.SetObjectAsJson(session, "cart", Cart);
			}
			else
			{
				Cart = SessionHelper.GetObjectFromJson<Cart>(session, "cart");
			}
		}

		void SaveCart() => SessionHelper.SetObjectAsJson(session, "cart", Cart);

		public void AddDish(int dishId)
		{
			int index = Cart.Dishes.FindIndex(s => s.DishID == dishId);
			if (index == -1)
			{
				Cart.Dishes.Add(
					new DishInCart
					{
						DishID = dishId,
						Dish = _context.Dishes.FirstOrDefault(s => s.DishID == dishId),
						Quantity = 1
					});
			}
			else
			{
				Cart.Dishes[index].Quantity++;				
			}
			SaveCart();
		}

		public void AddIngredient(int ingrId)
		{
			throw new NotImplementedException(ingredientsError);
		}

		public void AddQuantity(int dishId, int addCount = 1)
		{
			Cart.Dishes.First(s => s.DishID == dishId).Quantity+=addCount;
			SaveCart();
		}

		public void AddQuantity(int dishId, int ingredientId, int addCount = 1)
		{
			throw new NotImplementedException(ingredientsError);
		}

		public void ReduceQuantity(int dishId, int reduceCount = 1)
		{
			Cart.Dishes.First(s => s.DishID == dishId).Quantity -= reduceCount;
			SaveCart();
		}

		public void ReduceQuantity(int dishId, int ingredientId, int reduceCount = 1)
		{
			throw new NotImplementedException(ingredientsError);
		}

		public void MakeOrder()
		{

		}
	}
}
