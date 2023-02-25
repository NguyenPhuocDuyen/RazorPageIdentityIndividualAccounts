using Microsoft.EntityFrameworkCore.Migrations;

namespace RazorPageIdentityIndividualAccounts.Data.Migrations
{
    public partial class AddRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d8dfc571-3359-4c59-8c2f-c5322abf48b0", "e4def885-48af-4166-a774-1226ea139b70", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "87492cfb-29af-4171-ae3c-7ac8ba32c819", "27d3ffd6-ee08-4224-8392-9eb888c42c22", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2b0f87a2-819b-4637-87e1-4274e03baf98", "906fe1d7-c6cb-4cd7-9be6-9272d1adca14", "Employee", "EMPLOYEE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2b0f87a2-819b-4637-87e1-4274e03baf98");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "87492cfb-29af-4171-ae3c-7ac8ba32c819");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d8dfc571-3359-4c59-8c2f-c5322abf48b0");
        }
    }
}
