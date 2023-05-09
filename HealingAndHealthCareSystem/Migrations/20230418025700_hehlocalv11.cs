using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealingAndHealthCareSystem.Migrations
{
    /// <inheritdoc />
    public partial class hehlocalv11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalRecord_AspNetUsers_userID",
                table: "MedicalRecord");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalRecord_Category_categoryID",
                table: "MedicalRecord");

            migrationBuilder.DropIndex(
                name: "IX_MedicalRecord_categoryID",
                table: "MedicalRecord");

            migrationBuilder.DropIndex(
                name: "IX_MedicalRecord_userID",
                table: "MedicalRecord");

            migrationBuilder.DropColumn(
                name: "categoryID",
                table: "MedicalRecord");

            migrationBuilder.DropColumn(
                name: "userID",
                table: "MedicalRecord");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "categoryID",
                table: "MedicalRecord",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "userID",
                table: "MedicalRecord",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecord_categoryID",
                table: "MedicalRecord",
                column: "categoryID");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecord_userID",
                table: "MedicalRecord",
                column: "userID");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalRecord_AspNetUsers_userID",
                table: "MedicalRecord",
                column: "userID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalRecord_Category_categoryID",
                table: "MedicalRecord",
                column: "categoryID",
                principalTable: "Category",
                principalColumn: "categoryID");
        }
    }
}
