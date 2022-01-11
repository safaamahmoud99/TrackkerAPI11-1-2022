using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Core.Repositories;
using Tracker.Data.Models;
using Tracker.Domain;
using Tracker.Domain.IRepositories;

namespace Tracker.Core
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
        private bool disposed;
        private readonly ApplicationDbContext _context;
        private EmployeeRepository _employeeRepository;
        private ClientRepository _clientRepository;
        private DepartmentRepository _departmentRepository;
        private MileStoneRepository _mileStoneRepository;
        private OrganizationRepository _organizationRepository;
        private ProjectDocumentRepository _projectDocumentRepository;
        private ProjectRepository _projectRepository;
        private ProjectPositionRepository _projectPositionRepository;
        private ProjectTeamRepository _projectTeamRepository;
        private RequestCategoryRepository _requestCategoryRepository;
        private RequestPeriorityRepository _requestPeriorityRepository;
        private RequestRepository _requestRepository;
        private RequestProblemRepository _requestProblemRepository;
        private ProblemsRepository _problemsRepository;
        private AssignedRequestsRepository _assignedRequests;
        private RequestDescriptionRepository _requestDescriptionRepository;
        private TeamRepository _teamRepository;
        private RequestImageRepositories _requestImageRepositories;
        private RequestModeRepository _requestModeRepository;
        private AssetRepository _assetRepository;
        private StackeholdersRepository _stackeholdersRepository;
        private RequestTypeRepository _requestTypeRepository;
        private RequestSubCategoryRepository _requestSubCategoryRepository;
        private RequestStatusRepository _requestStatusRepository;
        private ProjectTypeRepository _projectType;
        private SitesRepository _sites;
        private OriginsRepository _origin;
        private DueDateCategoryRepository _dueDateCategory;
        private SupplierRepository _suppliers;
        private BrandRepository _brand;
        private ProjectSitesRepository _projectSites;
        private SiteClientsRepository _siteClients;
        private ProjectSiteAssetRepository _projectSiteAsset;
        private OrganizationClientsRepository _organizationClientsRepository;

        public IEmployeeRepository Employee => _employeeRepository = _employeeRepository ?? new EmployeeRepository(_context);
        public IClientRepository Client => _clientRepository = _clientRepository ?? new ClientRepository(_context);
        public IDepartmentRepository Department => _departmentRepository = _departmentRepository ?? new DepartmentRepository(_context);
        public IMileStoneRepository MileStone => _mileStoneRepository = _mileStoneRepository ?? new MileStoneRepository(_context);
        public IOrganizationRepository Organization => _organizationRepository = _organizationRepository ?? new OrganizationRepository(_context);
        public IProjectDocumentRepository ProjectDocument => _projectDocumentRepository = _projectDocumentRepository ?? new ProjectDocumentRepository(_context);
        public IProjectRepository Project => _projectRepository = _projectRepository ?? new ProjectRepository(_context);
        public IProjectPositionRepository ProjectPosition => _projectPositionRepository = _projectPositionRepository ?? new ProjectPositionRepository(_context);
        public IProjectTeamRepository ProjectTeam => _projectTeamRepository = _projectTeamRepository ?? new ProjectTeamRepository(_context);
        public IRequestCategoryRepository RequestCategory => _requestCategoryRepository = _requestCategoryRepository ?? new RequestCategoryRepository(_context);
        public IRequestPeriorityRepository RequestPeriority => _requestPeriorityRepository = _requestPeriorityRepository ?? new RequestPeriorityRepository(_context);
        public IRequestRepository Request => _requestRepository = _requestRepository ?? new RequestRepository(_context);
        public IRequestProblemRepository RequestProblem => _requestProblemRepository = _requestProblemRepository ?? new RequestProblemRepository(_context);
        public IProblemsRepository Problems => _problemsRepository = _problemsRepository ?? new ProblemsRepository(_context);
        public IAssignedRequestsRepository AssignedRequests => _assignedRequests = _assignedRequests ?? new AssignedRequestsRepository(_context);
        public IRequestDescriptionRepository RequestDescription => _requestDescriptionRepository= _requestDescriptionRepository ?? new RequestDescriptionRepository(_context);
        public ITeamRepository Team => _teamRepository = _teamRepository ?? new TeamRepository(_context);
        public IRequestImageRepositories RequestImage => _requestImageRepositories = _requestImageRepositories ?? new RequestImageRepositories(_context);
        public IRequestModeRepository RequestMode => _requestModeRepository = _requestModeRepository ?? new RequestModeRepository(_context);
        public IAssetRepository Asset => _assetRepository = _assetRepository ?? new AssetRepository(_context);
        public IStackeholdersRepository Stackeholders => _stackeholdersRepository = _stackeholdersRepository ?? new StackeholdersRepository(_context);
        public IRequestTypeRepository RequestType => _requestTypeRepository = _requestTypeRepository ?? new RequestTypeRepository(_context);
        public IRequestSubCategoryRepository SubCategory => _requestSubCategoryRepository = _requestSubCategoryRepository ?? new RequestSubCategoryRepository(_context);
        public IRequestStatusRepository RequestStatus => _requestStatusRepository = _requestStatusRepository ?? new RequestStatusRepository(_context);
        public IProjectTypeRepository ProjectType => _projectType = _projectType ?? new ProjectTypeRepository(_context);
        public ISitesRepository Sites => _sites = _sites ?? new SitesRepository(_context);
        public IOriginsRepository Origins => _origin = _origin ?? new OriginsRepository(_context);
        public IDueDateCategoryRepository DueDateCategory => _dueDateCategory = _dueDateCategory ?? new DueDateCategoryRepository(_context);
        public ISuppliersRepository Suppliers => _suppliers = _suppliers ?? new SupplierRepository(_context);
        public IBrandRepository Brand => _brand = _brand ?? new BrandRepository(_context);
        public IProjectSitesRepository ProjectSites => _projectSites = _projectSites ?? new ProjectSitesRepository(_context);
        public ISiteClientsRepository SiteClients => _siteClients = _siteClients ?? new SiteClientsRepository(_context);
        public IProjectSiteAssetRepository ProjectSiteAsset => _projectSiteAsset = _projectSiteAsset ?? new ProjectSiteAssetRepository(_context);
        public IOrganizationClientsRepository OrganizationClients => _organizationClientsRepository = _organizationClientsRepository ?? new OrganizationClientsRepository(_context);

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
