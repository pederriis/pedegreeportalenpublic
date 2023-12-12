using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MatingCalculator.Infrastructure.Migrations
{
    public partial class m7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dogs_MatingCalculations_MatingCalculationId",
                table: "Dogs");

            migrationBuilder.AlterColumn<Guid>(
                name: "MatingCalculationId",
                table: "Dogs",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Dogs_MatingCalculations_MatingCalculationId",
                table: "Dogs",
                column: "MatingCalculationId",
                principalTable: "MatingCalculations",
                principalColumn: "MatingCalculationId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dogs_MatingCalculations_MatingCalculationId",
                table: "Dogs");

            migrationBuilder.AlterColumn<Guid>(
                name: "MatingCalculationId",
                table: "Dogs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Dogs_MatingCalculations_MatingCalculationId",
                table: "Dogs",
                column: "MatingCalculationId",
                principalTable: "MatingCalculations",
                principalColumn: "MatingCalculationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
