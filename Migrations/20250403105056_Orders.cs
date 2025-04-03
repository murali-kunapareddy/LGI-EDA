using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WISSEN.EDA.Migrations
{
    /// <inheritdoc />
    public partial class Orders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalesRepName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerPONo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContractNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BillToNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShipToNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShipVia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsImportPermitRequired = table.Column<bool>(type: "bit", nullable: false),
                    IsPermitReceived = table.Column<bool>(type: "bit", nullable: false),
                    ContainerSizeId = table.Column<int>(type: "int", nullable: false),
                    RequestContainerLoading = table.Column<int>(type: "int", nullable: false),
                    RequestedETA = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SpecialShippingInstructions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpecialSKU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsSepareteChargeApplicable = table.Column<bool>(type: "bit", nullable: false),
                    FloorLoadChargeRate = table.Column<double>(type: "float", nullable: false),
                    IsFloorLoarChargeIncluded = table.Column<bool>(type: "bit", nullable: false),
                    PalletChargeRate = table.Column<double>(type: "float", nullable: false),
                    IsPalletChargeIncluded = table.Column<bool>(type: "bit", nullable: false),
                    AdditionalNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_MasterItems_ContainerSizeId",
                        column: x => x.ContainerSizeId,
                        principalTable: "MasterItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderAttachments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    FileType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FileSize = table.Column<int>(type: "int", nullable: false),
                    FileHash = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderAttachments_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderAttachments_OrderId",
                table: "OrderAttachments",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ContainerSizeId",
                table: "Orders",
                column: "ContainerSizeId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderAttachments");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
