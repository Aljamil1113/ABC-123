using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ABCPay.Data.Migrations
{
    public partial class RemoveOtherPaymentDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentSends");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PaymentSends",
                columns: table => new
                {
                    ReferenceNumber = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    AccountName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Client = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Customer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MerchantId = table.Column<int>(type: "int", nullable: false),
                    OtherDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PPRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceFee = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentSends", x => x.ReferenceNumber);
                });
        }
    }
}
