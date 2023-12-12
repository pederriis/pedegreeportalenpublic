using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MatingCalculator.Infrastructure.Migrations
{
    public partial class m1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Litters",
                columns: table => new
                {
                    LitterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name_Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date_Value = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted_Value = table.Column<bool>(type: "bit", nullable: true),
                    Id_Value = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Litters", x => x.LitterId);
                });

            migrationBuilder.CreateTable(
                name: "MatingRules",
                columns: table => new
                {
                    MatingRulesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InbreedingPercent_Value = table.Column<double>(type: "float", nullable: true),
                    LitterAmount_Value = table.Column<int>(type: "int", nullable: true),
                    IsDeleted_Value = table.Column<bool>(type: "bit", nullable: true),
                    Id_Value = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatingRules", x => x.MatingRulesId);
                });

            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    ContractId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MatingRulesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaleDogName_Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FemaleDogName_Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaleDogOwnerName_Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FemaleDogOwnerName_Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate_Value = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MatingDate_Value = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted_Value = table.Column<bool>(type: "bit", nullable: true),
                    Id_Value = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.ContractId);
                    table.ForeignKey(
                        name: "FK_Contracts_MatingRules_MatingRulesId",
                        column: x => x.MatingRulesId,
                        principalTable: "MatingRules",
                        principalColumn: "MatingRulesId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MatingCalculations",
                columns: table => new
                {
                    MatingCalculationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExpectedChildren_Value = table.Column<int>(type: "int", nullable: true),
                    InbreedingPercent_Value = table.Column<double>(type: "float", nullable: true),
                    IsLegal_Value = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted_Value = table.Column<bool>(type: "bit", nullable: true),
                    LitterAmount_Value = table.Column<int>(type: "int", nullable: true),
                    ContractId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MatingRulesId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Id_Value = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatingCalculations", x => x.MatingCalculationId);
                    table.ForeignKey(
                        name: "FK_MatingCalculations_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "ContractId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MatingCalculations_MatingRules_MatingRulesId",
                        column: x => x.MatingRulesId,
                        principalTable: "MatingRules",
                        principalColumn: "MatingRulesId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Userinformations",
                columns: table => new
                {
                    UserinformationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContractId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email_Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name_Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNo_Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted_Value = table.Column<bool>(type: "bit", nullable: true),
                    Id_Value = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Userinformations", x => x.UserinformationId);
                    table.ForeignKey(
                        name: "FK_Userinformations_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "ContractId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dogs",
                columns: table => new
                {
                    DogId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MatingCalculationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParentId_Value = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RaceId_Value = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SubdRaceId_Value = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ChildAmount_Value = table.Column<int>(type: "int", nullable: true),
                    Gender_Value = table.Column<bool>(type: "bit", nullable: true),
                    Name_Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted_Value = table.Column<bool>(type: "bit", nullable: true),
                    Id_Value = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dogs", x => x.DogId);
                    table.ForeignKey(
                        name: "FK_Dogs_MatingCalculations_MatingCalculationId",
                        column: x => x.MatingCalculationId,
                        principalTable: "MatingCalculations",
                        principalColumn: "MatingCalculationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Diseases",
                columns: table => new
                {
                    DiseaseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DogId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name_Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date_Value = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Note_Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsHereditary_Value = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted_Value = table.Column<bool>(type: "bit", nullable: true),
                    Id_Value = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diseases", x => x.DiseaseId);
                    table.ForeignKey(
                        name: "FK_Diseases_Dogs_DogId",
                        column: x => x.DogId,
                        principalTable: "Dogs",
                        principalColumn: "DogId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DogLitters",
                columns: table => new
                {
                    DogLitterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DogId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LitterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted_Value = table.Column<bool>(type: "bit", nullable: true),
                    Id_Value = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DogLitters", x => x.DogLitterId);
                    table.ForeignKey(
                        name: "FK_DogLitters_Dogs_DogId",
                        column: x => x.DogId,
                        principalTable: "Dogs",
                        principalColumn: "DogId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DogLitters_Litters_LitterId",
                        column: x => x.LitterId,
                        principalTable: "Litters",
                        principalColumn: "LitterId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_MatingRulesId",
                table: "Contracts",
                column: "MatingRulesId");

            migrationBuilder.CreateIndex(
                name: "IX_Diseases_DogId",
                table: "Diseases",
                column: "DogId");

            migrationBuilder.CreateIndex(
                name: "IX_DogLitters_DogId",
                table: "DogLitters",
                column: "DogId");

            migrationBuilder.CreateIndex(
                name: "IX_DogLitters_LitterId",
                table: "DogLitters",
                column: "LitterId");

            migrationBuilder.CreateIndex(
                name: "IX_Dogs_MatingCalculationId",
                table: "Dogs",
                column: "MatingCalculationId");

            migrationBuilder.CreateIndex(
                name: "IX_MatingCalculations_ContractId",
                table: "MatingCalculations",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_MatingCalculations_MatingRulesId",
                table: "MatingCalculations",
                column: "MatingRulesId");

            migrationBuilder.CreateIndex(
                name: "IX_Userinformations_ContractId",
                table: "Userinformations",
                column: "ContractId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Diseases");

            migrationBuilder.DropTable(
                name: "DogLitters");

            migrationBuilder.DropTable(
                name: "Userinformations");

            migrationBuilder.DropTable(
                name: "Dogs");

            migrationBuilder.DropTable(
                name: "Litters");

            migrationBuilder.DropTable(
                name: "MatingCalculations");

            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.DropTable(
                name: "MatingRules");
        }
    }
}
