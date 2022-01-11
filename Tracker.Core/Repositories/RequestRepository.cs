using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracker.Data.DTO;
using Tracker.Data.Models;
using Tracker.Domain.IRepositories;
using TrackingSystemAPI.DTO;

namespace Tracker.Core.Repositories
{
    public class RequestRepository : IRequestRepository
    {
        private readonly ApplicationDbContext _context;
        public RequestRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public int Add(RequestDTO requestDTO)
        {
            try
            {
                if (requestDTO != null)
                {
                    var dtStartTime = DateTime.Parse(requestDTO.RequestTime).ToString("HH:mm:ss");
                    Request request = new Request();
                    string Req = "Req";
                    string requestCode = "";
                    var lstIds = _context.requests.ToList();
                    if (lstIds.Count > 0)
                    {
                        var code = lstIds.LastOrDefault().Id;
                        requestCode = Req + (code + 1);
                    }
                    else
                    {
                        requestCode = Req + 1;
                    }
                    request.IsAssigned = false;
                    request.IsSolved = false;
                    request.RequestName = requestDTO.RequestName;
                    request.RequestCode = requestCode;
                    request.Description = requestDTO.Description;
                    request.RequestDate = DateTime.Now; //requestDTO.RequestDate;
                    request.RequestTime = TimeSpan.Parse(dtStartTime);
                    request.RequestModeId = requestDTO.RequestModeId;
                    //request.AssetId = requestDTO.AssetId;
                    request.RequestSubCategoryId = requestDTO.RequestSubCategoryId;
                    request.ProjectTeamId = requestDTO.ProjectTeamId;
                    request.ClientId = requestDTO.ClientId;
                    request.RequestStatusId = requestDTO.RequestStatusId;
                    request.RequestPeriorityId = requestDTO.RequestPeriorityId;
                    request.CreatedById = requestDTO.CreatedById;
                    request.ProjectSiteAssetId = requestDTO.ProjectSiteAssetId;
                    _context.requests.Add(request);
                    _context.SaveChanges();
                    requestDTO.Id=request.Id;
                    return requestDTO.Id;
                }
                else
                {
                    throw new NotCompletedException("Not Completed Exception");
                }
            }
            catch (Exception ex)
            {
                string test = ex.Message;
                throw new NotExistException("Not Exist Exception");
            }
            //InnerException = {"The INSERT statement conflicted with the FOREIGN KEY constraint \"FK_requests_ProjectSiteAsset_ProjectSiteAssetId\". The conflict occurred in database \"TrackingDB\", table \"dbo.ProjectSiteAsset\", column 'Id'.\r\nThe statement has been terminated."}
        }
        public void Delete(int id)
        {
            Request request = _context.requests.Find(id);
            if (request != null)
            {
                _context.requests.Remove(request);
                _context.SaveChanges();
            }
            else
            {
                throw new NotExistException("Not Exist Exception");
            }
        }
        public Request Find(int id)
        {
            return _context.requests.Find(id);
        }

        public IEnumerable<RequestDTO> GetAll()
        {
            var request = _context.requests.Include(r => r.ProjectTeam).Include(r => r.RequestPeriority)
                                             .Include(r => r.RequestStatus).Include(r => r.RequestSubCategory)
                                             .Include(r => r.RequestMode).Include(r => r.User)
                                             .Select(req => new RequestDTO
                                             {
                                                 Id = req.Id,
                                                 IsSolved = req.IsSolved,
                                                 IsAssigned = req.IsAssigned,
                                                 RequestName = req.RequestName,
                                                 RequestCode = req.RequestCode,
                                                 Description = req.Description,
                                                 RequestDate = req.RequestDate,
                                                 RequestTime = (req.RequestTime).ToString(),
                                                 RequestModeId = req.RequestModeId,
                                                 RequestMode = req.RequestMode.Mode,
                                                 //AssetId = req.AssetId,
                                                 //AssetCode = req.Asset.AssetCode,
                                                 ClientId = req.ClientId,
                                                 ClientName = req.Client.ClientName,
                                                 RequestSubCategoryId = req.RequestSubCategoryId,
                                                 RequestSubCategoryName = req.RequestSubCategory.SubCategoryName,
                                                 ProjectTeamId = req.ProjectTeamId,
                                                 ProjectName = req.ProjectTeam.Project.ProjectName,
                                                 TeamName = req.ProjectTeam.Team.Name,
                                                 RequestStatusId = req.RequestStatusId,
                                                 RequestStatus = req.RequestStatus.status,
                                                 RequestPeriorityId = req.RequestPeriorityId,
                                                 RequestPeriority = req.RequestPeriority.periorty,
                                                 ProjectSiteAssetId = req.ProjectSiteAssetId,
                                                 CreatedById = req.CreatedById,
                                                 CreatedBy = req.User.UserName,
                                             }).OrderByDescending(p => p.Id).ToList();
            return request;
        }

        public RequestDTO GetById(int id)
        {
            var request = _context.requests.Include(p => p.Client).Include(p => p.ProjectTeam).
               
               Include(p => p.RequestMode).Include(r => r.User).
               Include(p => p.RequestPeriority).Include(p => p.RequestStatus).
               Include(p => p.RequestSubCategory).
               FirstOrDefault(e => e.Id == id);

            if (request == null)
            {
                throw new NotExistException("Not Exist Exception");
            }
            else
            {
                var requestDTO = new RequestDTO
                {
                    Id = request.Id,
                    RequestName = request.RequestName,
                    RequestStatus = request.RequestStatus.status,
                    //AssetCode = request.Asset.AssetCode,
                    //AssetId = request.AssetId,
                    ClientId = request.ClientId,
                    ClientName = request.Client.ClientName,
                    Description = request.Description,
                    IsAssigned = request.IsAssigned,
                    IsSolved = request.IsSolved,
                    ProjectTeamId = request.ProjectTeamId,
                    RequestCode = request.RequestCode,
                    RequestDate = request.RequestDate,
                    RequestMode = request.RequestMode.Mode,
                    RequestModeId = request.RequestModeId,
                    RequestPeriority = request.RequestPeriority.periorty,
                    RequestPeriorityId = request.RequestPeriorityId,
                    RequestStatusId = request.RequestStatusId,
                    RequestSubCategoryId = request.RequestSubCategoryId,
                    RequestSubCategoryName = request.RequestSubCategory.SubCategoryName,
                    ProjectSiteAssetId=request.ProjectSiteAssetId,
                    CreatedById=request.CreatedById,
                    CreatedBy=request.User.UserName,
                    RequestTime = request.RequestTime.ToString()
                };
                return requestDTO;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(int Id, RequestDTO requestDTO)
        {
            if (Id != requestDTO.Id)
            {
                throw new NotExistException("Not Exist Exception");
            }
            try
            {
                Request request = new Request();
                request.Id = requestDTO.Id;
                request.IsSolved = requestDTO.IsSolved;
                request.IsAssigned = requestDTO.IsAssigned;
                request.RequestName = requestDTO.RequestName;
                request.RequestCode = requestDTO.RequestCode;
                request.Description = requestDTO.Description;
                request.RequestDate = requestDTO.RequestDate;
                request.RequestTime = TimeSpan.Parse(requestDTO.RequestTime);
                request.RequestModeId = requestDTO.RequestModeId;
                //request.AssetId = requestDTO.AssetId;
                request.RequestSubCategoryId = requestDTO.RequestSubCategoryId;
                request.ProjectTeamId = requestDTO.ProjectTeamId;
                request.ClientId = requestDTO.ClientId;
                request.RequestStatusId = requestDTO.RequestStatusId;
                request.RequestPeriorityId = requestDTO.RequestPeriorityId;
                request.CreatedById = requestDTO.CreatedById;
                request.ProjectSiteAssetId = requestDTO.ProjectSiteAssetId;
                _context.Entry(request).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw new NotCompletedException("Not Completed Exception");
            }

        }

        public IEnumerable<RequestDTO> GetProjectTeamsByProjectId(int ProjectId)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<RequestDTO> GetAllRequestByClientId(int ClientId)
        {
            var requests = _context.requests.Where(r => r.ClientId == ClientId).Include(r => r.ProjectTeam).Include(r => r.RequestPeriority)
                                             .Include(r => r.RequestStatus).Include(r => r.RequestSubCategory)
                                             .Include(r => r.RequestMode).Include(r => r.User)
                                             .Select(req => new RequestDTO
                                             {
                                                 Id = req.Id,
                                                 IsSolved = req.IsSolved,
                                                 IsAssigned = req.IsAssigned,
                                                 RequestName = req.RequestName,
                                                 RequestCode = req.RequestCode,
                                                 Description = req.Description,
                                                 RequestDate = req.RequestDate,
                                                 RequestTime = (req.RequestTime.Value.Hours + ":" + req.RequestTime.Value.Minutes.ToString().PadLeft(2, '0')).ToString(),

                                                 RequestModeId = req.RequestModeId,
                                                 RequestMode = req.RequestMode.Mode,
                                                 //AssetId = req.AssetId,
                                                 //AssetCode = req.Asset.AssetCode,
                                                 ClientId = req.ClientId,
                                                 ClientName = req.Client.ClientName,
                                                 RequestSubCategoryId = req.RequestSubCategoryId,
                                                 RequestSubCategoryName = req.RequestSubCategory.SubCategoryName,
                                                 ProjectTeamId = req.ProjectTeamId,
                                                 ProjectName = req.ProjectTeam.Project.ProjectName,
                                                 TeamName = req.ProjectTeam.Team.Name,
                                                 RequestStatusId = req.RequestStatusId,
                                                 RequestStatus = req.RequestStatus.status,
                                                 RequestPeriorityId = req.RequestPeriorityId,
                                                 RequestPeriority = req.RequestPeriority.periorty,
                                                 ProjectSiteAssetId = req.ProjectSiteAssetId,
                                                 CreatedById = req.CreatedById,
                                                 CreatedBy = req.User.UserName
                                             }).OrderByDescending(p => p.Id).ToList();
            return requests;
        }
        public IEnumerable<RequestDTO> GetAllRequestByProjectId(int ProjectId)
        {
            var requests = _context.requests.Where(r => r.ProjectSiteAsset.ProjectSites.ProjectId == ProjectId)
                .Include(r => r.ProjectTeam).Include(r => r.RequestPeriority).Include(r => r.ProjectSiteAsset.Asset)
                .Include(r => r.ProjectSiteAsset.ProjectSites.Sites).Include(r => r.RequestStatus).Include(r => r.RequestSubCategory)
                                             .Include(r => r.RequestMode).Include(r => r.User)
                                             .Select(req => new RequestDTO
                                             {
                                                 Id = req.Id,
                                                 IsSolved = req.IsSolved,
                                                 IsAssigned = req.IsAssigned,
                                                 RequestName = req.RequestName,
                                                 RequestCode = req.RequestCode,
                                                 Description = req.Description,
                                                 RequestDate = req.RequestDate,
                                                 RequestTime = (req.RequestTime.Value.Hours + ":" + req.RequestTime.Value.Minutes.ToString().PadLeft(2, '0')).ToString(),
                                                 RequestModeId = req.RequestModeId,
                                                 RequestMode = req.RequestMode.Mode,
                                                 AssetId = req.ProjectSiteAsset.AssetId,
                                                 AssetName = req.ProjectSiteAsset.Asset.AssetName,
                                                 SerialNumber=req.ProjectSiteAsset.SerialNumber,
                                                 Sitename=req.ProjectSiteAsset.ProjectSites.Sites.Sitename,
                                                 ClientId = req.ClientId,
                                                 ClientName = req.Client.ClientName,
                                                 RequestSubCategoryId = req.RequestSubCategoryId,
                                                 RequestSubCategoryName = req.RequestSubCategory.SubCategoryName,
                                                 ProjectTeamId = req.ProjectTeamId,
                                                 ProjectName = req.ProjectTeam.Project.ProjectName,
                                                 TeamName = req.ProjectTeam.Team.Name,
                                                 RequestStatusId = req.RequestStatusId,
                                                 RequestStatus = req.RequestStatus.status,
                                                 RequestPeriorityId = req.RequestPeriorityId,
                                                 RequestPeriority = req.RequestPeriority.periorty,
                                                 ProjectSiteAssetId = req.ProjectSiteAssetId,
                                                 CreatedById = req.CreatedById,
                                                 CreatedBy = req.User.UserName,
                                             }).OrderByDescending(p => p.Id).ToList();
            return requests;
        }

        public List<RequestDTO> GetAllRequestByProjectTeamId(ProjectTeamVM model)
        {
            List<RequestDTO> requestDTO = new List<RequestDTO>();
            var Ids = model.ProjectTeamIds.Split(",");
            string[] lstIds = Ids;
            foreach (var item in lstIds)
            {
                int id = int.Parse(item);
                var request = _context.requests.Where(r => r.ProjectTeamId == id)
                                            .Include(r => r.ProjectTeam).Include(r => r.RequestPeriority)
                                            .Include(r => r.RequestStatus).Include(r => r.RequestSubCategory)
                                            .Include(r => r.RequestMode).Include(r => r.User)
                                            .Select(req => new RequestDTO
                                            {
                                                Id = req.Id,
                                                IsSolved = req.IsSolved,
                                                IsAssigned = req.IsAssigned,
                                                RequestName = req.RequestName,
                                                RequestCode = req.RequestCode,
                                                Description = req.Description,
                                                RequestDate = req.RequestDate,
                                                RequestTime = (req.RequestTime).ToString(),

                                                RequestModeId = req.RequestModeId,
                                                RequestMode = req.RequestMode.Mode,
                                                //AssetId = req.AssetId,
                                                //AssetCode = req.Asset.AssetCode,
                                                ClientId = req.ClientId,
                                                ClientName = req.Client.ClientName,
                                                RequestSubCategoryId = req.RequestSubCategoryId,
                                                RequestSubCategoryName = req.RequestSubCategory.SubCategoryName,
                                                ProjectTeamId = req.ProjectTeamId,
                                                ProjectName = req.ProjectTeam.Project.ProjectName,
                                                TeamName = req.ProjectTeam.Team.Name,
                                                RequestStatusId = req.RequestStatusId,
                                                RequestStatus = req.RequestStatus.status,
                                                RequestPeriorityId = req.RequestPeriorityId,
                                                RequestPeriority = req.RequestPeriority.periorty,
                                                ProjectSiteAssetId = req.ProjectSiteAssetId,
                                                CreatedById = req.CreatedById,
                                                CreatedBy = req.User.UserName
                                            }).OrderByDescending(p => p.Id).ToList();

                foreach (var item2 in request)
                {
                    requestDTO.Add(item2);
                }
            }
            return requestDTO;
        }

        public List<RequestDTO> GetAllRequestByRequestStatus(int requestStatusId)
        {
            var request = _context.requests.Where(e => e.RequestStatusId == requestStatusId).Select(req => new RequestDTO
            {
                RequestStatusId = req.RequestStatusId,
                Id = req.Id,
                //AssetId = req.AssetId,
                RequestName = req.RequestName
            }).OrderByDescending(p => p.Id).ToList();
            return request;
        }
        public IEnumerable<RequestDTO> GetAllRequestByProjectSiteAssetId(int ProjectSiteAssetId)
        {
            if (ProjectSiteAssetId == 0)
            {
                throw new NotExistException("Not Exist Exception");
            }
            else
            {
                var requestDTO = _context.requests.Where(e => e.ProjectSiteAssetId == ProjectSiteAssetId).Select(request => new RequestDTO
                {
                    Id = request.Id,
                    RequestName = request.RequestName,
                    ProjectSiteAssetId = request.ProjectSiteAssetId,
                }).ToList();
                if (requestDTO == null)
                {
                    throw new NotExistException("Not Exist Exception");
                }
                else
                {
                    return requestDTO;
                }
            }

        }
        public RequestDTO GetAllRequestByRequestStatusAndProjectTeamId(int requestStatusId, int ProjectTeamId)
        {
            if (requestStatusId == 0 && ProjectTeamId == 0)
            {
                throw new NotExistException("Not Exist Exception");
            }
            else
            {
                var request = _context.requests.Include(p => p.Client).Include(p => p.ProjectTeam).                              
                              Include(p => p.RequestMode).
                              Include(p => p.RequestPeriority).Include(p => p.RequestStatus).
                              Include(p => p.RequestSubCategory).Include(r => r.User).
                              FirstOrDefault(e => e.RequestStatusId == requestStatusId && e.ProjectTeamId == ProjectTeamId);
                if (request == null)
                {
                    throw new NotExistException("Not Exist Exception");
                }
                else
                {
                    var requestDTO = new RequestDTO
                    {
                        Id = request.Id,
                        RequestName = request.RequestName,
                        RequestStatus = request.RequestStatus.status,
                        //AssetCode = request.Asset.AssetCode,
                        //AssetId = request.AssetId,
                        ClientId = request.ClientId,
                        ClientName = request.Client.ClientName,
                        Description = request.Description,
                        IsAssigned = request.IsAssigned,
                        IsSolved = request.IsSolved,
                        ProjectTeamId = request.ProjectTeamId,
                        RequestCode = request.RequestCode,
                        RequestDate = request.RequestDate,
                        RequestMode = request.RequestMode.Mode,
                        RequestModeId = request.RequestModeId,
                        RequestPeriority = request.RequestPeriority.periorty,
                        RequestPeriorityId = request.RequestPeriorityId,
                        RequestStatusId = request.RequestStatusId,
                        RequestSubCategoryId = request.RequestSubCategoryId,
                        RequestSubCategoryName = request.RequestSubCategory.SubCategoryName,
                        ProjectSiteAssetId = request.ProjectSiteAssetId,
                        CreatedById = request.CreatedById,
                        CreatedBy = request.User.UserName,
                        RequestTime = request.RequestTime.ToString()
                    };
                    return requestDTO;
                }
            }

        }

        public int CountProjects(int projectId)
        {
            return (from req in _context.requests
                    join projectteam in _context.projectTeams on req.ProjectTeamId equals projectteam.Id
                    join proj in _context.projects on projectteam.ProjectId equals proj.Id
                    where proj.Id == projectId
                    select proj).ToList().Count;
        }


        public int CountClosedProjects(int projectId)
        {
            return (from req in _context.requests
                    join projectteam in _context.projectTeams on req.ProjectTeamId equals projectteam.Id
                    join proj in _context.projects on projectteam.ProjectId equals proj.Id
                    where req.RequestStatusId == 2
                    where proj.Id == projectId
                    select proj).ToList().Count;
        }

        public int CountOpenProjects(int projectId)
        {
            return (from req in _context.requests
                    join projectteam in _context.projectTeams on req.ProjectTeamId equals projectteam.Id
                    join proj in _context.projects on projectteam.ProjectId equals proj.Id
                    where req.RequestStatusId == 1
                    where proj.Id == projectId
                    select proj).ToList().Count;
        }
        public int CountInProgressProjects(int projectId)
        {
            return (from req in _context.requests
                    join projectteam in _context.projectTeams on req.ProjectTeamId equals projectteam.Id
                    join proj in _context.projects on projectteam.ProjectId equals proj.Id
                    where req.RequestStatusId == 3
                    where proj.Id == projectId
                    select proj).ToList().Count;
        }
    }
}
