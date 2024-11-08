using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WISSEN.EDA.Migrations
{
    /// <inheritdoc />
    public partial class customertablesadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "MasterItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AddressLine = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    State = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CountryCode = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Zip = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Website = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    TaxId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    VATNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AdditionalEmails = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "DEFAULTADMIN"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: DateTime.UtcNow),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Countries_CountryCode",
                        column: x => x.CountryCode,
                        principalTable: "Countries",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BillToNo = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    BillToName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BillToAddressId = table.Column<int>(type: "int", nullable: false),
                    ShipToNo = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    ShipToName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ShipToAddressId = table.Column<int>(type: "int", nullable: false),
                    CompanyCode = table.Column<int>(type: "int", maxLength: 100, nullable: false),
                    DocsSendToAddressId = table.Column<int>(type: "int", nullable: false),
                    BrokerAddressId = table.Column<int>(type: "int", nullable: false),
                    NotifyPartyAddressId = table.Column<int>(type: "int", nullable: false),
                    BankAddressId = table.Column<int>(type: "int", nullable: false),
                    DocsDistributionEmails = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CustomerBookingEmails = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    UltimateConsgineeTypeId = table.Column<int>(type: "int", nullable: false),
                    ExportInfoCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    LicenseCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    LicenseNo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    RoutedTransaction = table.Column<bool>(type: "bit", nullable: false),
                    PaymentTermId = table.Column<int>(type: "int", nullable: false),
                    Incoterm2020Id = table.Column<int>(type: "int", nullable: false),
                    ProformaInvoiceRequired = table.Column<bool>(type: "bit", nullable: false),
                    PictureRequired = table.Column<bool>(type: "bit", nullable: false),
                    ImportPermitRequiredBeforeShipping = table.Column<bool>(type: "bit", nullable: false),
                    ImportPermitNotes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ExportComments = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    OldNotes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "DEFAULTADMIN"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: DateTime.UtcNow),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customer_Addresses_BankAddressId",
                        column: x => x.BankAddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Customer_Addresses_BillToAddressId",
                        column: x => x.BillToAddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Customer_Addresses_BrokerAddressId",
                        column: x => x.BrokerAddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Customer_Addresses_DocsSendToAddressId",
                        column: x => x.DocsSendToAddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Customer_Addresses_NotifyPartyAddressId",
                        column: x => x.NotifyPartyAddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Customer_Addresses_ShipToAddressId",
                        column: x => x.ShipToAddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Customer_Companies_CompanyCode",
                        column: x => x.CompanyCode,
                        principalTable: "Companies",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Customer_MasterItems_Incoterm2020Id",
                        column: x => x.Incoterm2020Id,
                        principalTable: "MasterItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Customer_MasterItems_PaymentTermId",
                        column: x => x.PaymentTermId,
                        principalTable: "MasterItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Customer_MasterItems_UltimateConsgineeTypeId",
                        column: x => x.UltimateConsgineeTypeId,
                        principalTable: "MasterItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "CustomerAttachments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    FileType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FileSize = table.Column<int>(type: "int", nullable: false),
                    FileHash = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "DEFAULTADMIN"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: DateTime.UtcNow),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerAttachments_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerPaperworks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    PaperworkId = table.Column<int>(type: "int", nullable: false),
                    OriginalQuantity = table.Column<int>(type: "int", nullable: false),
                    CopyQuantity = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "DEFAULTADMIN"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: DateTime.UtcNow),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerPaperworks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerPaperworks_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerPaperworks_MasterItems_PaperworkId",
                        column: x => x.PaperworkId,
                        principalTable: "MasterItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            //migrationBuilder.InsertData(
            //    table: "Countries",
            //    columns: new[] { "Code", "CreatedBy", "CreatedOn", "IsActive", "IsDeleted", "ModifiedBy", "ModifiedOn", "Name" },
            //    values: new object[,]
            //    {
            //        { "AD", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(1899), true, false, null, null, "Andorra" },
            //        { "AE", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2478), true, false, null, null, "United Arab Emirates" },
            //        { "AF", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(1887), true, false, null, null, "Afghanistan" },
            //        { "AG", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(1906), true, false, null, null, "Antigua and Barbuda" },
            //        { "AL", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(1892), true, false, null, null, "Albania" },
            //        { "AM", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(1910), true, false, null, null, "Armenia" },
            //        { "AO", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(1901), true, false, null, null, "Angola" },
            //        { "AQ", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(1904), true, false, null, null, "Antarctica" },
            //        { "AR", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(1908), true, false, null, null, "Argentina" },
            //        { "AS", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(1897), true, false, null, null, "American Samoa" },
            //        { "AT", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(1917), true, false, null, null, "Austria" },
            //        { "AU", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(1915), true, false, null, null, "Australia" },
            //        { "AW", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(1913), true, false, null, null, "Aruba" },
            //        { "AX", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(1890), true, false, null, null, "Åland Islands" },
            //        { "AZ", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(1920), true, false, null, null, "Azerbaijan" },
            //        { "BA", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(1949), true, false, null, null, "Bosnia and Herzegovina" },
            //        { "BB", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(1929), true, false, null, null, "Barbados" },
            //        { "BD", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(1926), true, false, null, null, "Bangladesh" },
            //        { "BE", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(1933), true, false, null, null, "Belgium" },
            //        { "BF", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(1968), true, false, null, null, "Burkina Faso" },
            //        { "BG", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(1965), true, false, null, null, "Bulgaria" },
            //        { "BH", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(1924), true, false, null, null, "Bahrain" },
            //        { "BI", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(1970), true, false, null, null, "Burundi" },
            //        { "BJ", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(1938), true, false, null, null, "Benin" },
            //        { "BL", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2368), true, false, null, null, "Saint Barthélemy" },
            //        { "BM", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(1940), true, false, null, null, "Bermuda" },
            //        { "BN", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(1963), true, false, null, null, "Brunei" },
            //        { "BO", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(1945), true, false, null, null, "Bolivia" },
            //        { "BQ", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(1947), true, false, null, null, "Bonaire" },
            //        { "BR", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(1956), true, false, null, null, "Brazil" },
            //        { "BS", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(1922), true, false, null, null, "Bahamas" },
            //        { "BT", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(1942), true, false, null, null, "Bhutan" },
            //        { "BV", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(1954), true, false, null, null, "Bouvet Island" },
            //        { "BW", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(1952), true, false, null, null, "Botswana" },
            //        { "BY", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(1931), true, false, null, null, "Belarus" },
            //        { "BZ", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(1936), true, false, null, null, "Belize" },
            //        { "CA", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(1979), true, false, null, null, "Canada" },
            //        { "CC", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(1997), true, false, null, null, "Cocos (Keeling) Islands" },
            //        { "CD", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2006), true, false, null, null, "Congo (DRC)" },
            //        { "CF", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(1984), true, false, null, null, "Central African Republic" },
            //        { "CG", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2004), true, false, null, null, "Congo" },
            //        { "CH", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2437), true, false, null, null, "Switzerland" },
            //        { "CI", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2013), true, false, null, null, "Côte d'Ivoire" },
            //        { "CK", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2008), true, false, null, null, "Cook Islands" },
            //        { "CL", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(1990), true, false, null, null, "Chile" },
            //        { "CM", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(1977), true, false, null, null, "Cameroon" },
            //        { "CN", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(1993), true, false, null, null, "China" },
            //        { "CO", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(1999), true, false, null, null, "Colombia" },
            //        { "CR", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2011), true, false, null, null, "Costa Rica" },
            //        { "CU", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2017), true, false, null, null, "Cuba" },
            //        { "CV", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(1972), true, false, null, null, "Cabo Verde" },
            //        { "CW", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2020), true, false, null, null, "Curaçao" },
            //        { "CX", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(1995), true, false, null, null, "Christmas Island" },
            //        { "CY", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2022), true, false, null, null, "Cyprus" },
            //        { "CZ", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(1988), true, false, null, null, "Czechia" },
            //        { "DE", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2110), true, false, null, null, "Germany" },
            //        { "DJ", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2027), true, false, null, null, "Djibouti" },
            //        { "DK", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2024), true, false, null, null, "Denmark" },
            //        { "DM", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2029), true, false, null, null, "Dominica" },
            //        { "DO", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2031), true, false, null, null, "Dominican Republic" },
            //        { "DZ", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(1894), true, false, null, null, "Algeria" },
            //        { "EC", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2034), true, false, null, null, "Ecuador" },
            //        { "EE", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2081), true, false, null, null, "Estonia" },
            //        { "EG", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2036), true, false, null, null, "Egypt" },
            //        { "ER", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2078), true, false, null, null, "Eritrea" },
            //        { "ES", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2421), true, false, null, null, "Spain" },
            //        { "ET", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2085), true, false, null, null, "Ethiopia" },
            //        { "FI", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2092), true, false, null, null, "Finland" },
            //        { "FJ", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2090), true, false, null, null, "Fiji" },
            //        { "FM", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2245), true, false, null, null, "Micronesia" },
            //        { "FO", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2087), true, false, null, null, "Faroe Islands" },
            //        { "FR", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2094), true, false, null, null, "France" },
            //        { "GA", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2103), true, false, null, null, "Gabon" },
            //        { "GB", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2480), true, false, null, null, "United Kingdom" },
            //        { "GD", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2122), true, false, null, null, "Grenada" },
            //        { "GE", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2108), true, false, null, null, "Georgia" },
            //        { "GF", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2097), true, false, null, null, "French Guiana" },
            //        { "GG", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2131), true, false, null, null, "Guernsey" },
            //        { "GH", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2112), true, false, null, null, "Ghana" },
            //        { "GI", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2115), true, false, null, null, "Gibraltar" },
            //        { "GL", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2119), true, false, null, null, "Greenland" },
            //        { "GM", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2106), true, false, null, null, "Gambia" },
            //        { "GN", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2133), true, false, null, null, "Guinea" },
            //        { "GP", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2124), true, false, null, null, "Guadeloupe" },
            //        { "GQ", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2076), true, false, null, null, "Equatorial Guinea" },
            //        { "GR", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2117), true, false, null, null, "Greece" },
            //        { "GS", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2417), true, false, null, null, "South Georgia and South Sandwich Islands" },
            //        { "GT", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2128), true, false, null, null, "Guatemala" },
            //        { "GU", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2126), true, false, null, null, "Guam" },
            //        { "GW", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2135), true, false, null, null, "Guinea-Bissau" },
            //        { "GY", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2137), true, false, null, null, "Guyana" },
            //        { "HK", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2147), true, false, null, null, "Hong Kong SAR" },
            //        { "HM", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2142), true, false, null, null, "Heard Island and McDonald Islands" },
            //        { "HN", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2145), true, false, null, null, "Honduras" },
            //        { "HR", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2015), true, false, null, null, "Croatia" },
            //        { "HT", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2140), true, false, null, null, "Haiti" },
            //        { "HU", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2149), true, false, null, null, "Hungary" },
            //        { "ID", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2156), true, false, null, null, "Indonesia" },
            //        { "IE", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2163), true, false, null, null, "Ireland" },
            //        { "IL", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2167), true, false, null, null, "Israel" },
            //        { "IM", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2165), true, false, null, null, "Isle of Man" },
            //        { "IN", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2154), true, false, null, null, "India" },
            //        { "IO", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(1958), true, false, null, null, "British Indian Ocean Territory" },
            //        { "IQ", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2161), true, false, null, null, "Iraq" },
            //        { "IR", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2158), true, false, null, null, "Iran" },
            //        { "IS", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2151), true, false, null, null, "Iceland" },
            //        { "IT", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2169), true, false, null, null, "Italy" },
            //        { "JE", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2176), true, false, null, null, "Jersey" },
            //        { "JM", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2172), true, false, null, null, "Jamaica" },
            //        { "JO", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2179), true, false, null, null, "Jordan" },
            //        { "JP", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2174), true, false, null, null, "Japan" },
            //        { "KE", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2183), true, false, null, null, "Kenya" },
            //        { "KG", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2192), true, false, null, null, "Kyrgyzstan" },
            //        { "KH", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(1974), true, false, null, null, "Cambodia" },
            //        { "KI", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2185), true, false, null, null, "Kiribati" },
            //        { "KM", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2002), true, false, null, null, "Comoros" },
            //        { "KN", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2370), true, false, null, null, "Saint Kitts and Nevis" },
            //        { "KP", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2318), true, false, null, null, "North Korea" },
            //        { "KR", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2188), true, false, null, null, "Korea (South)" },
            //        { "KW", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2190), true, false, null, null, "Kuwait" },
            //        { "KY", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(1981), true, false, null, null, "Cayman Islands" },
            //        { "KZ", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2181), true, false, null, null, "Kazakhstan" },
            //        { "LA", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2194), true, false, null, null, "Laos" },
            //        { "LB", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2199), true, false, null, null, "Lebanon" },
            //        { "LC", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2372), true, false, null, null, "Saint Lucia" },
            //        { "LI", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2208), true, false, null, null, "Liechtenstein" },
            //        { "LK", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2424), true, false, null, null, "Sri Lanka" },
            //        { "LR", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2203), true, false, null, null, "Liberia" },
            //        { "LS", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2201), true, false, null, null, "Lesotho" },
            //        { "LT", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2210), true, false, null, null, "Lithuania" },
            //        { "LU", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2212), true, false, null, null, "Luxembourg" },
            //        { "LV", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2197), true, false, null, null, "Latvia" },
            //        { "LY", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2206), true, false, null, null, "Libya" },
            //        { "MA", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2258), true, false, null, null, "Morocco" },
            //        { "MC", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2249), true, false, null, null, "Monaco" },
            //        { "MD", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2247), true, false, null, null, "Moldova" },
            //        { "ME", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2254), true, false, null, null, "Montenegro" },
            //        { "MF", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2375), true, false, null, null, "Saint Martin" },
            //        { "MG", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2217), true, false, null, null, "Madagascar" },
            //        { "MH", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2231), true, false, null, null, "Marshall Islands" },
            //        { "MK", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2323), true, false, null, null, "North Macedonia" },
            //        { "ML", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2226), true, false, null, null, "Mali" },
            //        { "MM", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2263), true, false, null, null, "Myanmar" },
            //        { "MN", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2252), true, false, null, null, "Mongolia" },
            //        { "MO", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2215), true, false, null, null, "Macao SAR" },
            //        { "MP", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2320), true, false, null, null, "Northern Mariana Islands" },
            //        { "MQ", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2233), true, false, null, null, "Martinique" },
            //        { "MR", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2235), true, false, null, null, "Mauritania" },
            //        { "MS", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2256), true, false, null, null, "Montserrat" },
            //        { "MT", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2228), true, false, null, null, "Malta" },
            //        { "MU", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2238), true, false, null, null, "Mauritius" },
            //        { "MV", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2224), true, false, null, null, "Maldives" },
            //        { "MW", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2219), true, false, null, null, "Malawi" },
            //        { "MX", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2242), true, false, null, null, "Mexico" },
            //        { "MY", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2222), true, false, null, null, "Malaysia" },
            //        { "MZ", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2260), true, false, null, null, "Mozambique" },
            //        { "NA", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2265), true, false, null, null, "Namibia" },
            //        { "NC", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2274), true, false, null, null, "New Caledonia" },
            //        { "NE", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2281), true, false, null, null, "Niger" },
            //        { "NF", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2316), true, false, null, null, "Norfolk Island" },
            //        { "NG", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2283), true, false, null, null, "Nigeria" },
            //        { "NI", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2279), true, false, null, null, "Nicaragua" },
            //        { "NL", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2272), true, false, null, null, "Netherlands" },
            //        { "NO", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2325), true, false, null, null, "Norway" },
            //        { "NP", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2270), true, false, null, null, "Nepal" },
            //        { "NR", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2267), true, false, null, null, "Nauru" },
            //        { "NU", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2285), true, false, null, null, "Niue" },
            //        { "NZ", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2276), true, false, null, null, "New Zealand" },
            //        { "OM", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2327), true, false, null, null, "Oman" },
            //        { "PA", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2336), true, false, null, null, "Panama" },
            //        { "PE", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2343), true, false, null, null, "Peru" },
            //        { "PF", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2099), true, false, null, null, "French Polynesia" },
            //        { "PG", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2338), true, false, null, null, "Papua New Guinea" },
            //        { "PH", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2345), true, false, null, null, "Philippines" },
            //        { "PK", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2329), true, false, null, null, "Pakistan" },
            //        { "PL", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2350), true, false, null, null, "Poland" },
            //        { "PM", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2377), true, false, null, null, "Saint Pierre and Miquelon" },
            //        { "PN", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2348), true, false, null, null, "Pitcairn Islands" },
            //        { "PR", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2354), true, false, null, null, "Puerto Rico" },
            //        { "PS", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2334), true, false, null, null, "Palestinian Authority" },
            //        { "PT", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2352), true, false, null, null, "Portugal" },
            //        { "PW", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2332), true, false, null, null, "Palau" },
            //        { "PY", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2341), true, false, null, null, "Paraguay" },
            //        { "QA", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2357), true, false, null, null, "Qatar" },
            //        { "RE", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2359), true, false, null, null, "Réunion" },
            //        { "RO", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2361), true, false, null, null, "Romania" },
            //        { "RS", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2393), true, false, null, null, "Serbia" },
            //        { "RU", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2363), true, false, null, null, "Russia" },
            //        { "RW", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2366), true, false, null, null, "Rwanda" },
            //        { "SA", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2388), true, false, null, null, "Saudi Arabia" },
            //        { "SB", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2410), true, false, null, null, "Solomon Islands" },
            //        { "SC", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2395), true, false, null, null, "Seychelles" },
            //        { "SD", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2428), true, false, null, null, "Sudan" },
            //        { "SE", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2435), true, false, null, null, "Sweden" },
            //        { "SG", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2400), true, false, null, null, "Singapore" },
            //        { "SH", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2426), true, false, null, null, "St Helena, Ascension, Tristan da Cunha" },
            //        { "SI", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2408), true, false, null, null, "Slovenia" },
            //        { "SJ", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2433), true, false, null, null, "Svalbard" },
            //        { "SK", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2404), true, false, null, null, "Slovakia" },
            //        { "SL", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2397), true, false, null, null, "Sierra Leone" },
            //        { "SM", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2384), true, false, null, null, "San Marino" },
            //        { "SN", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2391), true, false, null, null, "Senegal" },
            //        { "SO", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2412), true, false, null, null, "Somalia" },
            //        { "SR", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2430), true, false, null, null, "Suriname" },
            //        { "SS", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2419), true, false, null, null, "South Sudan" },
            //        { "ST", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2386), true, false, null, null, "São Tomé and Príncipe" },
            //        { "SV", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2074), true, false, null, null, "El Salvador" },
            //        { "SX", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2402), true, false, null, null, "Sint Maarten" },
            //        { "SY", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2439), true, false, null, null, "Syria" },
            //        { "SZ", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2083), true, false, null, null, "eSwatini" },
            //        { "TC", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2469), true, false, null, null, "Turks and Caicos Islands" },
            //        { "TD", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(1986), true, false, null, null, "Chad" },
            //        { "TF", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2101), true, false, null, null, "French Southern Territories" },
            //        { "TG", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2453), true, false, null, null, "Togo" },
            //        { "TH", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2448), true, false, null, null, "Thailand" },
            //        { "TJ", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2444), true, false, null, null, "Tajikistan" },
            //        { "TK", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2455), true, false, null, null, "Tokelau" },
            //        { "TL", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2451), true, false, null, null, "Timor-Leste" },
            //        { "TM", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2466), true, false, null, null, "Turkmenistan" },
            //        { "TN", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2462), true, false, null, null, "Tunisia" },
            //        { "TO", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2457), true, false, null, null, "Tonga" },
            //        { "TR", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2464), true, false, null, null, "Türkiye" },
            //        { "TT", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2460), true, false, null, null, "Trinidad and Tobago" },
            //        { "TV", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2471), true, false, null, null, "Tuvalu" },
            //        { "TW", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2442), true, false, null, null, "Taiwan" },
            //        { "TZ", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2446), true, false, null, null, "Tanzania" },
            //        { "UA", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2476), true, false, null, null, "Ukraine" },
            //        { "UG", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2473), true, false, null, null, "Uganda" },
            //        { "UM", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2487), true, false, null, null, "U.S. Outlying Islands" },
            //        { "US", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2482), true, false, null, null, "United States" },
            //        { "UY", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2485), true, false, null, null, "Uruguay" },
            //        { "UZ", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2491), true, false, null, null, "Uzbekistan" },
            //        { "VA", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2496), true, false, null, null, "Vatican City" },
            //        { "VC", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2379), true, false, null, null, "Saint Vincent and the Grenadines" },
            //        { "VE", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2498), true, false, null, null, "Venezuela" },
            //        { "VG", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(1961), true, false, null, null, "British Virgin Islands" },
            //        { "VI", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2489), true, false, null, null, "U.S. Virgin Islands" },
            //        { "VN", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2500), true, false, null, null, "Vietnam" },
            //        { "VU", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2494), true, false, null, null, "Vanuatu" },
            //        { "WF", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2502), true, false, null, null, "Wallis and Futuna" },
            //        { "WS", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2382), true, false, null, null, "Samoa" },
            //        { "YE", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2505), true, false, null, null, "Yemen" },
            //        { "YT", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2240), true, false, null, null, "Mayotte" },
            //        { "ZA", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2414), true, false, null, null, "South Africa" },
            //        { "ZM", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2507), true, false, null, null, "Zambia" },
            //        { "ZW", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2509), true, false, null, null, "Zimbabwe" }
            //    });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Code", "Action", "AppCode", "Controller", "CreatedBy", "CreatedOn", "IsActive", "IsDeleted", "ModifiedBy", "ModifiedOn", "Name", "Parent", "Sequence" },
                values: new object[,]
                {
                    { "BACKOPS", "Index", 2, "BackOps", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2927), true, false, null, null, "Back Ops", "", 60 },
                    { "CUSTOMERS", "Index", 2, "Customers", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2918), true, false, null, null, "Customers", "", 30 },
                    { "DASHBOARD", "Index", 2, "Home", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2912), true, false, null, null, "Dashboard", "", 10 },
                    { "MASTERS", "Index", 2, "Masters", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2921), true, false, null, null, "Masters", "", 40 },
                    { "ORDERS", "Index", 2, "Orders", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2915), true, false, null, null, "Orders", "", 20 },
                    { "SETTINGS", "Index", 2, "Settings", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2924), true, false, null, null, "Settings", "", 50 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Email", "CreatedBy", "CreatedOn", "FirstName", "IsActive", "IsDeleted", "LastName", "Mobile", "ModifiedBy", "ModifiedOn" },
                values: new object[] { "murali.kunapareddy@vendor.lgiglobal.com", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2024, 11, 5, 16, 55, 13, 269, DateTimeKind.Local).AddTicks(2878), "Murali Krishna", true, false, "KUNAPAREDDY", "+919916140646", null, null });

            migrationBuilder.CreateIndex(
                name: "IX_MasterItems_CustomerId",
                table: "MasterItems",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CountryCode",
                table: "Addresses",
                column: "CountryCode");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_BankAddressId",
                table: "Customer",
                column: "BankAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_BillToAddressId",
                table: "Customer",
                column: "BillToAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_BrokerAddressId",
                table: "Customer",
                column: "BrokerAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_CompanyCode",
                table: "Customer",
                column: "CompanyCode");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_DocsSendToAddressId",
                table: "Customer",
                column: "DocsSendToAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Incoterm2020Id",
                table: "Customer",
                column: "Incoterm2020Id");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_NotifyPartyAddressId",
                table: "Customer",
                column: "NotifyPartyAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_PaymentTermId",
                table: "Customer",
                column: "PaymentTermId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_ShipToAddressId",
                table: "Customer",
                column: "ShipToAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_UltimateConsgineeTypeId",
                table: "Customer",
                column: "UltimateConsgineeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAttachments_CustomerId",
                table: "CustomerAttachments",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPaperworks_CustomerId",
                table: "CustomerPaperworks",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPaperworks_PaperworkId",
                table: "CustomerPaperworks",
                column: "PaperworkId");

            migrationBuilder.AddForeignKey(
                name: "FK_MasterItems_Customer_CustomerId",
                table: "MasterItems",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MasterItems_Customer_CustomerId",
                table: "MasterItems");

            migrationBuilder.DropTable(
                name: "CustomerAttachments");

            migrationBuilder.DropTable(
                name: "CustomerPaperworks");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_MasterItems_CustomerId",
                table: "MasterItems");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "AD");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "AE");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "AF");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "AG");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "AL");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "AM");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "AO");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "AQ");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "AR");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "AS");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "AT");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "AU");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "AW");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "AX");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "AZ");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "BA");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "BB");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "BD");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "BE");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "BF");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "BG");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "BH");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "BI");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "BJ");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "BL");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "BM");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "BN");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "BO");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "BQ");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "BR");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "BS");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "BT");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "BV");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "BW");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "BY");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "BZ");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "CA");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "CC");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "CD");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "CF");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "CG");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "CH");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "CI");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "CK");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "CL");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "CM");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "CN");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "CO");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "CR");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "CU");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "CV");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "CW");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "CX");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "CY");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "CZ");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "DE");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "DJ");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "DK");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "DM");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "DO");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "DZ");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "EC");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "EE");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "EG");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "ER");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "ES");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "ET");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "FI");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "FJ");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "FM");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "FO");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "FR");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "GA");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "GB");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "GD");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "GE");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "GF");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "GG");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "GH");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "GI");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "GL");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "GM");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "GN");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "GP");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "GQ");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "GR");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "GS");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "GT");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "GU");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "GW");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "GY");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "HK");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "HM");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "HN");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "HR");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "HT");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "HU");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "ID");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "IE");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "IL");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "IM");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "IN");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "IO");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "IQ");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "IR");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "IS");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "IT");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "JE");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "JM");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "JO");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "JP");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "KE");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "KG");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "KH");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "KI");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "KM");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "KN");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "KP");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "KR");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "KW");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "KY");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "KZ");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "LA");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "LB");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "LC");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "LI");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "LK");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "LR");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "LS");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "LT");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "LU");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "LV");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "LY");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "MA");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "MC");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "MD");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "ME");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "MF");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "MG");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "MH");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "MK");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "ML");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "MM");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "MN");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "MO");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "MP");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "MQ");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "MR");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "MS");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "MT");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "MU");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "MV");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "MW");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "MX");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "MY");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "MZ");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "NA");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "NC");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "NE");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "NF");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "NG");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "NI");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "NL");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "NO");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "NP");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "NR");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "NU");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "NZ");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "OM");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "PA");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "PE");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "PF");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "PG");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "PH");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "PK");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "PL");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "PM");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "PN");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "PR");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "PS");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "PT");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "PW");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "PY");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "QA");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "RE");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "RO");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "RS");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "RU");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "RW");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "SA");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "SB");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "SC");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "SD");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "SE");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "SG");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "SH");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "SI");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "SJ");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "SK");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "SL");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "SM");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "SN");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "SO");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "SR");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "SS");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "ST");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "SV");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "SX");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "SY");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "SZ");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "TC");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "TD");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "TF");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "TG");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "TH");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "TJ");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "TK");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "TL");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "TM");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "TN");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "TO");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "TR");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "TT");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "TV");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "TW");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "TZ");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "UA");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "UG");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "UM");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "US");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "UY");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "UZ");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "VA");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "VC");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "VE");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "VG");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "VI");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "VN");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "VU");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "WF");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "WS");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "YE");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "YT");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "ZA");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "ZM");

            //migrationBuilder.DeleteData(
            //    table: "Countries",
            //    keyColumn: "Code",
            //    keyValue: "ZW");

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Code",
                keyValue: "BACKOPS");

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Code",
                keyValue: "CUSTOMERS");

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Code",
                keyValue: "DASHBOARD");

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Code",
                keyValue: "MASTERS");

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Code",
                keyValue: "ORDERS");

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Code",
                keyValue: "SETTINGS");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Email",
                keyValue: "murali.kunapareddy@vendor.lgiglobal.com");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "MasterItems");
        }
    }
}
