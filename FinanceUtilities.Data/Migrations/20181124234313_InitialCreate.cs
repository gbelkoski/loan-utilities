using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinanceUtilities.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    NameEn = table.Column<string>(nullable: true),
                    Logo = table.Column<byte[]>(nullable: true),
                    LogoImageName = table.Column<string>(nullable: true),
                    LoanContactEmail = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    ContactPerson = table.Column<string>(nullable: true),
                    ContactPersonEmail = table.Column<string>(nullable: true),
                    ContactPersonPhoneNo = table.Column<string>(nullable: true),
                    Website = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true)
                },
                schema: "dbo",
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Code = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ExchangeRate = table.Column<decimal>(nullable: false)
                },
                schema: "dbo",
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "ExpenseTypes",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                schema: "dbo",
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoanTypes",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    NameEN = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DescriptionEN = table.Column<string>(nullable: true)
                },
                schema: "dbo",
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReferenceInterestRates",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DescriptionEn = table.Column<string>(nullable: true),
                    Rate = table.Column<decimal>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    TenorInMonths = table.Column<string>(nullable: true),
                    CurrencyCode = table.Column<string>(nullable: true)
                },
                schema: "dbo",
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReferenceInterestRates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReferenceInterestRates_Currencies_CurrencyCode",
                        column: x => x.CurrencyCode,
                        principalTable: "Currencies",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LoanProducts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    LoanTypeId = table.Column<string>(nullable: true),
                    BankId = table.Column<int>(nullable: false),
                    Link = table.Column<string>(nullable: true),
                    MinDuration = table.Column<int>(nullable: false),
                    MaxDuration = table.Column<int>(nullable: false),
                    MinimumAmount = table.Column<decimal>(nullable: false),
                    MaximumAmount = table.Column<decimal>(nullable: false),
                    CurrencyCode = table.Column<string>(nullable: true),
                    ParticipationPercentage = table.Column<decimal>(nullable: false),
                    Markup = table.Column<string>(type: "ntext", nullable: true),
                    MarkupDate = table.Column<DateTime>(nullable: true),
                    NewMarkup = table.Column<string>(type: "ntext", nullable: true),
                    NewMarkupDate = table.Column<DateTime>(nullable: true),
                    HasMarkupChanges = table.Column<bool>(nullable: false)
                },
                schema: "dbo",
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoanProducts_Banks_BankId",
                        column: x => x.BankId,
                        principalTable: "Banks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoanProducts_Currencies_CurrencyCode",
                        column: x => x.CurrencyCode,
                        principalTable: "Currencies",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LoanProducts_LoanTypes_LoanTypeId",
                        column: x => x.LoanTypeId,
                        principalTable: "LoanTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InterestPeriods",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderNo = table.Column<int>(nullable: false),
                    ReferenceInterestId = table.Column<string>(nullable: true),
                    Duration = table.Column<int>(nullable: false),
                    InterestPercentage = table.Column<decimal>(nullable: false),
                    IRType = table.Column<int>(nullable: false),
                    LoanProductId = table.Column<int>(nullable: false),
                    CurrencyCode = table.Column<string>(nullable: true),
                    IsBankClient = table.Column<bool>(nullable: false),
                    LoanAmountFrom = table.Column<decimal>(nullable: true),
                    LoanAmountTo = table.Column<decimal>(nullable: true),
                    DurationFrom = table.Column<int>(nullable: true),
                    DurationTo = table.Column<int>(nullable: true),
                    Minimum = table.Column<decimal>(nullable: false),
                    Maximum = table.Column<decimal>(nullable: false)
                },
                schema: "dbo",
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterestPeriods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InterestPeriods_Currencies_CurrencyCode",
                        column: x => x.CurrencyCode,
                        principalTable: "Currencies",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InterestPeriods_LoanProducts_LoanProductId",
                        column: x => x.LoanProductId,
                        principalTable: "LoanProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InterestPeriods_ReferenceInterestRates_ReferenceInterestId",
                        column: x => x.ReferenceInterestId,
                        principalTable: "ReferenceInterestRates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LoanProductExpenseTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LoanProductId = table.Column<int>(nullable: false),
                    ExpenseTypeId = table.Column<string>(nullable: true),
                    Percentage = table.Column<decimal>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    Reccuring = table.Column<bool>(nullable: false),
                    RecurmentType = table.Column<int>(nullable: false),
                    Minimum = table.Column<decimal>(nullable: false),
                    Maximum = table.Column<decimal>(nullable: false),
                    LoanAmountFrom = table.Column<decimal>(nullable: false),
                    LoanAmountTo = table.Column<decimal>(nullable: false),
                    IsBankClient = table.Column<bool>(nullable: false),
                    CurrencyCode = table.Column<string>(nullable: true),
                    DurationFrom = table.Column<int>(nullable: true),
                    DurationTo = table.Column<int>(nullable: true)
                },
                schema: "dbo",
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanProductExpenseTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoanProductExpenseTypes_Currencies_CurrencyCode",
                        column: x => x.CurrencyCode,
                        principalTable: "Currencies",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LoanProductExpenseTypes_ExpenseTypes_ExpenseTypeId",
                        column: x => x.ExpenseTypeId,
                        principalTable: "ExpenseTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LoanProductExpenseTypes_LoanProducts_LoanProductId",
                        column: x => x.LoanProductId,
                        principalTable: "LoanProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InterestPeriods_CurrencyCode",
                table: "InterestPeriods",
                column: "CurrencyCode");

            migrationBuilder.CreateIndex(
                name: "IX_InterestPeriods_LoanProductId",
                table: "InterestPeriods",
                column: "LoanProductId");

            migrationBuilder.CreateIndex(
                name: "IX_InterestPeriods_ReferenceInterestId",
                table: "InterestPeriods",
                column: "ReferenceInterestId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanProductExpenseTypes_CurrencyCode",
                table: "LoanProductExpenseTypes",
                column: "CurrencyCode");

            migrationBuilder.CreateIndex(
                name: "IX_LoanProductExpenseTypes_ExpenseTypeId",
                table: "LoanProductExpenseTypes",
                column: "ExpenseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanProductExpenseTypes_LoanProductId",
                table: "LoanProductExpenseTypes",
                column: "LoanProductId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanProducts_BankId",
                table: "LoanProducts",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanProducts_CurrencyCode",
                table: "LoanProducts",
                column: "CurrencyCode");

            migrationBuilder.CreateIndex(
                name: "IX_LoanProducts_LoanTypeId",
                table: "LoanProducts",
                column: "LoanTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ReferenceInterestRates_CurrencyCode",
                table: "ReferenceInterestRates",
                column: "CurrencyCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InterestPeriods");

            migrationBuilder.DropTable(
                name: "LoanProductExpenseTypes");

            migrationBuilder.DropTable(
                name: "ReferenceInterestRates");

            migrationBuilder.DropTable(
                name: "ExpenseTypes");

            migrationBuilder.DropTable(
                name: "LoanProducts");

            migrationBuilder.DropTable(
                name: "Banks");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "LoanTypes");
        }
    }
}
