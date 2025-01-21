using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Introductory.Migrations
{
    /// <inheritdoc />
    public partial class UserIDinUsGr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "UserGroup",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserGroup_CreatedBy",
                table: "UserGroup",
                column: "CreatedBy",
                unique: true,
                filter: "[CreatedBy] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_UserGroup_Users_CreatedBy",
                table: "UserGroup",
                column: "CreatedBy",
                principalTable: "Users",
                principalColumn: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserGroup_Users_CreatedBy",
                table: "UserGroup");

            migrationBuilder.DropIndex(
                name: "IX_UserGroup_CreatedBy",
                table: "UserGroup");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "UserGroup");
        }
    }
}
