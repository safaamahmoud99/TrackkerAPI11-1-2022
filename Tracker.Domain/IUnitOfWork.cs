using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Domain.IRepositories;

namespace Tracker.Domain
{
    //private readonly IUnitOfWork _unitOfWork;

    //public RequestService(IUnitOfWork unitOfWork)
    //{
    //    _unitOfWork = unitOfWork;
    //}
    public interface IUnitOfWork : IDisposable
    {
        IEmployeeRepository Employee { get; }
        IClientRepository Client { get; }
        IDepartmentRepository Department { get; }
        IMileStoneRepository MileStone { get; }
        IOrganizationRepository Organization { get; }
        IProjectDocumentRepository ProjectDocument { get; }
        IProjectRepository Project { get; }
        IProjectPositionRepository ProjectPosition { get; }
        IProjectTeamRepository ProjectTeam { get; }
        IRequestCategoryRepository RequestCategory { get; }
        IRequestPeriorityRepository RequestPeriority { get; }
        IRequestRepository Request { get; }
        IRequestStatusRepository RequestStatus { get; }
        IRequestSubCategoryRepository SubCategory { get; }
        IRequestTypeRepository RequestType { get; }
        IStackeholdersRepository Stackeholders  { get; }
        IAssetRepository Asset { get; }
        IRequestModeRepository RequestMode { get; }
        IRequestImageRepositories RequestImage { get; }
        ITeamRepository Team { get; }
        IRequestDescriptionRepository RequestDescription { get; }
        IAssignedRequestsRepository AssignedRequests { get; }
        IProblemsRepository Problems { get; }
        IRequestProblemRepository RequestProblem{ get; }
        IProjectTypeRepository ProjectType { get; }
        ISitesRepository Sites { get; }
        IOriginsRepository Origins { get; }
        IDueDateCategoryRepository DueDateCategory { get; }
        ISuppliersRepository Suppliers { get; }
        IBrandRepository Brand { get; }
        IProjectSitesRepository ProjectSites { get; }
        ISiteClientsRepository SiteClients { get; }
        IProjectSiteAssetRepository ProjectSiteAsset  { get; }
        IOrganizationClientsRepository OrganizationClients { get; }
    }
}
