using Microsoft.EntityFrameworkCore.Migrations;

namespace ABCPay.Data.Migrations
{
    public partial class removeUserIdFromPaymentSend : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentSends_AspNetUsers_UserId",
                table: "PaymentSends");

            migrationBuilder.DropIndex(
                name: "IX_PaymentSends_UserId",
                table: "PaymentSends");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "PaymentSends");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "PaymentSends",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PaymentSends_UserId",
                table: "PaymentSends",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentSends_AspNetUsers_UserId",
                table: "PaymentSends",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
