using Microsoft.EntityFrameworkCore.Migrations;

namespace Tracker.Data.Migrations
{
    public partial class asset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Asset_Brand_BrandId",
                table: "Asset");

            migrationBuilder.DropForeignKey(
                name: "FK_Asset_Origins_OriginId",
                table: "Asset");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectSiteAsset_Asset_AssetId",
                table: "ProjectSiteAsset");

            migrationBuilder.DropForeignKey(
                name: "FK_requests_Asset_AssetId",
                table: "requests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Asset",
                table: "Asset");

            migrationBuilder.RenameTable(
                name: "Asset",
                newName: "assets");

            migrationBuilder.RenameIndex(
                name: "IX_Asset_OriginId",
                table: "assets",
                newName: "IX_assets_OriginId");

            migrationBuilder.RenameIndex(
                name: "IX_Asset_BrandId",
                table: "assets",
                newName: "IX_assets_BrandId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_assets",
                table: "assets",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_assets_Brand_BrandId",
                table: "assets",
                column: "BrandId",
                principalTable: "Brand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_assets_Origins_OriginId",
                table: "assets",
                column: "OriginId",
                principalTable: "Origins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectSiteAsset_assets_AssetId",
                table: "ProjectSiteAsset",
                column: "AssetId",
                principalTable: "assets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_requests_assets_AssetId",
                table: "requests",
                column: "AssetId",
                principalTable: "assets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_assets_Brand_BrandId",
                table: "assets");

            migrationBuilder.DropForeignKey(
                name: "FK_assets_Origins_OriginId",
                table: "assets");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectSiteAsset_assets_AssetId",
                table: "ProjectSiteAsset");

            migrationBuilder.DropForeignKey(
                name: "FK_requests_assets_AssetId",
                table: "requests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_assets",
                table: "assets");

            migrationBuilder.RenameTable(
                name: "assets",
                newName: "Asset");

            migrationBuilder.RenameIndex(
                name: "IX_assets_OriginId",
                table: "Asset",
                newName: "IX_Asset_OriginId");

            migrationBuilder.RenameIndex(
                name: "IX_assets_BrandId",
                table: "Asset",
                newName: "IX_Asset_BrandId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Asset",
                table: "Asset",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Asset_Brand_BrandId",
                table: "Asset",
                column: "BrandId",
                principalTable: "Brand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Asset_Origins_OriginId",
                table: "Asset",
                column: "OriginId",
                principalTable: "Origins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectSiteAsset_Asset_AssetId",
                table: "ProjectSiteAsset",
                column: "AssetId",
                principalTable: "Asset",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_requests_Asset_AssetId",
                table: "requests",
                column: "AssetId",
                principalTable: "Asset",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
