using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryAppEFCore.DataLayer.Migrations
{
    public partial class clientmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Clients",
                table: "Clients");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.RenameTable(
                name: "Clients",
                newName: "Client");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Client",
                table: "Client",
                column: "ClientId");

            migrationBuilder.InsertData(
                table: "Client",
                columns: new[] { "ClientId", "IsDeleted", "Name" },
                values: new object[] { 1, false, "Client 1" });

            migrationBuilder.InsertData(
                table: "Client",
                columns: new[] { "ClientId", "IsDeleted", "Name" },
                values: new object[] { 2, false, "Client 2" });

            migrationBuilder.InsertData(
                table: "Client",
                columns: new[] { "ClientId", "IsDeleted", "Name" },
                values: new object[] { 3, false, "Client 3" });

            migrationBuilder.AddViewViaSql<ClientView>("ClientView", "Client", "Name = 'Client1'");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Client",
                table: "Client");

            migrationBuilder.DeleteData(
                table: "Client",
                keyColumn: "ClientId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Client",
                keyColumn: "ClientId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Client",
                keyColumn: "ClientId",
                keyValue: 3);

            migrationBuilder.RenameTable(
                name: "Client",
                newName: "Clients");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clients",
                table: "Clients",
                column: "ClientId");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "IsDeleted", "Name" },
                values: new object[] { 1, false, "Product 1" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "IsDeleted", "Name" },
                values: new object[] { 2, false, "Product 2" });
        }
    }
}
