﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Mnom_Mnom.Models;

namespace Mnom_Mnom.Migrations
{
    [DbContext(typeof(Mnom_MnomContext))]
    [Migration("20190206130640_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Mnom_Mnom.Models.AdditionalIngredients", b =>
                {
                    b.Property<int>("IngredientID");

                    b.Property<int>("DishID");

                    b.Property<bool>("Available");

                    b.Property<int>("Max");

                    b.HasKey("IngredientID", "DishID");

                    b.HasIndex("DishID");

                    b.ToTable("AdditionalIngredients");
                });

            modelBuilder.Entity("Mnom_Mnom.Models.AdditionsInOrder", b =>
                {
                    b.Property<int>("IngredientID");

                    b.Property<int>("DishID");

                    b.Property<int>("OrderID");

                    b.Property<int>("Quantity");

                    b.HasKey("IngredientID", "DishID", "OrderID");

                    b.HasIndex("DishID");

                    b.HasIndex("OrderID");

                    b.ToTable("AdditionsInOrder");
                });

            modelBuilder.Entity("Mnom_Mnom.Models.Address", b =>
                {
                    b.Property<int>("AddressID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City");

                    b.Property<string>("Comment");

                    b.Property<string>("Flat");

                    b.Property<string>("House");

                    b.Property<string>("Region");

                    b.Property<string>("Street");

                    b.Property<int?>("UserID");

                    b.HasKey("AddressID");

                    b.HasIndex("UserID");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("Mnom_Mnom.Models.Dish", b =>
                {
                    b.Property<int>("DishID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<int>("Price");

                    b.Property<string>("Title");

                    b.Property<int>("Type");

                    b.HasKey("DishID");

                    b.ToTable("Dish");
                });

            modelBuilder.Entity("Mnom_Mnom.Models.DishInOrder", b =>
                {
                    b.Property<int>("DishID");

                    b.Property<int>("OrderID");

                    b.Property<int>("Discount");

                    b.Property<int>("Quantity");

                    b.Property<int>("UnitPrice");

                    b.HasKey("DishID", "OrderID");

                    b.HasIndex("OrderID");

                    b.ToTable("DishInOrder");
                });

            modelBuilder.Entity("Mnom_Mnom.Models.Ingredient", b =>
                {
                    b.Property<int>("IngredientID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Title");

                    b.HasKey("IngredientID");

                    b.ToTable("Ingredient");
                });

            modelBuilder.Entity("Mnom_Mnom.Models.Order", b =>
                {
                    b.Property<int>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddressID");

                    b.Property<string>("Comment");

                    b.Property<int>("PriceTotal");

                    b.Property<int>("Status");

                    b.Property<DateTime>("Time");

                    b.Property<int>("UserID");

                    b.HasKey("OrderID");

                    b.HasIndex("AddressID");

                    b.HasIndex("UserID");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("Mnom_Mnom.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Login");

                    b.Property<string>("Password");

                    b.Property<DateTime>("RegistrationDate");

                    b.Property<string>("TelNumber");

                    b.HasKey("UserID");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Mnom_Mnom.Models.UserAddress", b =>
                {
                    b.Property<int>("UserID");

                    b.Property<int>("AddressID");

                    b.HasKey("UserID", "AddressID");

                    b.HasIndex("AddressID");

                    b.ToTable("UserAddress");
                });

            modelBuilder.Entity("Mnom_Mnom.Models.AdditionalIngredients", b =>
                {
                    b.HasOne("Mnom_Mnom.Models.Dish", "Dish")
                        .WithMany()
                        .HasForeignKey("DishID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Mnom_Mnom.Models.Ingredient", "Ingredient")
                        .WithMany()
                        .HasForeignKey("IngredientID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Mnom_Mnom.Models.AdditionsInOrder", b =>
                {
                    b.HasOne("Mnom_Mnom.Models.Dish", "Dish")
                        .WithMany()
                        .HasForeignKey("DishID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Mnom_Mnom.Models.Ingredient", "Ingredient")
                        .WithMany()
                        .HasForeignKey("IngredientID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Mnom_Mnom.Models.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Mnom_Mnom.Models.Address", b =>
                {
                    b.HasOne("Mnom_Mnom.Models.User")
                        .WithMany("Addresses")
                        .HasForeignKey("UserID");
                });

            modelBuilder.Entity("Mnom_Mnom.Models.DishInOrder", b =>
                {
                    b.HasOne("Mnom_Mnom.Models.Dish", "Dish")
                        .WithMany()
                        .HasForeignKey("DishID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Mnom_Mnom.Models.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Mnom_Mnom.Models.Order", b =>
                {
                    b.HasOne("Mnom_Mnom.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Mnom_Mnom.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Mnom_Mnom.Models.UserAddress", b =>
                {
                    b.HasOne("Mnom_Mnom.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Mnom_Mnom.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
