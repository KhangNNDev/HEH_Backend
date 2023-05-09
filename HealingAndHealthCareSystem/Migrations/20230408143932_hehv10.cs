using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealingAndHealthCareSystem.Migrations
{
    /// <inheritdoc />
    public partial class hehv10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Slot_TypeOfSlot_typeOfSlotID",
                table: "Slot");

            migrationBuilder.DropIndex(
                name: "IX_Slot_typeOfSlotID",
                table: "Slot");

            migrationBuilder.DropColumn(
                name: "typeOfSlotID",
                table: "Slot");

            migrationBuilder.RenameColumn(
                name: "slotName",
                table: "TypeOfSlot",
                newName: "typeName");

            migrationBuilder.AddColumn<Guid>(
                name: "typeOfSlotID",
                table: "Schedule",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "iconUrl",
                table: "Exercise",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "iconUrl",
                table: "Category",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_typeOfSlotID",
                table: "Schedule",
                column: "typeOfSlotID");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_TypeOfSlot_typeOfSlotID",
                table: "Schedule",
                column: "typeOfSlotID",
                principalTable: "TypeOfSlot",
                principalColumn: "typeOfSlotID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_TypeOfSlot_typeOfSlotID",
                table: "Schedule");

            migrationBuilder.DropIndex(
                name: "IX_Schedule_typeOfSlotID",
                table: "Schedule");

            migrationBuilder.DropColumn(
                name: "typeOfSlotID",
                table: "Schedule");

            migrationBuilder.DropColumn(
                name: "iconUrl",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "iconUrl",
                table: "Category");

            migrationBuilder.RenameColumn(
                name: "typeName",
                table: "TypeOfSlot",
                newName: "slotName");

            migrationBuilder.AddColumn<Guid>(
                name: "typeOfSlotID",
                table: "Slot",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Slot_typeOfSlotID",
                table: "Slot",
                column: "typeOfSlotID");

            migrationBuilder.AddForeignKey(
                name: "FK_Slot_TypeOfSlot_typeOfSlotID",
                table: "Slot",
                column: "typeOfSlotID",
                principalTable: "TypeOfSlot",
                principalColumn: "typeOfSlotID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
