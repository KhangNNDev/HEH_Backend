using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealingAndHealthCareSystem.Migrations
{
    /// <inheritdoc />
    public partial class hehlocalv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingDetail_Schedule_scheduleID",
                table: "BookingDetail");

            migrationBuilder.DropIndex(
                name: "IX_BookingDetail_scheduleID",
                table: "BookingDetail");

            migrationBuilder.DropColumn(
                name: "scheduleID",
                table: "BookingDetail");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "scheduleID",
                table: "BookingDetail",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_BookingDetail_scheduleID",
                table: "BookingDetail",
                column: "scheduleID");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingDetail_Schedule_scheduleID",
                table: "BookingDetail",
                column: "scheduleID",
                principalTable: "Schedule",
                principalColumn: "scheduleID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
