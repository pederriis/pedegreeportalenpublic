using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MatingCalculator.Infrastructure.Migrations
{
    public partial class m25 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CalculatedDiseases",
                columns: table => new
                {
                    CalculatedDiseaseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MatingCalculationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name_Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Probability_Value = table.Column<double>(type: "float", nullable: true),
                    IsDeleted_Value = table.Column<bool>(type: "bit", nullable: true),
                    Id_Value = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalculatedDiseases", x => x.CalculatedDiseaseId);
                    table.ForeignKey(
                        name: "FK_CalculatedDiseases_MatingCalculations_CalculatedDiseaseId",
                        column: x => x.CalculatedDiseaseId,
                        principalTable: "MatingCalculations",
                        principalColumn: "MatingCalculationId",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CalculatedDiseases");
        }
    }
}
