using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Introductory.Migrations
{
    /// <inheritdoc />
    public partial class adeshaddition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ComplainStatus",
                columns: table => new
                {
                    ComplainStatusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComplainStatusName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComplainStatusCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplainStatus", x => x.ComplainStatusID);
                });

            migrationBuilder.CreateTable(
                name: "ComplainStatusTrackInfo",
                columns: table => new
                {
                    ComplainStatusTrackInfoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComplainID = table.Column<int>(type: "int", nullable: false),
                    ComplainStatusID = table.Column<int>(type: "int", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplainStatusTrackInfo", x => x.ComplainStatusTrackInfoID);
                    table.ForeignKey(
                        name: "FK_ComplainStatusTrackInfo_ComplainStatus_ComplainStatusID",
                        column: x => x.ComplainStatusID,
                        principalTable: "ComplainStatus",
                        principalColumn: "ComplainStatusID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComplainStatusTrackInfo_Complain_ComplainID",
                        column: x => x.ComplainID,
                        principalTable: "Complain",
                        principalColumn: "ComplainId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComplainStatusTrackInfo_ComplainID",
                table: "ComplainStatusTrackInfo",
                column: "ComplainID");

            migrationBuilder.CreateIndex(
                name: "IX_ComplainStatusTrackInfo_ComplainStatusID",
                table: "ComplainStatusTrackInfo",
                column: "ComplainStatusID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComplainStatusTrackInfo");

            migrationBuilder.DropTable(
                name: "ComplainStatus");
        }
    }
}
