using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealingAndHealthCareSystem.Migrations
{
    /// <inheritdoc />
    public partial class hehlocalv7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingDetail_BookingSchedule_bookingScheduleID",
                table: "BookingDetail");

            migrationBuilder.AlterColumn<Guid>(
                name: "bookingScheduleID",
                table: "BookingDetail",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<string>(
                name: "videoCallRoom",
                table: "BookingDetail",
                type: "text",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BookingDetail_BookingSchedule_bookingScheduleID",
                table: "BookingDetail",
                column: "bookingScheduleID",
                principalTable: "BookingSchedule",
                principalColumn: "bookingScheduleID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingDetail_BookingSchedule_bookingScheduleID",
                table: "BookingDetail");

            migrationBuilder.DropColumn(
                name: "videoCallRoom",
                table: "BookingDetail");

            migrationBuilder.AlterColumn<Guid>(
                name: "bookingScheduleID",
                table: "BookingDetail",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BookingDetail_BookingSchedule_bookingScheduleID",
                table: "BookingDetail",
                column: "bookingScheduleID",
                principalTable: "BookingSchedule",
                principalColumn: "bookingScheduleID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
