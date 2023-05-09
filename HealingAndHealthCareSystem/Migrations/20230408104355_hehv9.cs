using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealingAndHealthCareSystem.Migrations
{
    /// <inheritdoc />
    public partial class hehv9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_ExerciseDetail_exerciseDetailID",
                table: "Schedule");

            migrationBuilder.AlterColumn<Guid>(
                name: "exerciseDetailID",
                table: "Schedule",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_ExerciseDetail_exerciseDetailID",
                table: "Schedule",
                column: "exerciseDetailID",
                principalTable: "ExerciseDetail",
                principalColumn: "exerciseDetailID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_ExerciseDetail_exerciseDetailID",
                table: "Schedule");

            migrationBuilder.AlterColumn<Guid>(
                name: "exerciseDetailID",
                table: "Schedule",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_ExerciseDetail_exerciseDetailID",
                table: "Schedule",
                column: "exerciseDetailID",
                principalTable: "ExerciseDetail",
                principalColumn: "exerciseDetailID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
