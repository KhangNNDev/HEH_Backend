using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealingAndHealthCareSystem.Migrations
{
    /// <inheritdoc />
    public partial class hehv1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingDetail_AspNetUsers_userID",
                table: "BookingDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingDetail_Slot_slotID",
                table: "BookingDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingDetail_SubProfile_profileID",
                table: "BookingDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingSchedule_MedicalRecord_medicalRecordID",
                table: "BookingSchedule");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingSchedule_Schedule_scheduleID",
                table: "BookingSchedule");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingSchedule_SubProfile_subProfileID",
                table: "BookingSchedule");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedback_AspNetUsers_Id",
                table: "Feedback");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedback_BookingDetail_bookingDetailID",
                table: "Feedback");

            migrationBuilder.DropIndex(
                name: "IX_Feedback_Id",
                table: "Feedback");

            migrationBuilder.DropIndex(
                name: "IX_BookingSchedule_medicalRecordID",
                table: "BookingSchedule");

            migrationBuilder.DropIndex(
                name: "IX_BookingSchedule_scheduleID",
                table: "BookingSchedule");

            migrationBuilder.DropIndex(
                name: "IX_BookingDetail_profileID",
                table: "BookingDetail");

            migrationBuilder.DropIndex(
                name: "IX_BookingDetail_slotID",
                table: "BookingDetail");

            migrationBuilder.DropColumn(
                name: "price",
                table: "Slot");

            migrationBuilder.DropColumn(
                name: "workingStatus",
                table: "Physiotherapist");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Feedback");

            migrationBuilder.DropColumn(
                name: "medicalRecordID",
                table: "BookingSchedule");

            migrationBuilder.DropColumn(
                name: "scheduleID",
                table: "BookingSchedule");

            migrationBuilder.DropColumn(
                name: "price",
                table: "BookingDetail");

            migrationBuilder.DropColumn(
                name: "profileID",
                table: "BookingDetail");

            migrationBuilder.DropColumn(
                name: "slotID",
                table: "BookingDetail");

            migrationBuilder.RenameColumn(
                name: "bookingDetailID",
                table: "Feedback",
                newName: "scheduleID");

            migrationBuilder.RenameIndex(
                name: "IX_Feedback_bookingDetailID",
                table: "Feedback",
                newName: "IX_Feedback_scheduleID");

            migrationBuilder.RenameColumn(
                name: "subProfileID",
                table: "BookingSchedule",
                newName: "profileID");

            migrationBuilder.RenameIndex(
                name: "IX_BookingSchedule_subProfileID",
                table: "BookingSchedule",
                newName: "IX_BookingSchedule_profileID");

            migrationBuilder.RenameColumn(
                name: "userID",
                table: "BookingDetail",
                newName: "scheduleID");

            migrationBuilder.RenameIndex(
                name: "IX_BookingDetail_userID",
                table: "BookingDetail",
                newName: "IX_BookingDetail_scheduleID");

            migrationBuilder.AddColumn<float>(
                name: "price",
                table: "TypeOfSlot",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<Guid>(
                name: "bookingScheduleID",
                table: "Schedule",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ratingStar",
                table: "Feedback",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "comment",
                table: "Feedback",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_bookingScheduleID",
                table: "Schedule",
                column: "bookingScheduleID");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingDetail_Schedule_scheduleID",
                table: "BookingDetail",
                column: "scheduleID",
                principalTable: "Schedule",
                principalColumn: "scheduleID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookingSchedule_SubProfile_profileID",
                table: "BookingSchedule",
                column: "profileID",
                principalTable: "SubProfile",
                principalColumn: "profileID");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedback_Schedule_scheduleID",
                table: "Feedback",
                column: "scheduleID",
                principalTable: "Schedule",
                principalColumn: "scheduleID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_BookingSchedule_bookingScheduleID",
                table: "Schedule",
                column: "bookingScheduleID",
                principalTable: "BookingSchedule",
                principalColumn: "bookingScheduleID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingDetail_Schedule_scheduleID",
                table: "BookingDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingSchedule_SubProfile_profileID",
                table: "BookingSchedule");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedback_Schedule_scheduleID",
                table: "Feedback");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_BookingSchedule_bookingScheduleID",
                table: "Schedule");

            migrationBuilder.DropIndex(
                name: "IX_Schedule_bookingScheduleID",
                table: "Schedule");

            migrationBuilder.DropColumn(
                name: "price",
                table: "TypeOfSlot");

            migrationBuilder.DropColumn(
                name: "bookingScheduleID",
                table: "Schedule");

            migrationBuilder.RenameColumn(
                name: "scheduleID",
                table: "Feedback",
                newName: "bookingDetailID");

            migrationBuilder.RenameIndex(
                name: "IX_Feedback_scheduleID",
                table: "Feedback",
                newName: "IX_Feedback_bookingDetailID");

            migrationBuilder.RenameColumn(
                name: "profileID",
                table: "BookingSchedule",
                newName: "subProfileID");

            migrationBuilder.RenameIndex(
                name: "IX_BookingSchedule_profileID",
                table: "BookingSchedule",
                newName: "IX_BookingSchedule_subProfileID");

            migrationBuilder.RenameColumn(
                name: "scheduleID",
                table: "BookingDetail",
                newName: "userID");

            migrationBuilder.RenameIndex(
                name: "IX_BookingDetail_scheduleID",
                table: "BookingDetail",
                newName: "IX_BookingDetail_userID");

            migrationBuilder.AddColumn<float>(
                name: "price",
                table: "Slot",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "workingStatus",
                table: "Physiotherapist",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ratingStar",
                table: "Feedback",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "comment",
                table: "Feedback",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Feedback",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "medicalRecordID",
                table: "BookingSchedule",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "scheduleID",
                table: "BookingSchedule",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<float>(
                name: "price",
                table: "BookingDetail",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<Guid>(
                name: "profileID",
                table: "BookingDetail",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "slotID",
                table: "BookingDetail",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_Id",
                table: "Feedback",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_BookingSchedule_medicalRecordID",
                table: "BookingSchedule",
                column: "medicalRecordID");

            migrationBuilder.CreateIndex(
                name: "IX_BookingSchedule_scheduleID",
                table: "BookingSchedule",
                column: "scheduleID");

            migrationBuilder.CreateIndex(
                name: "IX_BookingDetail_profileID",
                table: "BookingDetail",
                column: "profileID");

            migrationBuilder.CreateIndex(
                name: "IX_BookingDetail_slotID",
                table: "BookingDetail",
                column: "slotID");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingDetail_AspNetUsers_userID",
                table: "BookingDetail",
                column: "userID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookingDetail_Slot_slotID",
                table: "BookingDetail",
                column: "slotID",
                principalTable: "Slot",
                principalColumn: "slotID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookingDetail_SubProfile_profileID",
                table: "BookingDetail",
                column: "profileID",
                principalTable: "SubProfile",
                principalColumn: "profileID");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingSchedule_MedicalRecord_medicalRecordID",
                table: "BookingSchedule",
                column: "medicalRecordID",
                principalTable: "MedicalRecord",
                principalColumn: "medicalRecordID",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_Feedback_AspNetUsers_Id",
                table: "Feedback",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedback_BookingDetail_bookingDetailID",
                table: "Feedback",
                column: "bookingDetailID",
                principalTable: "BookingDetail",
                principalColumn: "bookingDetailID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
