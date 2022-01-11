using Microsoft.EntityFrameworkCore.Migrations;

namespace Tracker.Data.Migrations
{
    public partial class editinRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_requests_assets_AssetId",
                table: "requests");

            migrationBuilder.RenameColumn(
                name: "AssetId",
                table: "requests",
                newName: "ProjectSiteAssetId");

            migrationBuilder.RenameIndex(
                name: "IX_requests_AssetId",
                table: "requests",
                newName: "IX_requests_ProjectSiteAssetId");

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
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_requests_ProjectSiteAsset_ProjectSiteAssetId",
                table: "requests",
                column: "ProjectSiteAssetId",
                principalTable: "ProjectSiteAsset",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_requests_projects_ProjectId",
                table: "requests");

            migrationBuilder.DropForeignKey(
                name: "FK_requests_ProjectSiteAsset_ProjectSiteAssetId",
                table: "requests");

            migrationBuilder.DropIndex(
                name: "IX_requests_ProjectId",
                table: "requests");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "requests");

            migrationBuilder.RenameColumn(
                name: "ProjectSiteAssetId",
                table: "requests",
                newName: "AssetId");

            migrationBuilder.RenameIndex(
                name: "IX_requests_ProjectSiteAssetId",
                table: "requests",
                newName: "IX_requests_AssetId");

            migrationBuilder.AddForeignKey(
                name: "FK_requests_assets_AssetId",
                table: "requests",
                column: "AssetId",
                principalTable: "assets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
