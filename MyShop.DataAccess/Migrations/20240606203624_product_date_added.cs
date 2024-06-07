﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyShop.web.Migrations
{
    /// <inheritdoc />
    public partial class product_date_added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAdd",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAdd",
                table: "Products");
        }
    }
}
