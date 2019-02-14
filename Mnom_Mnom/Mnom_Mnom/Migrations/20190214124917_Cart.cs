using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mnom_Mnom.Migrations
{
    public partial class Cart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserAddress",
                table: "UserAddress");

            migrationBuilder.AddColumn<int>(
                name: "CartID",
                table: "UserAddress",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "UserAddress",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "PaymentMethodID",
                table: "UserAddress",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserAddress",
                table: "UserAddress",
                column: "CartID");

            migrationBuilder.CreateTable(
                name: "AdditionsInCart",
                columns: table => new
                {
                    CartID = table.Column<int>(nullable: false),
                    DishID = table.Column<int>(nullable: false),
                    IngredientID = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditionsInCart", x => new { x.CartID, x.DishID, x.IngredientID });
                    table.ForeignKey(
                        name: "FK_AdditionsInCart_UserAddress_CartID",
                        column: x => x.CartID,
                        principalTable: "UserAddress",
                        principalColumn: "CartID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdditionsInCart_Dish_DishID",
                        column: x => x.DishID,
                        principalTable: "Dish",
                        principalColumn: "DishID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdditionsInCart_Ingredient_IngredientID",
                        column: x => x.IngredientID,
                        principalTable: "Ingredient",
                        principalColumn: "IngredientID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false),
                    AddressID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => new { x.UserID, x.AddressID });
                    table.ForeignKey(
                        name: "FK_Carts_Address_AddressID",
                        column: x => x.AddressID,
                        principalTable: "Address",
                        principalColumn: "AddressID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Carts_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DishesInCart",
                columns: table => new
                {
                    CartID = table.Column<int>(nullable: false),
                    DishID = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishesInCart", x => new { x.CartID, x.DishID });
                    table.ForeignKey(
                        name: "FK_DishesInCart_UserAddress_CartID",
                        column: x => x.CartID,
                        principalTable: "UserAddress",
                        principalColumn: "CartID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DishesInCart_Dish_DishID",
                        column: x => x.DishID,
                        principalTable: "Dish",
                        principalColumn: "DishID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethods",
                columns: table => new
                {
                    PaymentMethodID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethods", x => x.PaymentMethodID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserAddress_PaymentMethodID",
                table: "UserAddress",
                column: "PaymentMethodID");

            migrationBuilder.CreateIndex(
                name: "IX_UserAddress_UserID",
                table: "UserAddress",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_AdditionsInCart_DishID",
                table: "AdditionsInCart",
                column: "DishID");

            migrationBuilder.CreateIndex(
                name: "IX_AdditionsInCart_IngredientID",
                table: "AdditionsInCart",
                column: "IngredientID");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_AddressID",
                table: "Carts",
                column: "AddressID");

            migrationBuilder.CreateIndex(
                name: "IX_DishesInCart_DishID",
                table: "DishesInCart",
                column: "DishID");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAddress_PaymentMethods_PaymentMethodID",
                table: "UserAddress",
                column: "PaymentMethodID",
                principalTable: "PaymentMethods",
                principalColumn: "PaymentMethodID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAddress_PaymentMethods_PaymentMethodID",
                table: "UserAddress");

            migrationBuilder.DropTable(
                name: "AdditionsInCart");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "DishesInCart");

            migrationBuilder.DropTable(
                name: "PaymentMethods");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserAddress",
                table: "UserAddress");

            migrationBuilder.DropIndex(
                name: "IX_UserAddress_PaymentMethodID",
                table: "UserAddress");

            migrationBuilder.DropIndex(
                name: "IX_UserAddress_UserID",
                table: "UserAddress");

            migrationBuilder.DropColumn(
                name: "CartID",
                table: "UserAddress");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "UserAddress");

            migrationBuilder.DropColumn(
                name: "PaymentMethodID",
                table: "UserAddress");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserAddress",
                table: "UserAddress",
                columns: new[] { "UserID", "AddressID" });
        }
    }
}
