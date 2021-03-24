using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ABCPay.Data.Migrations
{
    public partial class addPaymentSend : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PaymentSends",
                columns: table => new
                {
                    ReferenceNumber = table.Column<string>(maxLength: 8, nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    AccountNumber = table.Column<string>(nullable: false),
                    AccountName = table.Column<string>(maxLength: 50, nullable: false),
                    OtherDetails = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ServiceFee = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PPRemarks = table.Column<string>(nullable: true),
                    Client = table.Column<string>(maxLength: 50, nullable: true),
                    Customer = table.Column<string>(maxLength: 50, nullable: true),
                    MerchantId = table.Column<int>(nullable: false),
                    StatusId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentSends", x => x.ReferenceNumber);
                    table.ForeignKey(
                        name: "FK_PaymentSends_Merchants_MerchantId",
                        column: x => x.MerchantId,
                        principalTable: "Merchants",
                        principalColumn: "MerchantId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaymentSends_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaymentSends_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PaymentSends_MerchantId",
                table: "PaymentSends",
                column: "MerchantId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentSends_StatusId",
                table: "PaymentSends",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentSends_UserId",
                table: "PaymentSends",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentSends");
        }
    }
}
