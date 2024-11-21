using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lab6.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AtmMachines",
                columns: table => new
                {
                    AtmId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtmMachines", x => x.AtmId);
                });

            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    BankId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.BankId);
                });

            migrationBuilder.CreateTable(
                name: "Cardholders",
                columns: table => new
                {
                    CardholderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountNr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cardholders", x => x.CardholderId);
                });

            migrationBuilder.CreateTable(
                name: "Merchants",
                columns: table => new
                {
                    MerchantId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MerchantCategoryCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Merchants", x => x.MerchantId);
                });

            migrationBuilder.CreateTable(
                name: "RefCardTypes",
                columns: table => new
                {
                    CardTypeCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefCardTypes", x => x.CardTypeCode);
                });

            migrationBuilder.CreateTable(
                name: "RefCurrencyCodes",
                columns: table => new
                {
                    CurrencyCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefCurrencyCodes", x => x.CurrencyCode);
                });

            migrationBuilder.CreateTable(
                name: "CardholdersBanks",
                columns: table => new
                {
                    CardholderBankId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardholderId = table.Column<int>(type: "int", nullable: false),
                    BankId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardholdersBanks", x => x.CardholderBankId);
                    table.ForeignKey(
                        name: "FK_CardholdersBanks_Banks_BankId",
                        column: x => x.BankId,
                        principalTable: "Banks",
                        principalColumn: "BankId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CardholdersBanks_Cardholders_CardholderId",
                        column: x => x.CardholderId,
                        principalTable: "Cardholders",
                        principalColumn: "CardholderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MerchantsBanks",
                columns: table => new
                {
                    MerchantId = table.Column<int>(type: "int", nullable: false),
                    BankId = table.Column<int>(type: "int", nullable: false),
                    MerchantBankId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MerchantsBanks", x => new { x.MerchantId, x.BankId });
                    table.ForeignKey(
                        name: "FK_MerchantsBanks_Banks_BankId",
                        column: x => x.BankId,
                        principalTable: "Banks",
                        principalColumn: "BankId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MerchantsBanks_Merchants_MerchantId",
                        column: x => x.MerchantId,
                        principalTable: "Merchants",
                        principalColumn: "MerchantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CardholdersCards",
                columns: table => new
                {
                    CardNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CardholderId = table.Column<int>(type: "int", nullable: false),
                    CardTypeCode = table.Column<int>(type: "int", nullable: false),
                    CurrencyCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardholdersCards", x => x.CardNumber);
                    table.ForeignKey(
                        name: "FK_CardholdersCards_Cardholders_CardholderId",
                        column: x => x.CardholderId,
                        principalTable: "Cardholders",
                        principalColumn: "CardholderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CardholdersCards_RefCardTypes_CardTypeCode",
                        column: x => x.CardTypeCode,
                        principalTable: "RefCardTypes",
                        principalColumn: "CardTypeCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CardholdersCards_RefCurrencyCodes_CurrencyCode",
                        column: x => x.CurrencyCode,
                        principalTable: "RefCurrencyCodes",
                        principalColumn: "CurrencyCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FinancialTransactions",
                columns: table => new
                {
                    TransactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CardNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CurrencyCode = table.Column<int>(type: "int", nullable: false),
                    AtmId = table.Column<int>(type: "int", nullable: true),
                    MerchantId = table.Column<int>(type: "int", nullable: true),
                    TransactionTypeCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialTransactions", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_FinancialTransactions_AtmMachines_AtmId",
                        column: x => x.AtmId,
                        principalTable: "AtmMachines",
                        principalColumn: "AtmId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FinancialTransactions_CardholdersCards_CardNumber",
                        column: x => x.CardNumber,
                        principalTable: "CardholdersCards",
                        principalColumn: "CardNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FinancialTransactions_Merchants_MerchantId",
                        column: x => x.MerchantId,
                        principalTable: "Merchants",
                        principalColumn: "MerchantId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FinancialTransactions_RefCurrencyCodes_CurrencyCode",
                        column: x => x.CurrencyCode,
                        principalTable: "RefCurrencyCodes",
                        principalColumn: "CurrencyCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CardholdersBanks_BankId",
                table: "CardholdersBanks",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_CardholdersBanks_CardholderId",
                table: "CardholdersBanks",
                column: "CardholderId");

            migrationBuilder.CreateIndex(
                name: "IX_CardholdersCards_CardholderId",
                table: "CardholdersCards",
                column: "CardholderId");

            migrationBuilder.CreateIndex(
                name: "IX_CardholdersCards_CardTypeCode",
                table: "CardholdersCards",
                column: "CardTypeCode");

            migrationBuilder.CreateIndex(
                name: "IX_CardholdersCards_CurrencyCode",
                table: "CardholdersCards",
                column: "CurrencyCode");

            migrationBuilder.CreateIndex(
                name: "IX_FinancialTransactions_AtmId",
                table: "FinancialTransactions",
                column: "AtmId");

            migrationBuilder.CreateIndex(
                name: "IX_FinancialTransactions_CardNumber",
                table: "FinancialTransactions",
                column: "CardNumber");

            migrationBuilder.CreateIndex(
                name: "IX_FinancialTransactions_CurrencyCode",
                table: "FinancialTransactions",
                column: "CurrencyCode");

            migrationBuilder.CreateIndex(
                name: "IX_FinancialTransactions_MerchantId",
                table: "FinancialTransactions",
                column: "MerchantId");

            migrationBuilder.CreateIndex(
                name: "IX_MerchantsBanks_BankId",
                table: "MerchantsBanks",
                column: "BankId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CardholdersBanks");

            migrationBuilder.DropTable(
                name: "FinancialTransactions");

            migrationBuilder.DropTable(
                name: "MerchantsBanks");

            migrationBuilder.DropTable(
                name: "AtmMachines");

            migrationBuilder.DropTable(
                name: "CardholdersCards");

            migrationBuilder.DropTable(
                name: "Banks");

            migrationBuilder.DropTable(
                name: "Merchants");

            migrationBuilder.DropTable(
                name: "Cardholders");

            migrationBuilder.DropTable(
                name: "RefCardTypes");

            migrationBuilder.DropTable(
                name: "RefCurrencyCodes");
        }
    }
}
