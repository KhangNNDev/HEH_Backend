using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealingAndHealthCareSystem.Migrations
{
    /// <inheritdoc />
    public partial class hehv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalRecord_SubProfile_subProfileID",
                table: "MedicalRecord");

            migrationBuilder.AlterColumn<Guid>(
                name: "subProfileID",
                table: "MedicalRecord",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalRecord_SubProfile_subProfileID",
                table: "MedicalRecord",
                column: "subProfileID",
                principalTable: "SubProfile",
                principalColumn: "profileID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalRecord_SubProfile_subProfileID",
                table: "MedicalRecord");

            migrationBuilder.AlterColumn<Guid>(
                name: "subProfileID",
                table: "MedicalRecord",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalRecord_SubProfile_subProfileID",
                table: "MedicalRecord",
                column: "subProfileID",
                principalTable: "SubProfile",
                principalColumn: "profileID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
