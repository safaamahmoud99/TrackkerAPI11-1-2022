using Microsoft.EntityFrameworkCore.Migrations;

namespace Tracker.Data.Migrations
{
    public partial class addd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_assets_Brand_BrandId",
                table: "assets");

            migrationBuilder.DropForeignKey(
                name: "FK_assets_Origins_OriginId",
                table: "assets");

            migrationBuilder.DropForeignKey(
                name: "FK_AssignedRequests_Employees_EmployeeId",
                table: "AssignedRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_AssignedRequests_projectPositions_ProjectPositionId",
                table: "AssignedRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_AssignedRequests_requests_RequestId",
                table: "AssignedRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_AssignedRequests_Teams_TeamId",
                table: "AssignedRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_City_Governorate_GovernorateId",
                table: "City");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_departments_DepartmentId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_mileStones_projects_ProjectId",
                table: "mileStones");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationClients_clients_ClientId",
                table: "OrganizationClients");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationClients_organizations_OrganizationId",
                table: "OrganizationClients");

            migrationBuilder.DropForeignKey(
                name: "FK_projectDocuments_projects_ProjectId",
                table: "projectDocuments");

            migrationBuilder.DropForeignKey(
                name: "FK_projects_Employees_EmployeeId",
                table: "projects");

            migrationBuilder.DropForeignKey(
                name: "FK_projects_organizations_OrganizationId",
                table: "projects");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectSiteAsset_assets_AssetId",
                table: "ProjectSiteAsset");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectSiteAsset_ProjectSites_ProjectSiteId",
                table: "ProjectSiteAsset");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectSiteAsset_Suppliers_SupplierId",
                table: "ProjectSiteAsset");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectSites_projects_ProjectId",
                table: "ProjectSites");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectSites_Sites_SiteId",
                table: "ProjectSites");

            migrationBuilder.DropForeignKey(
                name: "FK_projectTeams_departments_DepartmentId",
                table: "projectTeams");

            migrationBuilder.DropForeignKey(
                name: "FK_projectTeams_Employees_EmployeeId",
                table: "projectTeams");

            migrationBuilder.DropForeignKey(
                name: "FK_projectTeams_projectPositions_ProjectPositionId",
                table: "projectTeams");

            migrationBuilder.DropForeignKey(
                name: "FK_projectTeams_projects_ProjectId",
                table: "projectTeams");

            migrationBuilder.DropForeignKey(
                name: "FK_projectTeams_Teams_TeamId",
                table: "projectTeams");

            migrationBuilder.DropForeignKey(
                name: "FK_requestCategories_departments_DepartmentId",
                table: "requestCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestDescriptions_requests_RequestId",
                table: "RequestDescriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestImages_requests_requestId",
                table: "RequestImages");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestProblems_Employees_EmployeeId",
                table: "RequestProblems");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestProblems_Problems_ProblemId",
                table: "RequestProblems");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestProblems_requests_RequestId",
                table: "RequestProblems");

            migrationBuilder.DropForeignKey(
                name: "FK_requests_clients_ClientId",
                table: "requests");

            migrationBuilder.DropForeignKey(
                name: "FK_requests_ProjectSiteAsset_ProjectSiteAssetId",
                table: "requests");

            migrationBuilder.DropForeignKey(
                name: "FK_requests_projectTeams_ProjectTeamId",
                table: "requests");

            migrationBuilder.DropForeignKey(
                name: "FK_requests_requestModes_RequestModeId",
                table: "requests");

            migrationBuilder.DropForeignKey(
                name: "FK_requests_requestPeriorities_RequestPeriorityId",
                table: "requests");

            migrationBuilder.DropForeignKey(
                name: "FK_requests_requestStatuses_RequestStatusId",
                table: "requests");

            migrationBuilder.DropForeignKey(
                name: "FK_requests_requestSubCategories_RequestSubCategoryId",
                table: "requests");

            migrationBuilder.DropForeignKey(
                name: "FK_requestSubCategories_requestCategories_RequestCategoryId",
                table: "requestSubCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_SiteClients_clients_ClientId",
                table: "SiteClients");

            migrationBuilder.DropForeignKey(
                name: "FK_SiteClients_ProjectSites_ProjectSiteId",
                table: "SiteClients");

            migrationBuilder.DropForeignKey(
                name: "FK_Sites_City_CityId",
                table: "Sites");

            migrationBuilder.DropForeignKey(
                name: "FK_Sites_Governorate_GovernorateId",
                table: "Sites");

            migrationBuilder.DropForeignKey(
                name: "FK_stackeholders_projects_ProjectId",
                table: "stackeholders");

            migrationBuilder.AddForeignKey(
                name: "FK_assets_Brand_BrandId",
                table: "assets",
                column: "BrandId",
                principalTable: "Brand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_assets_Origins_OriginId",
                table: "assets",
                column: "OriginId",
                principalTable: "Origins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AssignedRequests_Employees_EmployeeId",
                table: "AssignedRequests",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AssignedRequests_projectPositions_ProjectPositionId",
                table: "AssignedRequests",
                column: "ProjectPositionId",
                principalTable: "projectPositions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AssignedRequests_requests_RequestId",
                table: "AssignedRequests",
                column: "RequestId",
                principalTable: "requests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AssignedRequests_Teams_TeamId",
                table: "AssignedRequests",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_City_Governorate_GovernorateId",
                table: "City",
                column: "GovernorateId",
                principalTable: "Governorate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_departments_DepartmentId",
                table: "Employees",
                column: "DepartmentId",
                principalTable: "departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_mileStones_projects_ProjectId",
                table: "mileStones",
                column: "ProjectId",
                principalTable: "projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationClients_clients_ClientId",
                table: "OrganizationClients",
                column: "ClientId",
                principalTable: "clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationClients_organizations_OrganizationId",
                table: "OrganizationClients",
                column: "OrganizationId",
                principalTable: "organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_projectDocuments_projects_ProjectId",
                table: "projectDocuments",
                column: "ProjectId",
                principalTable: "projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_projects_Employees_EmployeeId",
                table: "projects",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_projects_organizations_OrganizationId",
                table: "projects",
                column: "OrganizationId",
                principalTable: "organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectSiteAsset_assets_AssetId",
                table: "ProjectSiteAsset",
                column: "AssetId",
                principalTable: "assets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectSiteAsset_ProjectSites_ProjectSiteId",
                table: "ProjectSiteAsset",
                column: "ProjectSiteId",
                principalTable: "ProjectSites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectSiteAsset_Suppliers_SupplierId",
                table: "ProjectSiteAsset",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectSites_projects_ProjectId",
                table: "ProjectSites",
                column: "ProjectId",
                principalTable: "projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectSites_Sites_SiteId",
                table: "ProjectSites",
                column: "SiteId",
                principalTable: "Sites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_projectTeams_departments_DepartmentId",
                table: "projectTeams",
                column: "DepartmentId",
                principalTable: "departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_projectTeams_Employees_EmployeeId",
                table: "projectTeams",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_projectTeams_projectPositions_ProjectPositionId",
                table: "projectTeams",
                column: "ProjectPositionId",
                principalTable: "projectPositions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_projectTeams_projects_ProjectId",
                table: "projectTeams",
                column: "ProjectId",
                principalTable: "projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_projectTeams_Teams_TeamId",
                table: "projectTeams",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_requestCategories_departments_DepartmentId",
                table: "requestCategories",
                column: "DepartmentId",
                principalTable: "departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestDescriptions_requests_RequestId",
                table: "RequestDescriptions",
                column: "RequestId",
                principalTable: "requests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestImages_requests_requestId",
                table: "RequestImages",
                column: "requestId",
                principalTable: "requests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestProblems_Employees_EmployeeId",
                table: "RequestProblems",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestProblems_Problems_ProblemId",
                table: "RequestProblems",
                column: "ProblemId",
                principalTable: "Problems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestProblems_requests_RequestId",
                table: "RequestProblems",
                column: "RequestId",
                principalTable: "requests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_requests_clients_ClientId",
                table: "requests",
                column: "ClientId",
                principalTable: "clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_requests_ProjectSiteAsset_ProjectSiteAssetId",
                table: "requests",
                column: "ProjectSiteAssetId",
                principalTable: "ProjectSiteAsset",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_requests_projectTeams_ProjectTeamId",
                table: "requests",
                column: "ProjectTeamId",
                principalTable: "projectTeams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_requests_requestModes_RequestModeId",
                table: "requests",
                column: "RequestModeId",
                principalTable: "requestModes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_requests_requestPeriorities_RequestPeriorityId",
                table: "requests",
                column: "RequestPeriorityId",
                principalTable: "requestPeriorities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_requests_requestStatuses_RequestStatusId",
                table: "requests",
                column: "RequestStatusId",
                principalTable: "requestStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_requests_requestSubCategories_RequestSubCategoryId",
                table: "requests",
                column: "RequestSubCategoryId",
                principalTable: "requestSubCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_requestSubCategories_requestCategories_RequestCategoryId",
                table: "requestSubCategories",
                column: "RequestCategoryId",
                principalTable: "requestCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SiteClients_clients_ClientId",
                table: "SiteClients",
                column: "ClientId",
                principalTable: "clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SiteClients_ProjectSites_ProjectSiteId",
                table: "SiteClients",
                column: "ProjectSiteId",
                principalTable: "ProjectSites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sites_City_CityId",
                table: "Sites",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sites_Governorate_GovernorateId",
                table: "Sites",
                column: "GovernorateId",
                principalTable: "Governorate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_stackeholders_projects_ProjectId",
                table: "stackeholders",
                column: "ProjectId",
                principalTable: "projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
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
                name: "FK_AssignedRequests_Employees_EmployeeId",
                table: "AssignedRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_AssignedRequests_projectPositions_ProjectPositionId",
                table: "AssignedRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_AssignedRequests_requests_RequestId",
                table: "AssignedRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_AssignedRequests_Teams_TeamId",
                table: "AssignedRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_City_Governorate_GovernorateId",
                table: "City");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_departments_DepartmentId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_mileStones_projects_ProjectId",
                table: "mileStones");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationClients_clients_ClientId",
                table: "OrganizationClients");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationClients_organizations_OrganizationId",
                table: "OrganizationClients");

            migrationBuilder.DropForeignKey(
                name: "FK_projectDocuments_projects_ProjectId",
                table: "projectDocuments");

            migrationBuilder.DropForeignKey(
                name: "FK_projects_Employees_EmployeeId",
                table: "projects");

            migrationBuilder.DropForeignKey(
                name: "FK_projects_organizations_OrganizationId",
                table: "projects");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectSiteAsset_assets_AssetId",
                table: "ProjectSiteAsset");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectSiteAsset_ProjectSites_ProjectSiteId",
                table: "ProjectSiteAsset");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectSiteAsset_Suppliers_SupplierId",
                table: "ProjectSiteAsset");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectSites_projects_ProjectId",
                table: "ProjectSites");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectSites_Sites_SiteId",
                table: "ProjectSites");

            migrationBuilder.DropForeignKey(
                name: "FK_projectTeams_departments_DepartmentId",
                table: "projectTeams");

            migrationBuilder.DropForeignKey(
                name: "FK_projectTeams_Employees_EmployeeId",
                table: "projectTeams");

            migrationBuilder.DropForeignKey(
                name: "FK_projectTeams_projectPositions_ProjectPositionId",
                table: "projectTeams");

            migrationBuilder.DropForeignKey(
                name: "FK_projectTeams_projects_ProjectId",
                table: "projectTeams");

            migrationBuilder.DropForeignKey(
                name: "FK_projectTeams_Teams_TeamId",
                table: "projectTeams");

            migrationBuilder.DropForeignKey(
                name: "FK_requestCategories_departments_DepartmentId",
                table: "requestCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestDescriptions_requests_RequestId",
                table: "RequestDescriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestImages_requests_requestId",
                table: "RequestImages");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestProblems_Employees_EmployeeId",
                table: "RequestProblems");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestProblems_Problems_ProblemId",
                table: "RequestProblems");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestProblems_requests_RequestId",
                table: "RequestProblems");

            migrationBuilder.DropForeignKey(
                name: "FK_requests_clients_ClientId",
                table: "requests");

            migrationBuilder.DropForeignKey(
                name: "FK_requests_ProjectSiteAsset_ProjectSiteAssetId",
                table: "requests");

            migrationBuilder.DropForeignKey(
                name: "FK_requests_projectTeams_ProjectTeamId",
                table: "requests");

            migrationBuilder.DropForeignKey(
                name: "FK_requests_requestModes_RequestModeId",
                table: "requests");

            migrationBuilder.DropForeignKey(
                name: "FK_requests_requestPeriorities_RequestPeriorityId",
                table: "requests");

            migrationBuilder.DropForeignKey(
                name: "FK_requests_requestStatuses_RequestStatusId",
                table: "requests");

            migrationBuilder.DropForeignKey(
                name: "FK_requests_requestSubCategories_RequestSubCategoryId",
                table: "requests");

            migrationBuilder.DropForeignKey(
                name: "FK_requestSubCategories_requestCategories_RequestCategoryId",
                table: "requestSubCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_SiteClients_clients_ClientId",
                table: "SiteClients");

            migrationBuilder.DropForeignKey(
                name: "FK_SiteClients_ProjectSites_ProjectSiteId",
                table: "SiteClients");

            migrationBuilder.DropForeignKey(
                name: "FK_Sites_City_CityId",
                table: "Sites");

            migrationBuilder.DropForeignKey(
                name: "FK_Sites_Governorate_GovernorateId",
                table: "Sites");

            migrationBuilder.DropForeignKey(
                name: "FK_stackeholders_projects_ProjectId",
                table: "stackeholders");

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
                name: "FK_AssignedRequests_Employees_EmployeeId",
                table: "AssignedRequests",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssignedRequests_projectPositions_ProjectPositionId",
                table: "AssignedRequests",
                column: "ProjectPositionId",
                principalTable: "projectPositions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssignedRequests_requests_RequestId",
                table: "AssignedRequests",
                column: "RequestId",
                principalTable: "requests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssignedRequests_Teams_TeamId",
                table: "AssignedRequests",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_City_Governorate_GovernorateId",
                table: "City",
                column: "GovernorateId",
                principalTable: "Governorate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_departments_DepartmentId",
                table: "Employees",
                column: "DepartmentId",
                principalTable: "departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_mileStones_projects_ProjectId",
                table: "mileStones",
                column: "ProjectId",
                principalTable: "projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationClients_clients_ClientId",
                table: "OrganizationClients",
                column: "ClientId",
                principalTable: "clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationClients_organizations_OrganizationId",
                table: "OrganizationClients",
                column: "OrganizationId",
                principalTable: "organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_projectDocuments_projects_ProjectId",
                table: "projectDocuments",
                column: "ProjectId",
                principalTable: "projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_projects_Employees_EmployeeId",
                table: "projects",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_projects_organizations_OrganizationId",
                table: "projects",
                column: "OrganizationId",
                principalTable: "organizations",
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
                name: "FK_ProjectSiteAsset_ProjectSites_ProjectSiteId",
                table: "ProjectSiteAsset",
                column: "ProjectSiteId",
                principalTable: "ProjectSites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectSiteAsset_Suppliers_SupplierId",
                table: "ProjectSiteAsset",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectSites_projects_ProjectId",
                table: "ProjectSites",
                column: "ProjectId",
                principalTable: "projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectSites_Sites_SiteId",
                table: "ProjectSites",
                column: "SiteId",
                principalTable: "Sites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_projectTeams_departments_DepartmentId",
                table: "projectTeams",
                column: "DepartmentId",
                principalTable: "departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_projectTeams_Employees_EmployeeId",
                table: "projectTeams",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_projectTeams_projectPositions_ProjectPositionId",
                table: "projectTeams",
                column: "ProjectPositionId",
                principalTable: "projectPositions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_projectTeams_projects_ProjectId",
                table: "projectTeams",
                column: "ProjectId",
                principalTable: "projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_projectTeams_Teams_TeamId",
                table: "projectTeams",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_requestCategories_departments_DepartmentId",
                table: "requestCategories",
                column: "DepartmentId",
                principalTable: "departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestDescriptions_requests_RequestId",
                table: "RequestDescriptions",
                column: "RequestId",
                principalTable: "requests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestImages_requests_requestId",
                table: "RequestImages",
                column: "requestId",
                principalTable: "requests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestProblems_Employees_EmployeeId",
                table: "RequestProblems",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestProblems_Problems_ProblemId",
                table: "RequestProblems",
                column: "ProblemId",
                principalTable: "Problems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestProblems_requests_RequestId",
                table: "RequestProblems",
                column: "RequestId",
                principalTable: "requests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_requests_clients_ClientId",
                table: "requests",
                column: "ClientId",
                principalTable: "clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_requests_ProjectSiteAsset_ProjectSiteAssetId",
                table: "requests",
                column: "ProjectSiteAssetId",
                principalTable: "ProjectSiteAsset",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_requests_projectTeams_ProjectTeamId",
                table: "requests",
                column: "ProjectTeamId",
                principalTable: "projectTeams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_requests_requestModes_RequestModeId",
                table: "requests",
                column: "RequestModeId",
                principalTable: "requestModes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_requests_requestPeriorities_RequestPeriorityId",
                table: "requests",
                column: "RequestPeriorityId",
                principalTable: "requestPeriorities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_requests_requestStatuses_RequestStatusId",
                table: "requests",
                column: "RequestStatusId",
                principalTable: "requestStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_requests_requestSubCategories_RequestSubCategoryId",
                table: "requests",
                column: "RequestSubCategoryId",
                principalTable: "requestSubCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_requestSubCategories_requestCategories_RequestCategoryId",
                table: "requestSubCategories",
                column: "RequestCategoryId",
                principalTable: "requestCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SiteClients_clients_ClientId",
                table: "SiteClients",
                column: "ClientId",
                principalTable: "clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SiteClients_ProjectSites_ProjectSiteId",
                table: "SiteClients",
                column: "ProjectSiteId",
                principalTable: "ProjectSites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sites_City_CityId",
                table: "Sites",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sites_Governorate_GovernorateId",
                table: "Sites",
                column: "GovernorateId",
                principalTable: "Governorate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_stackeholders_projects_ProjectId",
                table: "stackeholders",
                column: "ProjectId",
                principalTable: "projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
