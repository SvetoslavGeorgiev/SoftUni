using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolMealsOrderingSystem.Data.Migrations
{
    public partial class UpdateManyToManyParenChild : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_ParentUserId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Children_ChildId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ChildId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ParentUserId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ChildId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ParentUserId",
                table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ChildId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ParentUserId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ChildId",
                table: "AspNetUsers",
                column: "ChildId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ParentUserId",
                table: "AspNetUsers",
                column: "ParentUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_ParentUserId",
                table: "AspNetUsers",
                column: "ParentUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Children_ChildId",
                table: "AspNetUsers",
                column: "ChildId",
                principalTable: "Children",
                principalColumn: "Id");
        }
    }
}
