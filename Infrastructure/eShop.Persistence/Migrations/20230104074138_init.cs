using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eShop.Persistence.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "ProductOrders",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductOrders", x => new { x.ProductId, x.OrderId });
                    table.ForeignKey(
                        name: "FK_ProductOrders_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductOrders_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDateTime", "Name", "UpdatedDateTime" },
                values: new object[] { new Guid("57fa1374-1566-47e7-b38c-67761d6f80b3"), new DateTime(2023, 1, 4, 11, 41, 37, 913, DateTimeKind.Local).AddTicks(5448), "Smartphone", new DateTime(2023, 1, 4, 11, 41, 37, 913, DateTimeKind.Local).AddTicks(5451) });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CreatedDateTime", "Name", "Surname", "UpdatedDateTime" },
                values: new object[] { new Guid("6f37954b-bcf5-4e9e-97e9-b71670226eea"), new DateTime(2023, 1, 4, 11, 41, 37, 913, DateTimeKind.Local).AddTicks(5167), "John", "Doe", new DateTime(2023, 1, 4, 11, 41, 37, 913, DateTimeKind.Local).AddTicks(5170) });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Address", "CreatedDateTime", "CustomerId", "Description", "UpdatedDateTime" },
                values: new object[] { new Guid("39973b5e-80b2-4a22-b02f-972805dbb74c"), "(217) 348-8633\r\n1418 6th St\r\nCharleston, Illinois(IL), 61920", new DateTime(2023, 1, 4, 11, 41, 37, 913, DateTimeKind.Local).AddTicks(1786), new Guid("6f37954b-bcf5-4e9e-97e9-b71670226eea"), "Iphone 11", new DateTime(2023, 1, 4, 11, 41, 37, 913, DateTimeKind.Local).AddTicks(1800) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedDateTime", "Description", "Image", "Name", "Price", "Stock", "UpdatedDateTime" },
                values: new object[,]
                {
                    { new Guid("0aa90116-118a-4681-bfe7-fc778ea5408d"), new Guid("57fa1374-1566-47e7-b38c-67761d6f80b3"), new DateTime(2023, 1, 4, 11, 41, 37, 913, DateTimeKind.Local).AddTicks(4793), "128 gb black", "iphone-11-black.jpg", "Iphone 11", 1399.0, 50, new DateTime(2023, 1, 4, 11, 41, 37, 913, DateTimeKind.Local).AddTicks(4799) },
                    { new Guid("2943329b-8cd0-4ee1-9ffc-d22cf298917f"), new Guid("57fa1374-1566-47e7-b38c-67761d6f80b3"), new DateTime(2023, 1, 4, 11, 41, 37, 913, DateTimeKind.Local).AddTicks(4853), "128 gb white", "iphone-11-white.jpg", "Iphone 11", 1399.0, 50, new DateTime(2023, 1, 4, 11, 41, 37, 913, DateTimeKind.Local).AddTicks(4854) },
                    { new Guid("ed7f87fe-14b1-4071-adce-eaec17d4588e"), new Guid("57fa1374-1566-47e7-b38c-67761d6f80b3"), new DateTime(2023, 1, 4, 11, 41, 37, 913, DateTimeKind.Local).AddTicks(4816), "64 gb white", "iphone-11-white.jpg", "Iphone 11", 1199.0, 50, new DateTime(2023, 1, 4, 11, 41, 37, 913, DateTimeKind.Local).AddTicks(4817) }
                });

            migrationBuilder.InsertData(
                table: "ProductOrders",
                columns: new[] { "OrderId", "ProductId" },
                values: new object[] { new Guid("39973b5e-80b2-4a22-b02f-972805dbb74c"), new Guid("0aa90116-118a-4681-bfe7-fc778ea5408d") });

            migrationBuilder.InsertData(
                table: "ProductOrders",
                columns: new[] { "OrderId", "ProductId" },
                values: new object[] { new Guid("39973b5e-80b2-4a22-b02f-972805dbb74c"), new Guid("ed7f87fe-14b1-4071-adce-eaec17d4588e") });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductOrders_OrderId",
                table: "ProductOrders",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductOrders");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
