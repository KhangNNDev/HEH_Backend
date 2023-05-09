using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealingAndHealthCareSystem.Migrations
{
    /// <inheritdoc />
    public partial class hehv8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingSchedule_Physiotherapist_physiotherapistID",
                table: "BookingSchedule");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingSchedule_Slot_slotID",
                table: "BookingSchedule");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingSchedule_SubProfile_profileID",
                table: "BookingSchedule");

            migrationBuilder.DropForeignKey(
                name: "FK_Slot_ExerciseDetail_exerciseDetailID",
                table: "Slot");

            migrationBuilder.DropIndex(
                name: "IX_Slot_exerciseDetailID",
                table: "Slot");

            migrationBuilder.DropIndex(
                name: "IX_BookingSchedule_physiotherapistID",
                table: "BookingSchedule");

            migrationBuilder.DropColumn(
                name: "duaration",
                table: "Slot");

            migrationBuilder.DropColumn(
                name: "exerciseDetailID",
                table: "Slot");

            migrationBuilder.DropColumn(
                name: "physiotherapistID",
                table: "BookingSchedule");

            migrationBuilder.DropColumn(
                name: "price",
                table: "BookingSchedule");

            migrationBuilder.RenameColumn(
                name: "slotID",
                table: "BookingSchedule",
                newName: "scheduleID");

            migrationBuilder.RenameColumn(
                name: "profileID",
                table: "BookingSchedule",
                newName: "subProfileID");

            migrationBuilder.RenameIndex(
                name: "IX_BookingSchedule_slotID",
                table: "BookingSchedule",
                newName: "IX_BookingSchedule_scheduleID");

            migrationBuilder.RenameIndex(
                name: "IX_BookingSchedule_profileID",
                table: "BookingSchedule",
                newName: "IX_BookingSchedule_subProfileID");

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "Slot",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "slotName",
                table: "Slot",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "day",
                table: "Schedule",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AddColumn<Guid>(
                name: "exerciseDetailID",
                table: "Schedule",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_exerciseDetailID",
                table: "Schedule",
                column: "exerciseDetailID");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingSchedule_Schedule_scheduleID",
                table: "BookingSchedule",
                column: "scheduleID",
                principalTable: "Schedule",
                principalColumn: "scheduleID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookingSchedule_SubProfile_subProfileID",
                table: "BookingSchedule",
                column: "subProfileID",
                principalTable: "SubProfile",
                principalColumn: "profileID");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_ExerciseDetail_exerciseDetailID",
                table: "Schedule",
                column: "exerciseDetailID",
                principalTable: "ExerciseDetail",
                principalColumn: "exerciseDetailID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingSchedule_Schedule_scheduleID",
                table: "BookingSchedule");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingSchedule_SubProfile_subProfileID",
                table: "BookingSchedule");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_ExerciseDetail_exerciseDetailID",
                table: "Schedule");

            migrationBuilder.DropIndex(
                name: "IX_Schedule_exerciseDetailID",
                table: "Schedule");

            migrationBuilder.DropColumn(
                name: "slotName",
                table: "Slot");

            migrationBuilder.DropColumn(
                name: "exerciseDetailID",
                table: "Schedule");

            migrationBuilder.RenameColumn(
                name: "subProfileID",
                table: "BookingSchedule",
                newName: "profileID");

            migrationBuilder.RenameColumn(
                name: "scheduleID",
                table: "BookingSchedule",
                newName: "slotID");

            migrationBuilder.RenameIndex(
                name: "IX_BookingSchedule_subProfileID",
                table: "BookingSchedule",
                newName: "IX_BookingSchedule_profileID");

            migrationBuilder.RenameIndex(
                name: "IX_BookingSchedule_scheduleID",
                table: "BookingSchedule",
                newName: "IX_BookingSchedule_slotID");

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "Slot",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<TimeOnly>(
                name: "duaration",
                table: "Slot",
                type: "time without time zone",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));

            migrationBuilder.AddColumn<Guid>(
                name: "exerciseDetailID",
                table: "Slot",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<DateOnly>(
                name: "day",
                table: "Schedule",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AddColumn<Guid>(
                name: "physiotherapistID",
                table: "BookingSchedule",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<float>(
                name: "price",
                table: "BookingSchedule",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.CreateIndex(
                name: "IX_Slot_exerciseDetailID",
                table: "Slot",
                column: "exerciseDetailID");

            migrationBuilder.CreateIndex(
                name: "IX_BookingSchedule_physiotherapistID",
                table: "BookingSchedule",
                column: "physiotherapistID");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingSchedule_Physiotherapist_physiotherapistID",
                table: "BookingSchedule",
                column: "physiotherapistID",
                principalTable: "Physiotherapist",
                principalColumn: "physiotherapistID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookingSchedule_Slot_slotID",
                table: "BookingSchedule",
                column: "slotID",
                principalTable: "Slot",
                principalColumn: "slotID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookingSchedule_SubProfile_profileID",
                table: "BookingSchedule",
                column: "profileID",
                principalTable: "SubProfile",
                principalColumn: "profileID");

            migrationBuilder.AddForeignKey(
                name: "FK_Slot_ExerciseDetail_exerciseDetailID",
                table: "Slot",
                column: "exerciseDetailID",
                principalTable: "ExerciseDetail",
                principalColumn: "exerciseDetailID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
