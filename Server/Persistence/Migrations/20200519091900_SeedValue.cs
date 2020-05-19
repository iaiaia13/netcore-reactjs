﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class SeedValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Value",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Value101" });

            migrationBuilder.InsertData(
                table: "Value",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Value102" });

            migrationBuilder.InsertData(
                table: "Value",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Value103" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Value",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Value",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Value",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
