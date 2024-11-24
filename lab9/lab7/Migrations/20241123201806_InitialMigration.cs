using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lab7.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ATMMachines",
                columns: table => new
                {
                    ATMId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ATMMachines", x => x.ATMId);
                });

            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    BankId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    AccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    MerchantCategoryCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Merchants", x => x.MerchantId);
                });

            migrationBuilder.CreateTable(
                name: "RefCardTypes",
                columns: table => new
                {
                    CardTypeCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    CurrencyCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CurrencyName = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    BankId = table.Column<int>(type: "int", nullable: false)
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
                    CardTypeCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrencyCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CardTypeCode1 = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CurrencyCode1 = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                        name: "FK_CardholdersCards_RefCardTypes_CardTypeCode1",
                        column: x => x.CardTypeCode1,
                        principalTable: "RefCardTypes",
                        principalColumn: "CardTypeCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CardholdersCards_RefCurrencyCodes_CurrencyCode1",
                        column: x => x.CurrencyCode1,
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
                    ATMId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CardNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MerchantId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrencyCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ATMId1 = table.Column<int>(type: "int", nullable: true),
                    CardNumber1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MerchantId1 = table.Column<int>(type: "int", nullable: true),
                    CurrencyCode1 = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialTransactions", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_FinancialTransactions_ATMMachines_ATMId1",
                        column: x => x.ATMId1,
                        principalTable: "ATMMachines",
                        principalColumn: "ATMId");
                    table.ForeignKey(
                        name: "FK_FinancialTransactions_CardholdersCards_CardNumber1",
                        column: x => x.CardNumber1,
                        principalTable: "CardholdersCards",
                        principalColumn: "CardNumber");
                    table.ForeignKey(
                        name: "FK_FinancialTransactions_Merchants_MerchantId1",
                        column: x => x.MerchantId1,
                        principalTable: "Merchants",
                        principalColumn: "MerchantId");
                    table.ForeignKey(
                        name: "FK_FinancialTransactions_RefCurrencyCodes_CurrencyCode1",
                        column: x => x.CurrencyCode1,
                        principalTable: "RefCurrencyCodes",
                        principalColumn: "CurrencyCode",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_CardholdersCards_CardTypeCode1",
                table: "CardholdersCards",
                column: "CardTypeCode1");

            migrationBuilder.CreateIndex(
                name: "IX_CardholdersCards_CurrencyCode1",
                table: "CardholdersCards",
                column: "CurrencyCode1");

            migrationBuilder.CreateIndex(
                name: "IX_FinancialTransactions_ATMId1",
                table: "FinancialTransactions",
                column: "ATMId1");

            migrationBuilder.CreateIndex(
                name: "IX_FinancialTransactions_CardNumber1",
                table: "FinancialTransactions",
                column: "CardNumber1");

            migrationBuilder.CreateIndex(
                name: "IX_FinancialTransactions_CurrencyCode1",
                table: "FinancialTransactions",
                column: "CurrencyCode1");

            migrationBuilder.CreateIndex(
                name: "IX_FinancialTransactions_MerchantId1",
                table: "FinancialTransactions",
                column: "MerchantId1");

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
                name: "ATMMachines");

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
