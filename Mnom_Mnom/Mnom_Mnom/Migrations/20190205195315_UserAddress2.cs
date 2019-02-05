using Microsoft.EntityFrameworkCore.Migrations;

namespace Mnom_Mnom.Migrations
{
    public partial class UserAddress2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserAddresses");

            migrationBuilder.CreateTable(
                name: "UserAddress",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false),
                    AddressID = table.Column<int>(nullable: false),
                    AddressID1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAddress", x => new { x.UserID, x.AddressID });
                    table.ForeignKey(
                        name: "FK_UserAddress_Address_AddressID1",
                        column: x => x.AddressID1,
                        principalTable: "Address",
                        principalColumn: "AddressID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserAddress_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserAddress_AddressID1",
                table: "UserAddress",
                column: "AddressID1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserAddress");

            migrationBuilder.CreateTable(
                name: "UserAddresses",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false),
                    AddressID = table.Column<int>(nullable: false),
                    AddressID1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAddresses", x => new { x.UserID, x.AddressID });
                    table.ForeignKey(
                        name: "FK_UserAddresses_Address_AddressID1",
                        column: x => x.AddressID1,
                        principalTable: "Address",
                        principalColumn: "AddressID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserAddresses_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserAddresses_AddressID1",
                table: "UserAddresses",
                column: "AddressID1");
        }
    }
}
