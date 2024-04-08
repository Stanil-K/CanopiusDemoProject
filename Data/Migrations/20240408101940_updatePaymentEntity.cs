using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class updatePaymentEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Policies_PolicyID",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_PolicyID",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "PolicyID",
                table: "Payments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PolicyID",
                table: "Payments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Payments_PolicyID",
                table: "Payments",
                column: "PolicyID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Policies_PolicyID",
                table: "Payments",
                column: "PolicyID",
                principalTable: "Policies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
