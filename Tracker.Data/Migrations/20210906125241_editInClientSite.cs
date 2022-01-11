using Microsoft.EntityFrameworkCore.Migrations;

namespace Tracker.Data.Migrations
{
    public partial class editInClientSite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SiteClients_Sites_SiteId",
                table: "SiteClients");

            migrationBuilder.RenameColumn(
                name: "SiteId",
                table: "SiteClients",
                newName: "ProjectSiteId");

            migrationBuilder.RenameIndex(
                name: "IX_SiteClients_SiteId",
                table: "SiteClients",
                newName: "IX_SiteClients_ProjectSiteId");

            migrationBuilder.AddForeignKey(
                name: "FK_SiteClients_ProjectSites_ProjectSiteId",
                table: "SiteClients",
                column: "ProjectSiteId",
                principalTable: "ProjectSites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SiteClients_ProjectSites_ProjectSiteId",
                table: "SiteClients");

            migrationBuilder.RenameColumn(
                name: "ProjectSiteId",
                table: "SiteClients",
                newName: "SiteId");

            migrationBuilder.RenameIndex(
                name: "IX_SiteClients_ProjectSiteId",
                table: "SiteClients",
                newName: "IX_SiteClients_SiteId");

            migrationBuilder.AddForeignKey(
                name: "FK_SiteClients_Sites_SiteId",
                table: "SiteClients",
                column: "SiteId",
                principalTable: "Sites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
