using Microsoft.EntityFrameworkCore;

namespace Mnom_Mnom.Models
{
    public class Mnom_MnomContext : DbContext
    {
        public Mnom_MnomContext (DbContextOptions<Mnom_MnomContext> options)
            : base(options)
        { }

        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<DishInOrder> DishesInOrder { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<AdditionalIngredients> AdditionalIngredients { get; set; }
        public DbSet<AdditionsInOrder> AdditionsInOrder { get; set; }
        public DbSet<UserAddress> UserAddresses { get; set; }
		public DbSet<PaymentMethod> PaymentMethods { get; set; }
		public DbSet<Cart> Carts { get; set; }
		public DbSet<DishInCart> DishesInCart { get; set; }
		public DbSet<AdditionInCart> AdditionsInCart { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dish>().ToTable("Dish");
            modelBuilder.Entity<Order>().ToTable("Order");
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Address>().ToTable("Address");
            modelBuilder.Entity<DishInOrder>().ToTable("DishInOrder");
            modelBuilder.Entity<Ingredient>().ToTable("Ingredient");
            modelBuilder.Entity<AdditionalIngredients>().ToTable("AdditionalIngredients");
            modelBuilder.Entity<AdditionsInOrder>().ToTable("AdditionsInOrder");
            modelBuilder.Entity<UserAddress>().ToTable("Carts");
			modelBuilder.Entity<Cart>().ToTable("UserAddress");
			modelBuilder.Entity<DishInCart>().ToTable("DishesInCart");
			modelBuilder.Entity<AdditionInCart>().ToTable("AdditionsInCart");

			modelBuilder.Entity<DishInOrder>()
                .HasKey(c => new { c.DishID, c.OrderID });
            modelBuilder.Entity<AdditionalIngredients>()
                .HasKey(c => new { c.IngredientID, c.DishID });
            modelBuilder.Entity<AdditionsInOrder>()
                .HasKey(c => new { c.IngredientID, c.DishID, c.OrderID });
            modelBuilder.Entity<UserAddress>()
                .HasKey(c => new { c.UserID, c.AddressID });
			modelBuilder.Entity<DishInCart>()
				.HasKey(c => new { c.CartID, c.DishID });
			modelBuilder.Entity<AdditionInCart>()
				.HasKey(c => new { c.CartID, c.DishID, c.IngredientID });
		}
    }
}
