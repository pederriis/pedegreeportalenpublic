using Microsoft.EntityFrameworkCore.Migrations;

namespace MatingCalculator.Infrastructure.Migrations
{
    public partial class m40 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CalculatedDiseases_MatingCalculations_CalculatedDiseaseId",
                table: "CalculatedDiseases");

            migrationBuilder.CreateIndex(
                name: "IX_CalculatedDiseases_MatingCalculationId",
                table: "CalculatedDiseases",
                column: "MatingCalculationId");

            migrationBuilder.AddForeignKey(
                name: "FK_CalculatedDiseases_MatingCalculations_MatingCalculationId",
                table: "CalculatedDiseases",
                column: "MatingCalculationId",
                principalTable: "MatingCalculations",
                principalColumn: "MatingCalculationId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CalculatedDiseases_MatingCalculations_MatingCalculationId",
                table: "CalculatedDiseases");

            migrationBuilder.DropIndex(
                name: "IX_CalculatedDiseases_MatingCalculationId",
                table: "CalculatedDiseases");

            migrationBuilder.AddForeignKey(
                name: "FK_CalculatedDiseases_MatingCalculations_CalculatedDiseaseId",
                table: "CalculatedDiseases",
                column: "CalculatedDiseaseId",
                principalTable: "MatingCalculations",
                principalColumn: "MatingCalculationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
