using Microsoft.EntityFrameworkCore.Migrations;

namespace Tracker.Data.Migrations
{
    public partial class editInOrganization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "organizations");

            migrationBuilder.DropColumn(
                name: "Mobile",
                table: "organizations");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "organizations");

            migrationBuilder.DropColumn(
                name: "ResponsiblePerson",
                table: "organizations");

            migrationBuilder.CreateTable(
                name: "OrganizationClients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationId = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationClients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganizationClients_clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrganizationClients_organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationClients_ClientId",
                table: "OrganizationClients",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationClients_OrganizationId",
                table: "OrganizationClients",
                column: "OrganizationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrganizationClients");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "organizations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Mobile",
                table: "organizations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "organizations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ResponsiblePerson",
                table: "organizations",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
