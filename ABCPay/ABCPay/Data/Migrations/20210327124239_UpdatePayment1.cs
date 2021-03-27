using Microsoft.EntityFrameworkCore.Migrations;

namespace ABCPay.Data.Migrations
{
    public partial class UpdatePayment1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Client",
                table: "Payments",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Customer",
                table: "Payments",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Client",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "Customer",
                table: "Payments");
        }
    }
}
