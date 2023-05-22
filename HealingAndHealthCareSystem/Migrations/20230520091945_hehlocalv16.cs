using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealingAndHealthCareSystem.Migrations
{
    /// <inheritdoc />
    public partial class hehlocalv16 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FavoriteExerciseID",
                table: "FavoriteExercise",
                newName: "favoriteExerciseID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "favoriteExerciseID",
                table: "FavoriteExercise",
                newName: "FavoriteExerciseID");
        }
    }
}
