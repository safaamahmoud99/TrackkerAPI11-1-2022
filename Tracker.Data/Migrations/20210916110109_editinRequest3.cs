using Microsoft.EntityFrameworkCore.Migrations;

namespace Tracker.Data.Migrations
{
    public partial class editinRequest3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_requests_projects_ProjectId",
                table: "requests");

            migrationBuilder.DropIndex(
                name: "IX_requests_ProjectId",
                table: "requests");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "requests");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "requests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_requests_ProjectId",
                table: "requests",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_requests_projects_ProjectId",
                table: "requests",
                column: "ProjectId",
                principalTable: "projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
