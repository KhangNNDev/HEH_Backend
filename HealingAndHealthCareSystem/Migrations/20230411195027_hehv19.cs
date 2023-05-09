using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealingAndHealthCareSystem.Migrations
{
    /// <inheritdoc />
    public partial class hehv19 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingSchedule_Schedule_scheduleID",
                table: "BookingSchedule");

            migrationBuilder.DropIndex(
                name: "IX_BookingSchedule_scheduleID",
                table: "BookingSchedule");

            migrationBuilder.DropColumn(
                name: "scheduleID",
                table: "BookingSchedule");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "scheduleID",
                table: "BookingSchedule",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_BookingSchedule_scheduleID",
                table: "BookingSchedule",
                column: "scheduleID");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingSchedule_Schedule_scheduleID",
                table: "BookingSchedule",
                column: "scheduleID",
                principalTable: "Schedule",
                principalColumn: "scheduleID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
