using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolMealsOrderingSystem.Data.Migrations
{
    public partial class ChildColumnNameChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Children_AspNetUsers_SchoolId",
                table: "Children");

            migrationBuilder.RenameColumn(
                name: "SchoolId",
                table: "Children",
                newName: "SchoolUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Children_SchoolId",
                table: "Children",
                newName: "IX_Children_SchoolUserId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Birthday",
                table: "Children",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddForeignKey(
                name: "FK_Children_AspNetUsers_SchoolUserId",
                table: "Children",
                column: "SchoolUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Children_AspNetUsers_SchoolUserId",
                table: "Children");

            migrationBuilder.RenameColumn(
                name: "SchoolUserId",
                table: "Children",
                newName: "SchoolId");

            migrationBuilder.RenameIndex(
                name: "IX_Children_SchoolUserId",
                table: "Children",
                newName: "IX_Children_SchoolId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Birthday",
                table: "Children",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AddForeignKey(
                name: "FK_Children_AspNetUsers_SchoolId",
                table: "Children",
                column: "SchoolId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
