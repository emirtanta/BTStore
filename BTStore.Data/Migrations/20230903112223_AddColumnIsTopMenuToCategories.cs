using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTStore.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnIsTopMenuToCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsTopMenu",
                table: "Categories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 9, 3, 14, 22, 23, 103, DateTimeKind.Local).AddTicks(1042));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsTopMenu",
                table: "Categories");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 9, 2, 13, 30, 15, 484, DateTimeKind.Local).AddTicks(466));
        }
    }
}
