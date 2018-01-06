using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Ebuy.Data.Migrations
{
    public partial class ImageName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Picture",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Products",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Products");

            migrationBuilder.AddColumn<byte[]>(
                name: "Picture",
                table: "Products",
                nullable: true);
        }
    }
}
