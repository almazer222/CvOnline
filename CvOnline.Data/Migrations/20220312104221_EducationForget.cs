using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CvOnline.Infrastructure.Migrations
{
    public partial class EducationForget : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Education",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    School = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KindOfStudy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Degres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CvId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Education", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Education_CV_CvId",
                        column: x => x.CvId,
                        principalTable: "CV",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Education_CvId",
                table: "Education",
                column: "CvId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Education");
        }
    }
}
