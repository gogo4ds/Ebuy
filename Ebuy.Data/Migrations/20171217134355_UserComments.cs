using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Ebuy.Data.Migrations
{
    public partial class UserComments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "Apperture",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "FocalLenght",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Display",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Tv_Display",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Inches",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "User",
                table: "Reviews",
                newName: "UserId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Reviews",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Reviews",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Comments",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Comments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_AspNetUsers_UserId",
                table: "Reviews",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_AspNetUsers_UserId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Reviews",
                newName: "User");

            migrationBuilder.AlterColumn<string>(
                name: "User",
                table: "Reviews",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Comments",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Apperture",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "FocalLenght",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Products",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Display",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Tv_Display",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Inches",
                table: "Products",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
