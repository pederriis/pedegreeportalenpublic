using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MatingCalculator.Infrastructure.Migrations
{
    public partial class _33 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diseases_Dogs_DogId",
                table: "Diseases");

            migrationBuilder.RenameColumn(
                name: "DogId",
                table: "Diseases",
                newName: "HealthRecordId");

            migrationBuilder.RenameIndex(
                name: "IX_Diseases_DogId",
                table: "Diseases",
                newName: "IX_Diseases_HealthRecordId");

            migrationBuilder.CreateTable(
                name: "HealthRecords",
                columns: table => new
                {
                    HealthRecordId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DogId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted_Value = table.Column<bool>(type: "bit", nullable: true),
                    Id_Value = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthRecords", x => x.HealthRecordId);
                    table.ForeignKey(
                        name: "FK_HealthRecords_Dogs_DogId",
                        column: x => x.DogId,
                        principalTable: "Dogs",
                        principalColumn: "DogId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HealthRecords_DogId",
                table: "HealthRecords",
                column: "DogId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Diseases_HealthRecords_HealthRecordId",
                table: "Diseases",
                column: "HealthRecordId",
                principalTable: "HealthRecords",
                principalColumn: "HealthRecordId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diseases_HealthRecords_HealthRecordId",
                table: "Diseases");

            migrationBuilder.DropTable(
                name: "HealthRecords");

            migrationBuilder.RenameColumn(
                name: "HealthRecordId",
                table: "Diseases",
                newName: "DogId");

            migrationBuilder.RenameIndex(
                name: "IX_Diseases_HealthRecordId",
                table: "Diseases",
                newName: "IX_Diseases_DogId");

            migrationBuilder.AddForeignKey(
                name: "FK_Diseases_Dogs_DogId",
                table: "Diseases",
                column: "DogId",
                principalTable: "Dogs",
                principalColumn: "DogId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
