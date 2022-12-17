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
                values: new object[] { new Guid("44c82bb0-69da-4a9a-944d-85e7f2b34a5a"), new DateTime(2022, 12, 17, 18, 10, 48, 939, DateTimeKind.Local).AddTicks(4535), "Smartphone", new DateTime(2022, 12, 17, 18, 10, 48, 939, DateTimeKind.Local).AddTicks(4538) });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CreatedDateTime", "Name", "Surname", "UpdatedDateTime" },
                values: new object[] { new Guid("2611f479-f66d-4680-8c52-14356f2b41e0"), new DateTime(2022, 12, 17, 18, 10, 48, 939, DateTimeKind.Local).AddTicks(4199), "John", "Doe", new DateTime(2022, 12, 17, 18, 10, 48, 939, DateTimeKind.Local).AddTicks(4203) });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Address", "CreatedDateTime", "CustomerId", "Description", "UpdatedDateTime" },
                values: new object[] { new Guid("12a82fd8-5b41-4be6-89e3-299c517ec0ee"), "(217) 348-8633\r\n1418 6th St\r\nCharleston, Illinois(IL), 61920", new DateTime(2022, 12, 17, 18, 10, 48, 939, DateTimeKind.Local).AddTicks(198), new Guid("2611f479-f66d-4680-8c52-14356f2b41e0"), "Iphone 11", new DateTime(2022, 12, 17, 18, 10, 48, 939, DateTimeKind.Local).AddTicks(213) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedDateTime", "Description", "Name", "Price", "Stock", "UpdatedDateTime" },
                values: new object[,]
                {
                    { new Guid("36b09fbd-652c-4948-be89-d0566d5f0a74"), new Guid("44c82bb0-69da-4a9a-944d-85e7f2b34a5a"), new DateTime(2022, 12, 17, 18, 10, 48, 939, DateTimeKind.Local).AddTicks(3774), "64 gb white", "Iphone 11", 1199.0, 50, new DateTime(2022, 12, 17, 18, 10, 48, 939, DateTimeKind.Local).AddTicks(3775) },
                    { new Guid("55ea91c2-f379-48fe-81c7-916221214984"), new Guid("44c82bb0-69da-4a9a-944d-85e7f2b34a5a"), new DateTime(2022, 12, 17, 18, 10, 48, 939, DateTimeKind.Local).AddTicks(3755), "128 gb black", "Iphone 11", 1399.0, 50, new DateTime(2022, 12, 17, 18, 10, 48, 939, DateTimeKind.Local).AddTicks(3760) },
                    { new Guid("e88b8789-0174-49a5-ad7b-f6054b699af4"), new Guid("44c82bb0-69da-4a9a-944d-85e7f2b34a5a"), new DateTime(2022, 12, 17, 18, 10, 48, 939, DateTimeKind.Local).AddTicks(3780), "128 gb white", "Iphone 11", 1399.0, 50, new DateTime(2022, 12, 17, 18, 10, 48, 939, DateTimeKind.Local).AddTicks(3781) }
                });

            migrationBuilder.InsertData(
                table: "ProductOrders",
                columns: new[] { "ProductId", "OrderId" },
                values: new object[,]
                {
                    { new Guid("36b09fbd-652c-4948-be89-d0566d5f0a74"), new Guid("12a82fd8-5b41-4be6-89e3-299c517ec0ee") },
                    { new Guid("55ea91c2-f379-48fe-81c7-916221214984"), new Guid("12a82fd8-5b41-4be6-89e3-299c517ec0ee") },
                    { new Guid("e88b8789-0174-49a5-ad7b-f6054b699af4"), new Guid("12a82fd8-5b41-4be6-89e3-299c517ec0ee") }
                });

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
