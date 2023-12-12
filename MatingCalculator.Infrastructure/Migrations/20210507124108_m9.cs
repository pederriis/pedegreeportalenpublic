using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MatingCalculator.Infrastructure.Migrations
{
    public partial class m9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Userinformations_Contracts_ContractId",
                table: "Userinformations");

            migrationBuilder.DropIndex(
                name: "IX_Userinformations_ContractId",
                table: "Userinformations");

            migrationBuilder.DropColumn(
                name: "ContractId",
                table: "Userinformations");

            migrationBuilder.CreateTable(
                name: "ContractUserinformations",
                columns: table => new
                {
                    ContractUserinformationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContractId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserinformationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted_Value = table.Column<bool>(type: "bit", nullable: true),
                    Id_Value = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractUserinformations", x => x.ContractUserinformationId);
                    table.ForeignKey(
                        name: "FK_ContractUserinformations_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "ContractId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContractUserinformations_Userinformations_UserinformationId",
                        column: x => x.UserinformationId,
                        principalTable: "Userinformations",
                        principalColumn: "UserinformationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContractUserinformations_ContractId",
                table: "ContractUserinformations",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractUserinformations_UserinformationId",
                table: "ContractUserinformations",
                column: "UserinformationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContractUserinformations");

            migrationBuilder.AddColumn<Guid>(
                name: "ContractId",
                table: "Userinformations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Userinformations_ContractId",
                table: "Userinformations",
                column: "ContractId");

            migrationBuilder.AddForeignKey(
                name: "FK_Userinformations_Contracts_ContractId",
                table: "Userinformations",
                column: "ContractId",
                principalTable: "Contracts",
                principalColumn: "ContractId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
