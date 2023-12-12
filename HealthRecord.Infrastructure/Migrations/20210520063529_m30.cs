using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthRecord.Infrastructure.Migrations
{
    public partial class m30 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    AnimalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name_Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerId_Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted_Value = table.Column<bool>(type: "bit", nullable: true),
                    Id_Value = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.AnimalId);
                });

            migrationBuilder.CreateTable(
                name: "HealthRecord",
                columns: table => new
                {
                    HealthRecordId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnimalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id_Value = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthRecord", x => x.HealthRecordId);
                    table.ForeignKey(
                        name: "FK_HealthRecord_Animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "AnimalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Diseases",
                columns: table => new
                {
                    DiseaseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HealtRecordId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name_Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date_Value = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Note_Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Probability_Value = table.Column<double>(type: "float", nullable: true),
                    IsHereditary_Value = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted_Value = table.Column<bool>(type: "bit", nullable: true),
                    Id_Value = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diseases", x => x.DiseaseId);
                    table.ForeignKey(
                        name: "FK_Diseases_HealthRecord_HealtRecordId",
                        column: x => x.HealtRecordId,
                        principalTable: "HealthRecord",
                        principalColumn: "HealthRecordId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HealthCertificates",
                columns: table => new
                {
                    HealthCertificateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HealthRecordId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name_Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date_Value = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Note_Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted_Value = table.Column<bool>(type: "bit", nullable: true),
                    Id_Value = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthCertificates", x => x.HealthCertificateId);
                    table.ForeignKey(
                        name: "FK_HealthCertificates_HealthRecord_HealthRecordId",
                        column: x => x.HealthRecordId,
                        principalTable: "HealthRecord",
                        principalColumn: "HealthRecordId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vaccinations",
                columns: table => new
                {
                    VaccinationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HealthRecordId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name_Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date_Value = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted_Value = table.Column<bool>(type: "bit", nullable: true),
                    Id_Value = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vaccinations", x => x.VaccinationId);
                    table.ForeignKey(
                        name: "FK_Vaccinations_HealthRecord_HealthRecordId",
                        column: x => x.HealthRecordId,
                        principalTable: "HealthRecord",
                        principalColumn: "HealthRecordId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Diseases_HealtRecordId",
                table: "Diseases",
                column: "HealtRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthCertificates_HealthRecordId",
                table: "HealthCertificates",
                column: "HealthRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthRecord_AnimalId",
                table: "HealthRecord",
                column: "AnimalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vaccinations_HealthRecordId",
                table: "Vaccinations",
                column: "HealthRecordId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Diseases");

            migrationBuilder.DropTable(
                name: "HealthCertificates");

            migrationBuilder.DropTable(
                name: "Vaccinations");

            migrationBuilder.DropTable(
                name: "HealthRecord");

            migrationBuilder.DropTable(
                name: "Animals");
        }
    }
}
