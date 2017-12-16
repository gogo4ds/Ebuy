using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Ebuy.Data.Migrations
{
    public partial class AllProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Product_ProductId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerProducts_Product_ProductId",
                table: "CustomerProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Product_ProductId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_SellerProducts_Product_ProductId",
                table: "SellerProducts");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Apperture = table.Column<double>(nullable: true),
                    FocalLenght = table.Column<double>(nullable: true),
                    Type = table.Column<int>(nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BrandName = table.Column<string>(maxLength: 50, nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Picture = table.Column<byte[]>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Rating = table.Column<double>(nullable: true),
                    Display = table.Column<int>(nullable: true),
                    Tv_Display = table.Column<int>(nullable: true),
                    Inches = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Products_ProductId",
                table: "Comments",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerProducts_Products_ProductId",
                table: "CustomerProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Products_ProductId",
                table: "Reviews",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SellerProducts_Products_ProductId",
                table: "SellerProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Products_ProductId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerProducts_Products_ProductId",
                table: "CustomerProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Products_ProductId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_SellerProducts_Products_ProductId",
                table: "SellerProducts");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BrandName = table.Column<string>(maxLength: 50, nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Picture = table.Column<byte[]>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Rating = table.Column<double>(nullable: true),
                    Apperture = table.Column<double>(nullable: true),
                    FocalLenght = table.Column<double>(nullable: true),
                    Type = table.Column<int>(nullable: true),
                    Display = table.Column<int>(nullable: true),
                    Tv_Display = table.Column<int>(nullable: true),
                    Inches = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Product_ProductId",
                table: "Comments",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerProducts_Product_ProductId",
                table: "CustomerProducts",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Product_ProductId",
                table: "Reviews",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SellerProducts_Product_ProductId",
                table: "SellerProducts",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
