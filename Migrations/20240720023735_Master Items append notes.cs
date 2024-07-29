using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WISSEN.EDA.Migrations
{
    /// <inheritdoc />
    public partial class MasterItemsappendnotes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "MasterItems",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Notes",
                table: "MasterItems");
        }
    }
}
