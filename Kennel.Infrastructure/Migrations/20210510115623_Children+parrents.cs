using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kennel.Infrastructure.Migrations
{
    public partial class Childrenparrents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimalLitters");

            migrationBuilder.CreateTable(
                name: "Children",
                columns: table => new
                {
                    ChildId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnimalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LitterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted_Value = table.Column<bool>(type: "bit", nullable: true),
                    Id_Value = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Children", x => x.ChildId);
                    table.ForeignKey(
                        name: "FK_Children_Animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "AnimalId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Children_Litters_LitterId",
                        column: x => x.LitterId,
                        principalTable: "Litters",
                        principalColumn: "LitterId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Parrents",
                columns: table => new
                {
                    ParrentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnimalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LitterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted_Value = table.Column<bool>(type: "bit", nullable: true),
                    Id_Value = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parrents", x => x.ParrentId);
                    table.ForeignKey(
                        name: "FK_Parrents_Animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "AnimalId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Parrents_Litters_LitterId",
                        column: x => x.LitterId,
                        principalTable: "Litters",
                        principalColumn: "LitterId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Children_AnimalId",
                table: "Children",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_Children_LitterId",
                table: "Children",
                column: "LitterId");

            migrationBuilder.CreateIndex(
                name: "IX_Parrents_AnimalId",
                table: "Parrents",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_Parrents_LitterId",
                table: "Parrents",
                column: "LitterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Children");

            migrationBuilder.DropTable(
                name: "Parrents");

            migrationBuilder.CreateTable(
                name: "AnimalLitters",
                columns: table => new
                {
                    AnimalLitterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnimalId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LitterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Id_Value = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted_Value = table.Column<bool>(type: "bit", nullable: true)
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
    }
}
