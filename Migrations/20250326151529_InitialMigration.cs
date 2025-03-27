using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WISSEN.EDA.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConfigurationItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Key = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Sequence = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfigurationItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Controller = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Action = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Sequence = table.Column<int>(type: "int", nullable: false),
                    AppCode = table.Column<int>(type: "int", maxLength: 2, nullable: false),
                    Parent = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Email);
                });

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
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                name: "Companies",
                columns: table => new
                {
                    Code = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AddressLine1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AddressLine2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    State = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CountryCode = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Zip = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Code);
                    table.ForeignKey(
                        name: "FK_Companies_Countries_CountryCode",
                        column: x => x.CountryCode,
                        principalTable: "Countries",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Authenticaions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    PasswordSalt = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    FailedAttempts = table.Column<int>(type: "int", nullable: false),
                    LastSuccessfulAttemptOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastFailedAttemptOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authenticaions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Authenticaions_Users_UserEmail",
                        column: x => x.UserEmail,
                        principalTable: "Users",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CompanyCode = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Companies_CompanyCode",
                        column: x => x.CompanyCode,
                        principalTable: "Companies",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
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
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerAttachments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerPaperworks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    PaperworkId = table.Column<int>(type: "int", nullable: false),
                    Required = table.Column<bool>(type: "bit", nullable: false),
                    OriginalQuantity = table.Column<int>(type: "int", nullable: false),
                    CopyQuantity = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerPaperworks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
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
                    CompanyCode = table.Column<int>(type: "int", nullable: false),
                    DocsSendToAddressId = table.Column<int>(type: "int", nullable: false),
                    DocSendToNotes = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
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
                    ImportPermitRequired = table.Column<bool>(type: "bit", nullable: false),
                    ImportPermitNotes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ExportComments = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    OldNotes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Addresses_BankAddressId",
                        column: x => x.BankAddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Customers_Addresses_BillToAddressId",
                        column: x => x.BillToAddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Customers_Addresses_BrokerAddressId",
                        column: x => x.BrokerAddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Customers_Addresses_DocsSendToAddressId",
                        column: x => x.DocsSendToAddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Customers_Addresses_NotifyPartyAddressId",
                        column: x => x.NotifyPartyAddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Customers_Addresses_ShipToAddressId",
                        column: x => x.ShipToAddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Customers_Companies_CompanyCode",
                        column: x => x.CompanyCode,
                        principalTable: "Companies",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "MasterItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Key = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Sequence = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MasterItems_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Code", "CreatedBy", "CreatedOn", "IsActive", "IsDeleted", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { "AD", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7492), true, false, null, null, "Andorra" },
                    { "AE", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7938), true, false, null, null, "United Arab Emirates" },
                    { "AF", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7484), true, false, null, null, "Afghanistan" },
                    { "AG", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7497), true, false, null, null, "Antigua and Barbuda" },
                    { "AL", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7488), true, false, null, null, "Albania" },
                    { "AM", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7500), true, false, null, null, "Armenia" },
                    { "AO", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7494), true, false, null, null, "Angola" },
                    { "AQ", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7495), true, false, null, null, "Antarctica" },
                    { "AR", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7498), true, false, null, null, "Argentina" },
                    { "AS", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7491), true, false, null, null, "American Samoa" },
                    { "AT", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7504), true, false, null, null, "Austria" },
                    { "AU", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7503), true, false, null, null, "Australia" },
                    { "AW", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7501), true, false, null, null, "Aruba" },
                    { "AX", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7486), true, false, null, null, "Åland Islands" },
                    { "AZ", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7506), true, false, null, null, "Azerbaijan" },
                    { "BA", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7549), true, false, null, null, "Bosnia and Herzegovina" },
                    { "BB", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7535), true, false, null, null, "Barbados" },
                    { "BD", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7534), true, false, null, null, "Bangladesh" },
                    { "BE", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7538), true, false, null, null, "Belgium" },
                    { "BF", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7561), true, false, null, null, "Burkina Faso" },
                    { "BG", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7559), true, false, null, null, "Bulgaria" },
                    { "BH", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7532), true, false, null, null, "Bahrain" },
                    { "BI", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7562), true, false, null, null, "Burundi" },
                    { "BJ", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7541), true, false, null, null, "Benin" },
                    { "BL", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7826), true, false, null, null, "Saint Barthélemy" },
                    { "BM", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7543), true, false, null, null, "Bermuda" },
                    { "BN", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7558), true, false, null, null, "Brunei" },
                    { "BO", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7546), true, false, null, null, "Bolivia" },
                    { "BQ", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7547), true, false, null, null, "Bonaire" },
                    { "BR", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7553), true, false, null, null, "Brazil" },
                    { "BS", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7507), true, false, null, null, "Bahamas" },
                    { "BT", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7544), true, false, null, null, "Bhutan" },
                    { "BV", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7552), true, false, null, null, "Bouvet Island" },
                    { "BW", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7550), true, false, null, null, "Botswana" },
                    { "BY", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7537), true, false, null, null, "Belarus" },
                    { "BZ", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7540), true, false, null, null, "Belize" },
                    { "CA", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7568), true, false, null, null, "Canada" },
                    { "CC", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7580), true, false, null, null, "Cocos (Keeling) Islands" },
                    { "CD", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7586), true, false, null, null, "Congo (DRC)" },
                    { "CF", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7571), true, false, null, null, "Central African Republic" },
                    { "CG", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7585), true, false, null, null, "Congo" },
                    { "CH", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7912), true, false, null, null, "Switzerland" },
                    { "CI", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7590), true, false, null, null, "Côte d'Ivoire" },
                    { "CK", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7587), true, false, null, null, "Cook Islands" },
                    { "CL", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7575), true, false, null, null, "Chile" },
                    { "CM", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7567), true, false, null, null, "Cameroon" },
                    { "CN", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7577), true, false, null, null, "China" },
                    { "CO", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7582), true, false, null, null, "Colombia" },
                    { "CR", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7589), true, false, null, null, "Costa Rica" },
                    { "CU", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7593), true, false, null, null, "Cuba" },
                    { "CV", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7564), true, false, null, null, "Cabo Verde" },
                    { "CW", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7595), true, false, null, null, "Curaçao" },
                    { "CX", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7579), true, false, null, null, "Christmas Island" },
                    { "CY", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7596), true, false, null, null, "Cyprus" },
                    { "CZ", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7574), true, false, null, null, "Czechia" },
                    { "DE", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7631), true, false, null, null, "Germany" },
                    { "DJ", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7599), true, false, null, null, "Djibouti" },
                    { "DK", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7598), true, false, null, null, "Denmark" },
                    { "DM", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7601), true, false, null, null, "Dominica" },
                    { "DO", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7602), true, false, null, null, "Dominican Republic" },
                    { "DZ", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7489), true, false, null, null, "Algeria" },
                    { "EC", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7604), true, false, null, null, "Ecuador" },
                    { "EE", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7611), true, false, null, null, "Estonia" },
                    { "EG", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7605), true, false, null, null, "Egypt" },
                    { "ER", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7610), true, false, null, null, "Eritrea" },
                    { "ES", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7901), true, false, null, null, "Spain" },
                    { "ET", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7614), true, false, null, null, "Ethiopia" },
                    { "FI", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7619), true, false, null, null, "Finland" },
                    { "FJ", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7617), true, false, null, null, "Fiji" },
                    { "FM", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7764), true, false, null, null, "Micronesia" },
                    { "FO", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7616), true, false, null, null, "Faroe Islands" },
                    { "FR", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7620), true, false, null, null, "France" },
                    { "GA", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7626), true, false, null, null, "Gabon" },
                    { "GB", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7940), true, false, null, null, "United Kingdom" },
                    { "GD", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7638), true, false, null, null, "Grenada" },
                    { "GE", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7629), true, false, null, null, "Georgia" },
                    { "GF", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7622), true, false, null, null, "French Guiana" },
                    { "GG", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7644), true, false, null, null, "Guernsey" },
                    { "GH", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7632), true, false, null, null, "Ghana" },
                    { "GI", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7633), true, false, null, null, "Gibraltar" },
                    { "GL", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7636), true, false, null, null, "Greenland" },
                    { "GM", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7628), true, false, null, null, "Gambia" },
                    { "GN", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7645), true, false, null, null, "Guinea" },
                    { "GP", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7639), true, false, null, null, "Guadeloupe" },
                    { "GQ", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7608), true, false, null, null, "Equatorial Guinea" },
                    { "GR", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7635), true, false, null, null, "Greece" },
                    { "GS", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7898), true, false, null, null, "South Georgia and South Sandwich Islands" },
                    { "GT", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7642), true, false, null, null, "Guatemala" },
                    { "GU", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7641), true, false, null, null, "Guam" },
                    { "GW", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7647), true, false, null, null, "Guinea-Bissau" },
                    { "GY", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7648), true, false, null, null, "Guyana" },
                    { "HK", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7654), true, false, null, null, "Hong Kong SAR" },
                    { "HM", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7651), true, false, null, null, "Heard Island and McDonald Islands" },
                    { "HN", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7653), true, false, null, null, "Honduras" },
                    { "HR", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7592), true, false, null, null, "Croatia" },
                    { "HT", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7650), true, false, null, null, "Haiti" },
                    { "HU", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7656), true, false, null, null, "Hungary" },
                    { "ID", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7660), true, false, null, null, "Indonesia" },
                    { "IE", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7665), true, false, null, null, "Ireland" },
                    { "IL", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7713), true, false, null, null, "Israel" },
                    { "IM", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7712), true, false, null, null, "Isle of Man" },
                    { "IN", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7659), true, false, null, null, "India" },
                    { "IO", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7555), true, false, null, null, "British Indian Ocean Territory" },
                    { "IQ", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7663), true, false, null, null, "Iraq" },
                    { "IR", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7662), true, false, null, null, "Iran" },
                    { "IS", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7657), true, false, null, null, "Iceland" },
                    { "IT", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7715), true, false, null, null, "Italy" },
                    { "JE", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7719), true, false, null, null, "Jersey" },
                    { "JM", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7716), true, false, null, null, "Jamaica" },
                    { "JO", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7721), true, false, null, null, "Jordan" },
                    { "JP", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7718), true, false, null, null, "Japan" },
                    { "KE", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7724), true, false, null, null, "Kenya" },
                    { "KG", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7730), true, false, null, null, "Kyrgyzstan" },
                    { "KH", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7565), true, false, null, null, "Cambodia" },
                    { "KI", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7725), true, false, null, null, "Kiribati" },
                    { "KM", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7583), true, false, null, null, "Comoros" },
                    { "KN", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7828), true, false, null, null, "Saint Kitts and Nevis" },
                    { "KP", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7793), true, false, null, null, "North Korea" },
                    { "KR", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7727), true, false, null, null, "Korea (South)" },
                    { "KW", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7728), true, false, null, null, "Kuwait" },
                    { "KY", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7570), true, false, null, null, "Cayman Islands" },
                    { "KZ", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7722), true, false, null, null, "Kazakhstan" },
                    { "LA", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7731), true, false, null, null, "Laos" },
                    { "LB", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7734), true, false, null, null, "Lebanon" },
                    { "LC", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7829), true, false, null, null, "Saint Lucia" },
                    { "LI", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7740), true, false, null, null, "Liechtenstein" },
                    { "LK", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7903), true, false, null, null, "Sri Lanka" },
                    { "LR", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7737), true, false, null, null, "Liberia" },
                    { "LS", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7736), true, false, null, null, "Lesotho" },
                    { "LT", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7742), true, false, null, null, "Lithuania" },
                    { "LU", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7743), true, false, null, null, "Luxembourg" },
                    { "LV", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7733), true, false, null, null, "Latvia" },
                    { "LY", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7739), true, false, null, null, "Libya" },
                    { "MA", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7773), true, false, null, null, "Morocco" },
                    { "MC", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7767), true, false, null, null, "Monaco" },
                    { "MD", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7765), true, false, null, null, "Moldova" },
                    { "ME", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7770), true, false, null, null, "Montenegro" },
                    { "MF", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7830), true, false, null, null, "Saint Martin" },
                    { "MG", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7746), true, false, null, null, "Madagascar" },
                    { "MH", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7755), true, false, null, null, "Marshall Islands" },
                    { "MK", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7796), true, false, null, null, "North Macedonia" },
                    { "ML", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7752), true, false, null, null, "Mali" },
                    { "MM", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7776), true, false, null, null, "Myanmar" },
                    { "MN", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7768), true, false, null, null, "Mongolia" },
                    { "MO", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7745), true, false, null, null, "Macao SAR" },
                    { "MP", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7795), true, false, null, null, "Northern Mariana Islands" },
                    { "MQ", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7756), true, false, null, null, "Martinique" },
                    { "MR", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7758), true, false, null, null, "Mauritania" },
                    { "MS", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7771), true, false, null, null, "Montserrat" },
                    { "MT", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7753), true, false, null, null, "Malta" },
                    { "MU", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7759), true, false, null, null, "Mauritius" },
                    { "MV", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7750), true, false, null, null, "Maldives" },
                    { "MW", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7747), true, false, null, null, "Malawi" },
                    { "MX", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7762), true, false, null, null, "Mexico" },
                    { "MY", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7749), true, false, null, null, "Malaysia" },
                    { "MZ", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7774), true, false, null, null, "Mozambique" },
                    { "NA", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7777), true, false, null, null, "Namibia" },
                    { "NC", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7783), true, false, null, null, "New Caledonia" },
                    { "NE", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7788), true, false, null, null, "Niger" },
                    { "NF", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7792), true, false, null, null, "Norfolk Island" },
                    { "NG", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7789), true, false, null, null, "Nigeria" },
                    { "NI", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7786), true, false, null, null, "Nicaragua" },
                    { "NL", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7781), true, false, null, null, "Netherlands" },
                    { "NO", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7798), true, false, null, null, "Norway" },
                    { "NP", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7780), true, false, null, null, "Nepal" },
                    { "NR", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7778), true, false, null, null, "Nauru" },
                    { "NU", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7790), true, false, null, null, "Niue" },
                    { "NZ", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7784), true, false, null, null, "New Zealand" },
                    { "OM", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7799), true, false, null, null, "Oman" },
                    { "PA", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7805), true, false, null, null, "Panama" },
                    { "PE", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7810), true, false, null, null, "Peru" },
                    { "PF", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7623), true, false, null, null, "French Polynesia" },
                    { "PG", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7807), true, false, null, null, "Papua New Guinea" },
                    { "PH", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7811), true, false, null, null, "Philippines" },
                    { "PK", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7801), true, false, null, null, "Pakistan" },
                    { "PL", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7814), true, false, null, null, "Poland" },
                    { "PM", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7832), true, false, null, null, "Saint Pierre and Miquelon" },
                    { "PN", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7813), true, false, null, null, "Pitcairn Islands" },
                    { "PR", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7817), true, false, null, null, "Puerto Rico" },
                    { "PS", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7804), true, false, null, null, "Palestinian Authority" },
                    { "PT", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7816), true, false, null, null, "Portugal" },
                    { "PW", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7802), true, false, null, null, "Palau" },
                    { "PY", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7808), true, false, null, null, "Paraguay" },
                    { "QA", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7819), true, false, null, null, "Qatar" },
                    { "RE", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7820), true, false, null, null, "Réunion" },
                    { "RO", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7822), true, false, null, null, "Romania" },
                    { "RS", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7842), true, false, null, null, "Serbia" },
                    { "RU", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7823), true, false, null, null, "Russia" },
                    { "RW", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7825), true, false, null, null, "Rwanda" },
                    { "SA", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7839), true, false, null, null, "Saudi Arabia" },
                    { "SB", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7894), true, false, null, null, "Solomon Islands" },
                    { "SC", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7844), true, false, null, null, "Seychelles" },
                    { "SD", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7906), true, false, null, null, "Sudan" },
                    { "SE", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7910), true, false, null, null, "Sweden" },
                    { "SG", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7847), true, false, null, null, "Singapore" },
                    { "SH", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7904), true, false, null, null, "St Helena, Ascension, Tristan da Cunha" },
                    { "SI", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7892), true, false, null, null, "Slovenia" },
                    { "SJ", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7909), true, false, null, null, "Svalbard" },
                    { "SK", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7850), true, false, null, null, "Slovakia" },
                    { "SL", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7845), true, false, null, null, "Sierra Leone" },
                    { "SM", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7836), true, false, null, null, "San Marino" },
                    { "SN", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7841), true, false, null, null, "Senegal" },
                    { "SO", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7895), true, false, null, null, "Somalia" },
                    { "SR", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7907), true, false, null, null, "Suriname" },
                    { "SS", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7900), true, false, null, null, "South Sudan" },
                    { "ST", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7838), true, false, null, null, "São Tomé and Príncipe" },
                    { "SV", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7607), true, false, null, null, "El Salvador" },
                    { "SX", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7848), true, false, null, null, "Sint Maarten" },
                    { "SY", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7913), true, false, null, null, "Syria" },
                    { "SZ", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7613), true, false, null, null, "eSwatini" },
                    { "TC", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7933), true, false, null, null, "Turks and Caicos Islands" },
                    { "TD", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7573), true, false, null, null, "Chad" },
                    { "TF", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7625), true, false, null, null, "French Southern Territories" },
                    { "TG", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7922), true, false, null, null, "Togo" },
                    { "TH", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7919), true, false, null, null, "Thailand" },
                    { "TJ", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7916), true, false, null, null, "Tajikistan" },
                    { "TK", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7924), true, false, null, null, "Tokelau" },
                    { "TL", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7921), true, false, null, null, "Timor-Leste" },
                    { "TM", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7931), true, false, null, null, "Turkmenistan" },
                    { "TN", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7928), true, false, null, null, "Tunisia" },
                    { "TO", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7925), true, false, null, null, "Tonga" },
                    { "TR", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7930), true, false, null, null, "Türkiye" },
                    { "TT", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7927), true, false, null, null, "Trinidad and Tobago" },
                    { "TV", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7934), true, false, null, null, "Tuvalu" },
                    { "TW", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7915), true, false, null, null, "Taiwan" },
                    { "TZ", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7918), true, false, null, null, "Tanzania" },
                    { "UA", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7937), true, false, null, null, "Ukraine" },
                    { "UG", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7936), true, false, null, null, "Uganda" },
                    { "UM", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7944), true, false, null, null, "U.S. Outlying Islands" },
                    { "US", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7941), true, false, null, null, "United States" },
                    { "UY", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7943), true, false, null, null, "Uruguay" },
                    { "UZ", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7947), true, false, null, null, "Uzbekistan" },
                    { "VA", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7950), true, false, null, null, "Vatican City" },
                    { "VC", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7833), true, false, null, null, "Saint Vincent and the Grenadines" },
                    { "VE", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7952), true, false, null, null, "Venezuela" },
                    { "VG", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7556), true, false, null, null, "British Virgin Islands" },
                    { "VI", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7946), true, false, null, null, "U.S. Virgin Islands" },
                    { "VN", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7953), true, false, null, null, "Vietnam" },
                    { "VU", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7949), true, false, null, null, "Vanuatu" },
                    { "WF", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7955), true, false, null, null, "Wallis and Futuna" },
                    { "WS", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7835), true, false, null, null, "Samoa" },
                    { "YE", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7956), true, false, null, null, "Yemen" },
                    { "YT", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7761), true, false, null, null, "Mayotte" },
                    { "ZA", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7897), true, false, null, null, "South Africa" },
                    { "ZM", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7958), true, false, null, null, "Zambia" },
                    { "ZW", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(7959), true, false, null, null, "Zimbabwe" }
                });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Code", "Action", "AppCode", "Controller", "CreatedBy", "CreatedOn", "IsActive", "IsDeleted", "ModifiedBy", "ModifiedOn", "Name", "Parent", "Sequence" },
                values: new object[,]
                {
                    { "BACKOPS", "Index", 2, "BackOps", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(8264), true, false, null, null, "Back Ops", "", 60 },
                    { "CUSTOMERS", "Index", 2, "Customers", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(8258), true, false, null, null, "Customers", "", 30 },
                    { "DASHBOARD", "Index", 2, "Home", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(8253), true, false, null, null, "Dashboard", "", 10 },
                    { "MASTERS", "Index", 2, "Masters", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(8260), true, false, null, null, "Masters", "", 40 },
                    { "ORDERS", "Index", 2, "Orders", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(8256), true, false, null, null, "Orders", "", 20 },
                    { "SETTINGS", "Index", 2, "Settings", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(8262), true, false, null, null, "Settings", "", 50 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Email", "CreatedBy", "CreatedOn", "FirstName", "IsActive", "IsDeleted", "LastName", "Mobile", "ModifiedBy", "ModifiedOn" },
                values: new object[] { "murali.kunapareddy@vendor.lgiglobal.com", "murali.kunapareddy@vendor.lgiglobal.com", new DateTime(2025, 3, 26, 20, 45, 28, 583, DateTimeKind.Local).AddTicks(8220), "Murali Krishna", true, false, "KUNAPAREDDY", "+919916140646", null, null });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CountryCode",
                table: "Addresses",
                column: "CountryCode");

            migrationBuilder.CreateIndex(
                name: "IX_Authenticaions_UserEmail",
                table: "Authenticaions",
                column: "UserEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_CountryCode",
                table: "Companies",
                column: "CountryCode");

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

            migrationBuilder.CreateIndex(
                name: "IX_Customers_BankAddressId",
                table: "Customers",
                column: "BankAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_BillToAddressId",
                table: "Customers",
                column: "BillToAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_BrokerAddressId",
                table: "Customers",
                column: "BrokerAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CompanyCode",
                table: "Customers",
                column: "CompanyCode");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_DocsSendToAddressId",
                table: "Customers",
                column: "DocsSendToAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Incoterm2020Id",
                table: "Customers",
                column: "Incoterm2020Id");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_NotifyPartyAddressId",
                table: "Customers",
                column: "NotifyPartyAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_PaymentTermId",
                table: "Customers",
                column: "PaymentTermId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_ShipToAddressId",
                table: "Customers",
                column: "ShipToAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_UltimateConsgineeTypeId",
                table: "Customers",
                column: "UltimateConsgineeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterItems_CustomerId",
                table: "MasterItems",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CompanyCode",
                table: "Products",
                column: "CompanyCode");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerAttachments_Customers_CustomerId",
                table: "CustomerAttachments",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerPaperworks_Customers_CustomerId",
                table: "CustomerPaperworks",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerPaperworks_MasterItems_PaperworkId",
                table: "CustomerPaperworks",
                column: "PaperworkId",
                principalTable: "MasterItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_MasterItems_Incoterm2020Id",
                table: "Customers",
                column: "Incoterm2020Id",
                principalTable: "MasterItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_MasterItems_PaymentTermId",
                table: "Customers",
                column: "PaymentTermId",
                principalTable: "MasterItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_MasterItems_UltimateConsgineeTypeId",
                table: "Customers",
                column: "UltimateConsgineeTypeId",
                principalTable: "MasterItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Countries_CountryCode",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Countries_CountryCode",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_MasterItems_Customers_CustomerId",
                table: "MasterItems");

            migrationBuilder.DropTable(
                name: "Authenticaions");

            migrationBuilder.DropTable(
                name: "ConfigurationItems");

            migrationBuilder.DropTable(
                name: "CustomerAttachments");

            migrationBuilder.DropTable(
                name: "CustomerPaperworks");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "MasterItems");
        }
    }
}
