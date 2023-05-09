using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealingAndHealthCareSystem.Migrations
{
    /// <inheritdoc />
    public partial class hehv18 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_BookingSchedule_bookingScheduleID",
                table: "Schedule");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_ExerciseDetail_exerciseDetailID",
                table: "Schedule");

            migrationBuilder.DropIndex(
                name: "IX_Schedule_bookingScheduleID",
                table: "Schedule");

            migrationBuilder.DropIndex(
                name: "IX_Schedule_exerciseDetailID",
                table: "Schedule");

            migrationBuilder.DropColumn(
                name: "description",
                table: "Slot");

            migrationBuilder.DropColumn(
                name: "bookingScheduleID",
                table: "Schedule");

            migrationBuilder.DropColumn(
                name: "exerciseDetailID",
                table: "Schedule");

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "Schedule",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "set",
                table: "ExerciseDetail",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<Guid>(
                name: "scheduleID",
                table: "BookingSchedule",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "bookingScheduleID",
                table: "BookingDetail",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_BookingSchedule_scheduleID",
                table: "BookingSchedule",
                column: "scheduleID");

            migrationBuilder.CreateIndex(
                name: "IX_BookingDetail_bookingScheduleID",
                table: "BookingDetail",
                column: "bookingScheduleID");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingDetail_BookingSchedule_bookingScheduleID",
                table: "BookingDetail",
                column: "bookingScheduleID",
                principalTable: "BookingSchedule",
                principalColumn: "bookingScheduleID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookingSchedule_Schedule_scheduleID",
                table: "BookingSchedule",
                column: "scheduleID",
                principalTable: "Schedule",
                principalColumn: "scheduleID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingDetail_BookingSchedule_bookingScheduleID",
                table: "BookingDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingSchedule_Schedule_scheduleID",
                table: "BookingSchedule");

            migrationBuilder.DropIndex(
                name: "IX_BookingSchedule_scheduleID",
                table: "BookingSchedule");

            migrationBuilder.DropIndex(
                name: "IX_BookingDetail_bookingScheduleID",
                table: "BookingDetail");

            migrationBuilder.DropColumn(
                name: "description",
                table: "Schedule");

            migrationBuilder.DropColumn(
                name: "scheduleID",
                table: "BookingSchedule");

            migrationBuilder.DropColumn(
                name: "bookingScheduleID",
                table: "BookingDetail");

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "Slot",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "bookingScheduleID",
                table: "Schedule",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "exerciseDetailID",
                table: "Schedule",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "set",
                table: "ExerciseDetail",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_bookingScheduleID",
                table: "Schedule",
                column: "bookingScheduleID");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_exerciseDetailID",
                table: "Schedule",
                column: "exerciseDetailID");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_BookingSchedule_bookingScheduleID",
                table: "Schedule",
                column: "bookingScheduleID",
                principalTable: "BookingSchedule",
                principalColumn: "bookingScheduleID");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_ExerciseDetail_exerciseDetailID",
                table: "Schedule",
                column: "exerciseDetailID",
                principalTable: "ExerciseDetail",
                principalColumn: "exerciseDetailID");
        }
    }
}
