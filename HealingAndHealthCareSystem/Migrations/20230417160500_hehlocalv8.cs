using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealingAndHealthCareSystem.Migrations
{
    /// <inheritdoc />
    public partial class hehlocalv8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Problem",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    categoryID = table.Column<Guid>(type: "uuid", nullable: true),
                    medicalRecordID = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Problem", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Problem_Category_categoryID",
                        column: x => x.categoryID,
                        principalTable: "Category",
                        principalColumn: "categoryID");
                    table.ForeignKey(
                        name: "FK_Problem_MedicalRecord_medicalRecordID",
                        column: x => x.medicalRecordID,
                        principalTable: "MedicalRecord",
                        principalColumn: "medicalRecordID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Problem_categoryID",
                table: "Problem",
                column: "categoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Problem_medicalRecordID",
                table: "Problem",
                column: "medicalRecordID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Problem");
        }
    }
}
