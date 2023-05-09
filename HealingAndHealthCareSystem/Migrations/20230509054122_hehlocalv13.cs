using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealingAndHealthCareSystem.Migrations
{
    /// <inheritdoc />
    public partial class hehlocalv13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "longtermFlag",
                table: "BookingDetail");

            migrationBuilder.DropColumn(
                name: "shorttermFlag",
                table: "BookingDetail");

            migrationBuilder.DropColumn(
                name: "status",
                table: "BookingDetail");

            migrationBuilder.AddColumn<int>(
                name: "longtermStatus",
                table: "BookingDetail",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "shorttermStatus",
                table: "BookingDetail",
                type: "integer",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "longtermStatus",
                table: "BookingDetail");

            migrationBuilder.DropColumn(
                name: "shorttermStatus",
                table: "BookingDetail");

            migrationBuilder.AddColumn<int>(
                name: "longtermFlag",
                table: "BookingDetail",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "shorttermFlag",
                table: "BookingDetail",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "status",
                table: "BookingDetail",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
