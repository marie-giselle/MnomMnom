using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Mnom_Mnom.Models
{
    public class Mnom_MnomContext : DbContext
    {
        public Mnom_MnomContext (DbContextOptions<Mnom_MnomContext> options)
            : base(options)
        {
        }

        public DbSet<Dish> Dish { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<DishInOrder> DishInOrder { get; set; }
        public DbSet<Ingredient> Ingredient { get; set; }
        public DbSet<AdditionalIngredients> AdditionalIngredients { get; set; }
        public DbSet<AdditionsInOrder> AdditionsInOrder { get; set; }
        public DbSet<UserAddress> UserAddresses { get; set; }

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
            modelBuilder.Entity<UserAddress>().ToTable("UserAddress");

            modelBuilder.Entity<DishInOrder>()
                .HasKey(c => new { c.DishID, c.OrderID });
            modelBuilder.Entity<AdditionalIngredients>()
                .HasKey(c => new { c.IngredientID, c.DishID });
            modelBuilder.Entity<AdditionsInOrder>()
                .HasKey(c => new { c.IngredientID, c.DishID, c.OrderID });
            modelBuilder.Entity<UserAddress>()
                .HasKey(c => new { c.UserID, c.AddressID });
        }
    }
}
