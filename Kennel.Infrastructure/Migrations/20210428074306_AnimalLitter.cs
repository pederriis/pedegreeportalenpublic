using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kennel.Infrastructure.Migrations
{
    public partial class AnimalLitter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Litters_Animals_AnimalId",
                table: "Litters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Litters",
                table: "Litters");

            migrationBuilder.DropColumn(
                name: "AnimalId",
                table: "Litters");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Litters",
                table: "Litters",
                column: "LitterId");

            migrationBuilder.CreateTable(
                name: "AnimalLitters",
                columns: table => new
                {
                    AnimalLitterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnimalId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LitterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted_Value = table.Column<bool>(type: "bit", nullable: true),
                    Id_Value = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalLitters", x => x.AnimalLitterId);
                    table.ForeignKey(
                        name: "FK_AnimalLitters_Animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "AnimalId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AnimalLitters_Litters_LitterId",
                        column: x => x.LitterId,
                        principalTable: "Litters",
                        principalColumn: "LitterId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnimalLitters_AnimalId",
                table: "AnimalLitters",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimalLitters_LitterId",
                table: "AnimalLitters",
                column: "LitterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimalLitters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Litters",
                table: "Litters");

            migrationBuilder.AddColumn<Guid>(
                name: "AnimalId",
                table: "Litters",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Litters",
                table: "Litters",
                column: "AnimalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Litters_Animals_AnimalId",
                table: "Litters",
                column: "AnimalId",
                principalTable: "Animals",
                principalColumn: "AnimalId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
