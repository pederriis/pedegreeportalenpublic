using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MatingCalculator.Infrastructure.Migrations
{
    public partial class m3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_MatingRules_MatingRulesId",
                table: "Contracts");

            migrationBuilder.DropForeignKey(
                name: "FK_MatingCalculations_Contracts_ContractId",
                table: "MatingCalculations");

            migrationBuilder.DropForeignKey(
                name: "FK_MatingCalculations_MatingRules_MatingRulesId",
                table: "MatingCalculations");

            migrationBuilder.DropIndex(
                name: "IX_MatingCalculations_ContractId",
                table: "MatingCalculations");

            migrationBuilder.DropIndex(
                name: "IX_Contracts_MatingRulesId",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "ContractId",
                table: "MatingCalculations");

            migrationBuilder.DropColumn(
                name: "ParentId_Value",
                table: "Dogs");

            migrationBuilder.RenameColumn(
                name: "MatingRulesId",
                table: "Contracts",
                newName: "MatingCalculationId");

            migrationBuilder.AlterColumn<Guid>(
                name: "MatingRulesId",
                table: "MatingCalculations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MatingCalculations_Contracts_MatingCalculationId",
                table: "MatingCalculations",
                column: "MatingCalculationId",
                principalTable: "Contracts",
                principalColumn: "ContractId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MatingCalculations_MatingRules_MatingRulesId",
                table: "MatingCalculations",
                column: "MatingRulesId",
                principalTable: "MatingRules",
                principalColumn: "MatingRulesId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatingCalculations_Contracts_MatingCalculationId",
                table: "MatingCalculations");

            migrationBuilder.DropForeignKey(
                name: "FK_MatingCalculations_MatingRules_MatingRulesId",
                table: "MatingCalculations");

            migrationBuilder.RenameColumn(
                name: "MatingCalculationId",
                table: "Contracts",
                newName: "MatingRulesId");

            migrationBuilder.AlterColumn<Guid>(
                name: "MatingRulesId",
                table: "MatingCalculations",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "ContractId",
                table: "MatingCalculations",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ParentId_Value",
                table: "Dogs",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MatingCalculations_ContractId",
                table: "MatingCalculations",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_MatingRulesId",
                table: "Contracts",
                column: "MatingRulesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_MatingRules_MatingRulesId",
                table: "Contracts",
                column: "MatingRulesId",
                principalTable: "MatingRules",
                principalColumn: "MatingRulesId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MatingCalculations_Contracts_ContractId",
                table: "MatingCalculations",
                column: "ContractId",
                principalTable: "Contracts",
                principalColumn: "ContractId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MatingCalculations_MatingRules_MatingRulesId",
                table: "MatingCalculations",
                column: "MatingRulesId",
                principalTable: "MatingRules",
                principalColumn: "MatingRulesId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
