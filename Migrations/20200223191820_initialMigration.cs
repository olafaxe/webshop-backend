﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace shopApi.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Info = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false),
                    Price = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductId = table.Column<int>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    SizeId = table.Column<int>(nullable: false),
                    OrderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItem_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItem_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Email", "UserName" },
                values: new object[] { 1, "ola@mail.com", "Ola" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Email", "UserName" },
                values: new object[] { 2, "anton@mail.com", "Anton" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Email", "UserName" },
                values: new object[] { 3, "faxe@mail.com", "Faxe" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Image", "Info", "Name", "Price" },
                values: new object[] { 1, "https://picsum.photos/id/204/5184/3456", "En sak. Standard", "Sak", 50.0 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Image", "Info", "Name", "Price" },
                values: new object[] { 2, "https://picsum.photos/id/19/2500/1667", "Likadan som den andra saken fast en annan.", "Annan sak", 30.0 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Image", "Info", "Name", "Price" },
                values: new object[] { 3, "https://picsum.photos/id/144/4912/2760", "Troligtvis en sak men också lite oklart.", "Kanske en sak", 10.0 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Image", "Info", "Name", "Price" },
                values: new object[] { 4, "https://picsum.photos/id/164/1200/800", "Hög med saker. Inte så fina.", "Lite fula saker", 1005.0 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Image", "Info", "Name", "Price" },
                values: new object[] { 5, "https://picsum.photos/id/131/4698/3166", "En väldigt fin sak. Och billig.", "Fin sak", 5.0 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Image", "Info", "Name", "Price" },
                values: new object[] { 6, "https://picsum.photos/id/154/3264/2176", "Två udda saker. Precis som namnet beskriver.", "Två udda saker", 99.0 });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CustomerId", "OrderDate", "Price" },
                values: new object[] { 3, 1, new DateTime(2020, 2, 17, 20, 18, 20, 183, DateTimeKind.Local).AddTicks(3721), 0 });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CustomerId", "OrderDate", "Price" },
                values: new object[] { 2, 2, new DateTime(2020, 2, 18, 20, 18, 20, 183, DateTimeKind.Local).AddTicks(3639), 0 });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CustomerId", "OrderDate", "Price" },
                values: new object[] { 1, 3, new DateTime(2020, 1, 29, 20, 18, 20, 180, DateTimeKind.Local).AddTicks(8839), 0 });

            migrationBuilder.InsertData(
                table: "OrderItem",
                columns: new[] { "Id", "OrderId", "Price", "ProductId", "SizeId" },
                values: new object[] { 5, 3, 0, 3, 0 });

            migrationBuilder.InsertData(
                table: "OrderItem",
                columns: new[] { "Id", "OrderId", "Price", "ProductId", "SizeId" },
                values: new object[] { 4, 2, 0, 1, 0 });

            migrationBuilder.InsertData(
                table: "OrderItem",
                columns: new[] { "Id", "OrderId", "Price", "ProductId", "SizeId" },
                values: new object[] { 1, 1, 0, 2, 0 });

            migrationBuilder.InsertData(
                table: "OrderItem",
                columns: new[] { "Id", "OrderId", "Price", "ProductId", "SizeId" },
                values: new object[] { 2, 1, 0, 2, 0 });

            migrationBuilder.InsertData(
                table: "OrderItem",
                columns: new[] { "Id", "OrderId", "Price", "ProductId", "SizeId" },
                values: new object[] { 3, 1, 0, 3, 0 });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_OrderId",
                table: "OrderItem",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_ProductId",
                table: "OrderItem",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItem");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
