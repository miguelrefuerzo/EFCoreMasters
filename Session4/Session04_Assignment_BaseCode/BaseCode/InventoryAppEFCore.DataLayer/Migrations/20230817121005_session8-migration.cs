using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryAppEFCore.DataLayer.Migrations
{
    public partial class session8migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOrderedUtc",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Client",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Client",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Client",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Client",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                computedColumnSql: "[FirstName] + ' ' + [LastName]",
                stored: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.UpdateData(
                table: "Client",
                keyColumn: "ClientId",
                keyValue: 1,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Session", "8" });

            migrationBuilder.UpdateData(
                table: "Client",
                keyColumn: "ClientId",
                keyValue: 2,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Session", "8" });

            migrationBuilder.UpdateData(
                table: "Client",
                keyColumn: "ClientId",
                keyValue: 3,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Session", "8" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Client");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOrderedUtc",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Client",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComputedColumnSql: "[FirstName] + ' ' + [LastName]");
        }
    }
}
