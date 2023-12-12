using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MatingCalculator.Infrastructure.Migrations
{
    public partial class m19 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dogs_MatingCalculations_MatingCalculationId",
                table: "Dogs");

            migrationBuilder.DropIndex(
                name: "IX_Dogs_MatingCalculationId",
                table: "Dogs");

            migrationBuilder.DropColumn(
                name: "MatingCalculationId",
                table: "Dogs");

            migrationBuilder.CreateTable(
                name: "DogMatingCalculations",
                columns: table => new
                {
                    DogMatingCalculationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DogId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MatingCalculationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted_Value = table.Column<bool>(type: "bit", nullable: true),
                    Id_Value = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DogMatingCalculations", x => x.DogMatingCalculationId);
                    table.ForeignKey(
                        name: "FK_DogMatingCalculations_Dogs_DogId",
                        column: x => x.DogId,
                        principalTable: "Dogs",
                        principalColumn: "DogId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DogMatingCalculations_MatingCalculations_MatingCalculationId",
                        column: x => x.MatingCalculationId,
                        principalTable: "MatingCalculations",
                        principalColumn: "MatingCalculationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DogMatingCalculations_DogId",
                table: "DogMatingCalculations",
                column: "DogId");

            migrationBuilder.CreateIndex(
                name: "IX_DogMatingCalculations_MatingCalculationId",
                table: "DogMatingCalculations",
                column: "MatingCalculationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DogMatingCalculations");

            migrationBuilder.AddColumn<Guid>(
                name: "MatingCalculationId",
                table: "Dogs",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dogs_MatingCalculationId",
                table: "Dogs",
                column: "MatingCalculationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dogs_MatingCalculations_MatingCalculationId",
                table: "Dogs",
                column: "MatingCalculationId",
                principalTable: "MatingCalculations",
                principalColumn: "MatingCalculationId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
