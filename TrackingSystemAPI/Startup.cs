using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using System.IO;
using Microsoft.AspNetCore.Http.Features;
using Tracker.Domain.IRepositories;
using Tracker.Data.Models;
using Tracker.Core.Repositories;
using Tracker.Domain.IServices;
using Tracker.Core.Services;
using Tracker.Domain;
using Tracker.Core;

namespace Tracker.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public object JwtBearerDefaults { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        [System.Obsolete]
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDirectoryBrowser();
            services.AddHttpContextAccessor();
            services.AddCors();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddControllers();
            services.AddControllers().AddNewtonsoftJson();

            // For Entity Framework  
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ConnStr")));
            //services.AddScoped<IEmployee, EmployeeService>();
            // For Identity  
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IMileStoneService, MileStoneService>();
            services.AddScoped<IOrganizationService, OrganizationService>();
            services.AddScoped<IProjectDocumentService, ProjectDocumentService>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IProjectPositionService, ProjectPositionService>();
            services.AddScoped<IProjectTeamService, ProjectTeamService>();
            services.AddScoped<IRequestCategoryService, RequestCategoryService>();
            services.AddScoped<IRequestPeriorityService, RequestPeriorityService>();
            services.AddScoped<IRequestService, RequestService>();
            services.AddScoped<IRequestStatusService, RequestStatusService>();
            services.AddScoped<IRequestSubCategoryService, RequestSubCategoryService>();
            services.AddScoped<IRequestTypeService, RequestTypeService>();
            services.AddScoped<IStackeholdersService, StackeholdersService>();
            services.AddScoped<IAssetService, AssetService>();
            services.AddScoped<IRequestModeService, RequestModeService>();
            services.AddScoped<IRequestImageService, RequestImageService>();
            services.AddScoped<ITeamService, TeamService>();
            services.AddScoped<IRequestDescriptionService, RequestDescriptionService>();
            services.AddScoped<IRequestDescriptionRepository, RequestDescriptionRepository>();
            services.AddScoped<IAssignedRequestService, AssignedRequestService>();
            services.AddScoped<IProblemsService, ProblemsService>();
            services.AddScoped<IRequestProblemService, RequestProblemService>();
            services.AddScoped<IProjectTypeService, ProjectTypeService>();
            services.AddScoped<ISitesService, SitesService>();
            services.AddScoped<IOriginsService, OriginsService>();
            services.AddScoped<ISuppliersService, SuppliersService>();
            services.AddScoped<IDueDateCategoryService, DueDateCategoryService>();
            services.AddScoped<IProjectSitesService, ProjectSitesService>();
            services.AddScoped<ISiteClientsService, SiteClientsService>();
            services.AddScoped<IProjectSiteAssetService, ProjectSiteAssetService>();
            services.AddScoped<IOrganizationClientsService, OrganizationClientsService>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Adding Authentication  
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme;
            })

            // Adding Jwt Bearer  
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = Configuration["JWT:ValidAudience"],
                    ValidIssuer = Configuration["JWT:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Secret"]))
                };
            });
            services.Configure<FormOptions>(o =>
            {
                o.ValueLengthLimit = int.MaxValue;
                o.MultipartBodyLengthLimit = int.MaxValue;
                o.MemoryBufferThreshold = int.MaxValue;
            });
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(
             //options => options.WithOrigins("http://localhost:4200.com").AllowAnyMethod()
             options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
           );
            app.UseStaticFiles(); // For the wwwroot folder.


            app.UseFileServer(new FileServerOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(env.ContentRootPath, "wwwroot")),
                RequestPath = "/wwwroot",
                EnableDirectoryBrowsing = true
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
