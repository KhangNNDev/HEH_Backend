using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealingAndHealthCareSystem.Migrations
{
    /// <inheritdoc />
    public partial class hehlocalv15 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserExercise");

            migrationBuilder.AddColumn<int>(
                name: "favoriteStatus",
                table: "ExerciseDetail",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "FavoriteExercise",
                columns: table => new
                {
                    FavoriteExerciseID = table.Column<Guid>(type: "uuid", nullable: false),
                    exerciseDetailID = table.Column<Guid>(type: "uuid", nullable: false),
                    userID = table.Column<Guid>(type: "uuid", nullable: false),
                    isDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteExercise", x => x.FavoriteExerciseID);
                    table.ForeignKey(
                        name: "FK_FavoriteExercise_AspNetUsers_userID",
                        column: x => x.userID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavoriteExercise_ExerciseDetail_exerciseDetailID",
                        column: x => x.exerciseDetailID,
                        principalTable: "ExerciseDetail",
                        principalColumn: "exerciseDetailID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteExercise_exerciseDetailID",
                table: "FavoriteExercise",
                column: "exerciseDetailID");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteExercise_userID",
                table: "FavoriteExercise",
                column: "userID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavoriteExercise");

            migrationBuilder.DropColumn(
                name: "favoriteStatus",
                table: "ExerciseDetail");

            migrationBuilder.CreateTable(
                name: "UserExercise",
                columns: table => new
                {
                    userExerciseID = table.Column<Guid>(type: "uuid", nullable: false),
                    exerciseDetailID = table.Column<Guid>(type: "uuid", nullable: false),
                    userID = table.Column<Guid>(type: "uuid", nullable: false),
                    duarationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    isDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserExercise", x => x.userExerciseID);
                    table.ForeignKey(
                        name: "FK_UserExercise_AspNetUsers_userID",
                        column: x => x.userID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserExercise_ExerciseDetail_exerciseDetailID",
                        column: x => x.exerciseDetailID,
                        principalTable: "ExerciseDetail",
                        principalColumn: "exerciseDetailID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserExercise_exerciseDetailID",
                table: "UserExercise",
                column: "exerciseDetailID");

            migrationBuilder.CreateIndex(
                name: "IX_UserExercise_userID",
                table: "UserExercise",
                column: "userID");
        }
    }
}
