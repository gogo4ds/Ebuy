﻿using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Ebuy.Data.Migrations
{
    public partial class MadeCategoryParentIdNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ParentId",
                table: "Categories",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ParentId",
                table: "Categories",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
