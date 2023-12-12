using Microsoft.EntityFrameworkCore.Migrations;

namespace MatingCalculator.Infrastructure.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatingCalculations_Contracts_MatingCalculationId",
                table: "MatingCalculations");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_MatingCalculationId",
                table: "Contracts",
                column: "MatingCalculationId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_MatingCalculations_MatingCalculationId",
                table: "Contracts",
                column: "MatingCalculationId",
                principalTable: "MatingCalculations",
                principalColumn: "MatingCalculationId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_MatingCalculations_MatingCalculationId",
                table: "Contracts");

            migrationBuilder.DropIndex(
                name: "IX_Contracts_MatingCalculationId",
                table: "Contracts");

            migrationBuilder.AddForeignKey(
                name: "FK_MatingCalculations_Contracts_MatingCalculationId",
                table: "MatingCalculations",
                column: "MatingCalculationId",
                principalTable: "Contracts",
                principalColumn: "ContractId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
