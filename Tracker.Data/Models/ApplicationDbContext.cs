using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TrackingSystemAPI.DTO;

namespace Tracker.Data.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        //public ApplicationDbContext()
        //{

        //}
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Client> clients { get; set; }
        public DbSet<Department> departments { get; set; }
        public DbSet<MileStone> mileStones  { get; set; }
        public DbSet<Organization> organizations  { get; set; }
        public DbSet<Project> projects { get; set; }
        public DbSet<ProjectDocument>projectDocuments  { get; set; }
        public DbSet<ProjectPosition>projectPositions  { get; set; }
        public DbSet<ProjectTeam>projectTeams  { get; set; }
        public DbSet<Request>requests  { get; set; }
        public DbSet<RequestCategory>requestCategories  { get; set; }
        public DbSet<RequestPeriority>requestPeriorities  { get; set; }
        public DbSet<RequestStatus>requestStatuses  { get; set; }
        public DbSet<RequestSubCategory> requestSubCategories  { get; set; }
        public DbSet<Problems> requestTypes { get; set; }
        public DbSet<Stackeholders>stackeholders  { get; set; }
        public DbSet<ProjectType> projectTypes { get; set; }
        public DbSet<RequestMode> requestModes { get; set; }
        public DbSet<Asset> assets { get; set; }
        public DbSet<RequestDescription> RequestDescriptions { get; set; }
        public DbSet<requestImages> RequestImages { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<AssignedRequests> AssignedRequests { get; set; }
        public DbSet<Problems>  Problems{ get; set; }
        public DbSet<RequestProblems> RequestProblems { get; set; }
        public DbSet<DueDateCategory> DueDateCategory { get; set; }
        public DbSet<Origin>Origins { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<Supplier>Suppliers { get; set; }
        public DbSet<ProjectSiteAsset> ProjectSiteAsset { get; set; }
        public DbSet<ProjectSites> ProjectSites { get; set; }
        public DbSet<SiteClients> SiteClients { get; set; }
        public DbSet<Sites> Sites { get; set; }
       public DbSet<OrganizationClients> OrganizationClients { get; set; }














    }
}
