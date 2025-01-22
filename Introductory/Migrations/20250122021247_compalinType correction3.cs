using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Introductory.Migrations
{
    /// <inheritdoc />
    public partial class compalinTypecorrection3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Complain_ComplainType_ComplainTypeID",
                table: "Complain");

            migrationBuilder.DropIndex(
                name: "IX_Complain_ComplainTypeID",
                table: "Complain");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Complain_ComplainTypeID",
                table: "Complain",
                column: "ComplainTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Complain_ComplainType_ComplainTypeID",
                table: "Complain",
                column: "ComplainTypeID",
                principalTable: "ComplainType",
                principalColumn: "ComplainTypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
