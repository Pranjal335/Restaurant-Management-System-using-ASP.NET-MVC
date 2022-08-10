using Microsoft.EntityFrameworkCore.Migrations;

namespace Hotel.Web.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "varchar(50)", nullable: false),
                    Address = table.Column<string>(type: "varchar(100)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "DishCategory",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishCategory", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    OrderDetailId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentMethods = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.OrderDetailId);
                });

            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    DishID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DishName = table.Column<string>(type: "varchar(50)", nullable: false),
                    Quantity = table.Column<short>(nullable: false),
                    ImageUrl = table.Column<string>(maxLength: 120, nullable: true),
                    DishPrice = table.Column<string>(type: "varchar(50)", nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.DishID);
                    table.ForeignKey(
                        name: "FK_Menu_DishCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "DishCategory",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderDetailId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(nullable: false),
                    DishId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    PaymentMethod = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.OrderDetailId);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Menu_DishId",
                        column: x => x.DishId,
                        principalTable: "Menu",
                        principalColumn: "DishID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Payments_PaymentMethod",
                        column: x => x.PaymentMethod,
                        principalTable: "Payments",
                        principalColumn: "OrderDetailId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Menu_CategoryId",
                table: "Menu",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_CustomerId",
                table: "OrderDetails",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_DishId",
                table: "OrderDetails",
                column: "DishId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_PaymentMethod",
                table: "OrderDetails",
                column: "PaymentMethod");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "DishCategory");
        }
    }
}
