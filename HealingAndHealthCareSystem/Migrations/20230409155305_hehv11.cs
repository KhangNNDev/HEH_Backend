using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealingAndHealthCareSystem.Migrations
{
    /// <inheritdoc />
    public partial class hehv11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalRecord_AspNetUsers_userID",
                table: "MedicalRecord");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalRecord_Category_categoryID",
                table: "MedicalRecord");

            migrationBuilder.AddColumn<Guid>(
                name: "relationId",
                table: "SubProfile",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "userID",
                table: "MedicalRecord",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "categoryID",
                table: "MedicalRecord",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<string>(
                name: "address",
                table: "AspNetUsers",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Relationship",
                columns: table => new
                {
                    relationId = table.Column<Guid>(type: "uuid", nullable: false),
                    relationName = table.Column<string>(type: "text", nullable: false),
                    isDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relationship", x => x.relationId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubProfile_relationId",
                table: "SubProfile",
                column: "relationId");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalRecord_AspNetUsers_userID",
                table: "MedicalRecord",
                column: "userID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalRecord_Category_categoryID",
                table: "MedicalRecord",
                column: "categoryID",
                principalTable: "Category",
                principalColumn: "categoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_SubProfile_Relationship_relationId",
                table: "SubProfile",
                column: "relationId",
                principalTable: "Relationship",
                principalColumn: "relationId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalRecord_AspNetUsers_userID",
                table: "MedicalRecord");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalRecord_Category_categoryID",
                table: "MedicalRecord");

            migrationBuilder.DropForeignKey(
                name: "FK_SubProfile_Relationship_relationId",
                table: "SubProfile");

            migrationBuilder.DropTable(
                name: "Relationship");

            migrationBuilder.DropIndex(
                name: "IX_SubProfile_relationId",
                table: "SubProfile");

            migrationBuilder.DropColumn(
                name: "relationId",
                table: "SubProfile");

            migrationBuilder.AlterColumn<Guid>(
                name: "userID",
                table: "MedicalRecord",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "categoryID",
                table: "MedicalRecord",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "address",
                table: "AspNetUsers",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalRecord_AspNetUsers_userID",
                table: "MedicalRecord",
                column: "userID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalRecord_Category_categoryID",
                table: "MedicalRecord",
                column: "categoryID",
                principalTable: "Category",
                principalColumn: "categoryID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
