using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class dbStructureChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CardDetailId",
                table: "PaymentHistory");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "CardDetails");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "CardDetails");

            migrationBuilder.DropColumn(
                name: "MerchantId",
                table: "CardDetails");

            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "PaymentHistory",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MerchantId",
                table: "PaymentHistory",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PaymentDetailId",
                table: "CardDetails",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "PaymentHistory");

            migrationBuilder.DropColumn(
                name: "MerchantId",
                table: "PaymentHistory");

            migrationBuilder.DropColumn(
                name: "PaymentDetailId",
                table: "CardDetails");

            migrationBuilder.AddColumn<int>(
                name: "CardDetailId",
                table: "PaymentHistory",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "CardDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "CardDetails",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "MerchantId",
                table: "CardDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
