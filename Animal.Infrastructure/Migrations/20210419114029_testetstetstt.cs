using Microsoft.EntityFrameworkCore.Migrations;

namespace Animal.Infrastructure.Migrations
{
    public partial class testetstetstt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HealthRecords_Animals_HealthRecordId",
                table: "HealthRecords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HealthRecords",
                table: "HealthRecords");

            migrationBuilder.DropIndex(
                name: "IX_HealthRecords_HealthRecordId",
                table: "HealthRecords");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HealthRecords",
                table: "HealthRecords",
                column: "HealthRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthRecords_AnimalId",
                table: "HealthRecords",
                column: "AnimalId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_HealthRecords_Animals_AnimalId",
                table: "HealthRecords",
                column: "AnimalId",
                principalTable: "Animals",
                principalColumn: "AnimalId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HealthRecords_Animals_AnimalId",
                table: "HealthRecords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HealthRecords",
                table: "HealthRecords");

            migrationBuilder.DropIndex(
                name: "IX_HealthRecords_AnimalId",
                table: "HealthRecords");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HealthRecords",
                table: "HealthRecords",
                columns: new[] { "AnimalId", "HealthRecordId" });

            migrationBuilder.CreateIndex(
                name: "IX_HealthRecords_HealthRecordId",
                table: "HealthRecords",
                column: "HealthRecordId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_HealthRecords_Animals_HealthRecordId",
                table: "HealthRecords",
                column: "HealthRecordId",
                principalTable: "Animals",
                principalColumn: "AnimalId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
