using Microsoft.EntityFrameworkCore.Migrations;

namespace Tracker.Data.Migrations
{
    public partial class addCreatedbyToRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "requests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_requests_CreatedById",
                table: "requests",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_requests_clients_CreatedById",
                table: "requests",
                column: "CreatedById",
                principalTable: "clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_requests_clients_CreatedById",
                table: "requests");

            migrationBuilder.DropIndex(
                name: "IX_requests_CreatedById",
                table: "requests");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "requests");
        }
    }
}
