using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WISSEN.EDA.Migrations
{
    /// <inheritdoc />
    public partial class customermissingcolumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImportPermitRequiredBeforeShipping",
                table: "Customers",
                newName: "ImportPermitRequired");

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Code",
                keyValue: "BACKOPS",
                column: "CreatedOn",
                value: new DateTime(2024, 11, 24, 18, 59, 52, 964, DateTimeKind.Local).AddTicks(9967));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Code",
                keyValue: "CUSTOMERS",
                column: "CreatedOn",
                value: new DateTime(2024, 11, 24, 18, 59, 52, 964, DateTimeKind.Local).AddTicks(9959));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Code",
                keyValue: "DASHBOARD",
                column: "CreatedOn",
                value: new DateTime(2024, 11, 24, 18, 59, 52, 964, DateTimeKind.Local).AddTicks(9954));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Code",
                keyValue: "MASTERS",
                column: "CreatedOn",
                value: new DateTime(2024, 11, 24, 18, 59, 52, 964, DateTimeKind.Local).AddTicks(9962));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Code",
                keyValue: "ORDERS",
                column: "CreatedOn",
                value: new DateTime(2024, 11, 24, 18, 59, 52, 964, DateTimeKind.Local).AddTicks(9957));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Code",
                keyValue: "SETTINGS",
                column: "CreatedOn",
                value: new DateTime(2024, 11, 24, 18, 59, 52, 964, DateTimeKind.Local).AddTicks(9965));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Email",
                keyValue: "murali.kunapareddy@vendor.lgiglobal.com",
                column: "CreatedOn",
                value: new DateTime(2024, 11, 24, 18, 59, 52, 964, DateTimeKind.Local).AddTicks(9923));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImportPermitRequired",
                table: "Customers",
                newName: "ImportPermitRequiredBeforeShipping");            

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Code",
                keyValue: "BACKOPS",
                column: "CreatedOn",
                value: new DateTime(2024, 11, 23, 13, 28, 40, 467, DateTimeKind.Local).AddTicks(6503));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Code",
                keyValue: "CUSTOMERS",
                column: "CreatedOn",
                value: new DateTime(2024, 11, 23, 13, 28, 40, 467, DateTimeKind.Local).AddTicks(6494));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Code",
                keyValue: "DASHBOARD",
                column: "CreatedOn",
                value: new DateTime(2024, 11, 23, 13, 28, 40, 467, DateTimeKind.Local).AddTicks(6488));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Code",
                keyValue: "MASTERS",
                column: "CreatedOn",
                value: new DateTime(2024, 11, 23, 13, 28, 40, 467, DateTimeKind.Local).AddTicks(6497));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Code",
                keyValue: "ORDERS",
                column: "CreatedOn",
                value: new DateTime(2024, 11, 23, 13, 28, 40, 467, DateTimeKind.Local).AddTicks(6491));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Code",
                keyValue: "SETTINGS",
                column: "CreatedOn",
                value: new DateTime(2024, 11, 23, 13, 28, 40, 467, DateTimeKind.Local).AddTicks(6500));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Email",
                keyValue: "murali.kunapareddy@vendor.lgiglobal.com",
                column: "CreatedOn",
                value: new DateTime(2024, 11, 23, 13, 28, 40, 467, DateTimeKind.Local).AddTicks(6453));
        }
    }
}
