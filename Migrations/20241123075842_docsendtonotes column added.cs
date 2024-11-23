using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WISSEN.EDA.Migrations
{
    /// <inheritdoc />
    public partial class docsendtonotescolumnadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DocSendToNotes",
                table: "Customers",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DocSendToNotes",
                table: "Customers");
        }
    }
}
