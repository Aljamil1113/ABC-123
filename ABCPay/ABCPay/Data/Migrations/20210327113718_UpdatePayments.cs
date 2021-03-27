using Microsoft.EntityFrameworkCore.Migrations;

namespace ABCPay.Data.Migrations
{
    public partial class UpdatePayments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentSends_Merchants_MerchantId",
                table: "PaymentSends");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentSends_Statuses_StatusId",
                table: "PaymentSends");

            migrationBuilder.DropIndex(
                name: "IX_PaymentSends_MerchantId",
                table: "PaymentSends");

            migrationBuilder.DropIndex(
                name: "IX_PaymentSends_StatusId",
                table: "PaymentSends");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Payments",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "PaymentId",
                table: "Payments");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Payments",
                table: "Payments",
                column: "ReferenceNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Payments",
                table: "Payments");

            migrationBuilder.AddColumn<int>(
                name: "PaymentId",
                table: "Payments",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Payments",
                table: "Payments",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentSends_MerchantId",
                table: "PaymentSends",
                column: "MerchantId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentSends_StatusId",
                table: "PaymentSends",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentSends_Merchants_MerchantId",
                table: "PaymentSends",
                column: "MerchantId",
                principalTable: "Merchants",
                principalColumn: "MerchantId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentSends_Statuses_StatusId",
                table: "PaymentSends",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
