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
                values: new object[] { new Guid("5af53c6d-cd97-4c5a-b1b6-e4bbaf79ee39"), new DateTime(2022, 12, 19, 13, 39, 25, 147, DateTimeKind.Local).AddTicks(6439), "Smartphone", new DateTime(2022, 12, 19, 13, 39, 25, 147, DateTimeKind.Local).AddTicks(6440) });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CreatedDateTime", "Name", "Surname", "UpdatedDateTime" },
                values: new object[] { new Guid("3afc4bbb-60b7-4b94-b84e-97820597b520"), new DateTime(2022, 12, 19, 13, 39, 25, 147, DateTimeKind.Local).AddTicks(6370), "John", "Doe", new DateTime(2022, 12, 19, 13, 39, 25, 147, DateTimeKind.Local).AddTicks(6371) });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Address", "CreatedDateTime", "CustomerId", "Description", "UpdatedDateTime" },
                values: new object[] { new Guid("f88f4d79-6e63-466e-86df-c1e31da62ce9"), "(217) 348-8633\r\n1418 6th St\r\nCharleston, Illinois(IL), 61920", new DateTime(2022, 12, 19, 13, 39, 25, 147, DateTimeKind.Local).AddTicks(4889), new Guid("3afc4bbb-60b7-4b94-b84e-97820597b520"), "Iphone 11", new DateTime(2022, 12, 19, 13, 39, 25, 147, DateTimeKind.Local).AddTicks(4901) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedDateTime", "Description", "Name", "Price", "Stock", "UpdatedDateTime" },
                values: new object[,]
                {
                    { new Guid("0bd8cad2-1ea0-4302-9ebf-612c2c77ca95"), new Guid("5af53c6d-cd97-4c5a-b1b6-e4bbaf79ee39"), new DateTime(2022, 12, 19, 13, 39, 25, 147, DateTimeKind.Local).AddTicks(6255), "128 gb white", "Iphone 11", 1399.0, 50, new DateTime(2022, 12, 19, 13, 39, 25, 147, DateTimeKind.Local).AddTicks(6255) },
                    { new Guid("5c6460be-a137-4ab3-845c-43accca7dbcd"), new Guid("5af53c6d-cd97-4c5a-b1b6-e4bbaf79ee39"), new DateTime(2022, 12, 19, 13, 39, 25, 147, DateTimeKind.Local).AddTicks(6231), "64 gb white", "Iphone 11", 1199.0, 50, new DateTime(2022, 12, 19, 13, 39, 25, 147, DateTimeKind.Local).AddTicks(6232) },
                    { new Guid("8ca3b302-7a9c-4738-b5bf-1674bb298e29"), new Guid("5af53c6d-cd97-4c5a-b1b6-e4bbaf79ee39"), new DateTime(2022, 12, 19, 13, 39, 25, 147, DateTimeKind.Local).AddTicks(6223), "128 gb black", "Iphone 11", 1399.0, 50, new DateTime(2022, 12, 19, 13, 39, 25, 147, DateTimeKind.Local).AddTicks(6226) }
                });

            migrationBuilder.InsertData(
                table: "ProductOrders",
                columns: new[] { "OrderId", "ProductId" },
                values: new object[] { new Guid("f88f4d79-6e63-466e-86df-c1e31da62ce9"), new Guid("5c6460be-a137-4ab3-845c-43accca7dbcd") });

            migrationBuilder.InsertData(
                table: "ProductOrders",
                columns: new[] { "OrderId", "ProductId" },
                values: new object[] { new Guid("f88f4d79-6e63-466e-86df-c1e31da62ce9"), new Guid("8ca3b302-7a9c-4738-b5bf-1674bb298e29") });

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
