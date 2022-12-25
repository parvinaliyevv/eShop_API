using System;
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
                values: new object[] { new Guid("8782db3e-95bb-4c89-a92f-d3e92b9dceff"), new DateTime(2022, 12, 25, 21, 24, 27, 859, DateTimeKind.Local).AddTicks(6488), "Smartphone", new DateTime(2022, 12, 25, 21, 24, 27, 859, DateTimeKind.Local).AddTicks(6491) });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CreatedDateTime", "Name", "Surname", "UpdatedDateTime" },
                values: new object[] { new Guid("5dd54910-ae6a-439d-b85b-5034cf34de20"), new DateTime(2022, 12, 25, 21, 24, 27, 859, DateTimeKind.Local).AddTicks(6179), "John", "Doe", new DateTime(2022, 12, 25, 21, 24, 27, 859, DateTimeKind.Local).AddTicks(6182) });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Address", "CreatedDateTime", "CustomerId", "Description", "UpdatedDateTime" },
                values: new object[] { new Guid("1b11eff0-3bb0-46be-8f5c-ee3e4e57cff5"), "(217) 348-8633\r\n1418 6th St\r\nCharleston, Illinois(IL), 61920", new DateTime(2022, 12, 25, 21, 24, 27, 859, DateTimeKind.Local).AddTicks(3423), new Guid("5dd54910-ae6a-439d-b85b-5034cf34de20"), "Iphone 11", new DateTime(2022, 12, 25, 21, 24, 27, 859, DateTimeKind.Local).AddTicks(3434) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedDateTime", "Description", "Name", "Price", "Stock", "UpdatedDateTime" },
                values: new object[,]
                {
                    { new Guid("3d074776-26b2-45ba-86c5-527cbf2c5297"), new Guid("8782db3e-95bb-4c89-a92f-d3e92b9dceff"), new DateTime(2022, 12, 25, 21, 24, 27, 859, DateTimeKind.Local).AddTicks(5729), "128 gb black", "Iphone 11", 1399.0, 50, new DateTime(2022, 12, 25, 21, 24, 27, 859, DateTimeKind.Local).AddTicks(5733) },
                    { new Guid("84d2c679-22d7-4e78-b477-284c3e062cdb"), new Guid("8782db3e-95bb-4c89-a92f-d3e92b9dceff"), new DateTime(2022, 12, 25, 21, 24, 27, 859, DateTimeKind.Local).AddTicks(5746), "64 gb white", "Iphone 11", 1199.0, 50, new DateTime(2022, 12, 25, 21, 24, 27, 859, DateTimeKind.Local).AddTicks(5747) },
                    { new Guid("c4628cfc-2421-45c1-a34e-568c8d7bd7e6"), new Guid("8782db3e-95bb-4c89-a92f-d3e92b9dceff"), new DateTime(2022, 12, 25, 21, 24, 27, 859, DateTimeKind.Local).AddTicks(5799), "128 gb white", "Iphone 11", 1399.0, 50, new DateTime(2022, 12, 25, 21, 24, 27, 859, DateTimeKind.Local).AddTicks(5802) }
                });

            migrationBuilder.InsertData(
                table: "ProductOrders",
                columns: new[] { "OrderId", "ProductId" },
                values: new object[] { new Guid("1b11eff0-3bb0-46be-8f5c-ee3e4e57cff5"), new Guid("3d074776-26b2-45ba-86c5-527cbf2c5297") });

            migrationBuilder.InsertData(
                table: "ProductOrders",
                columns: new[] { "OrderId", "ProductId" },
                values: new object[] { new Guid("1b11eff0-3bb0-46be-8f5c-ee3e4e57cff5"), new Guid("84d2c679-22d7-4e78-b477-284c3e062cdb") });

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
