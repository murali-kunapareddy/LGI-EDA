using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WISSEN.EDA.Migrations
{
    /// <inheritdoc />
    public partial class updatetomenucomponent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuMenu");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MenuMenu",
                columns: table => new
                {
                    ChildrenCode = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    ParentsCode = table.Column<string>(type: "nvarchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuMenu", x => new { x.ChildrenCode, x.ParentsCode });
                    table.ForeignKey(
                        name: "FK_MenuMenu_Menus_ChildrenCode",
                        column: x => x.ChildrenCode,
                        principalTable: "Menus",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuMenu_Menus_ParentsCode",
                        column: x => x.ParentsCode,
                        principalTable: "Menus",
                        principalColumn: "Code");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MenuMenu_ParentsCode",
                table: "MenuMenu",
                column: "ParentsCode");
        }
    }
}
