using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealingAndHealthCareSystem.Migrations
{
    /// <inheritdoc />
    public partial class hehlocalv14 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "imageUrl",
                table: "BookingDetail",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "imageUrl",
                table: "BookingDetail");
        }
    }
}
