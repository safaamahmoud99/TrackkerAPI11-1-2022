using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracker.Data.DTO;
using Tracker.Data.Models;
using Tracker.Domain.IRepositories;

namespace Tracker.Core.Repositories
{
    public class AssignedRequestsRepository : IAssignedRequestsRepository
    {
        private readonly ApplicationDbContext _context;

        public AssignedRequestsRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(AssignedRequestsDTO assignedRequestsDTO)
        {
            try
            {
                if (assignedRequestsDTO != null)
                {
                    AssignedRequests assignedRequests = new AssignedRequests();
                    assignedRequests.TeamId = assignedRequestsDTO.TeamId;
                    assignedRequests.EmployeeId = assignedRequestsDTO.EmployeeId;
                    assignedRequests.ProjectPositionId = assignedRequestsDTO.ProjectPositionId;
                    assignedRequests.RequestId = assignedRequestsDTO.RequestId;
                    _context.AssignedRequests.Add(assignedRequests);
                    _context.SaveChanges();
                }
                else
                {
                    throw new NotCompletedException("Not Completed Exception");
                }
            }
            catch (Exception)
            {
                throw new NotExistException("Not Exist Exception");
            }
        }

        public void Delete(int id)
        {
            AssignedRequests assignedRequests = _context.AssignedRequests.Find(id);
            if (assignedRequests != null)
            {
                _context.AssignedRequests.Remove(assignedRequests);
                _context.SaveChanges();
            }
            else
            {
                throw new NotExistException("Not Exist Exception");
            }
        }
        public AssignedRequests Find(int id)
        {
            return _context.AssignedRequests.Find(id);
        }

        public IEnumerable<AssignedRequestsDTO> GetAll()
        {
            var AssignedRequests = _context.AssignedRequests.Include(a => a.ProjectPosition)
                .Include(a => a.Team).Include(a => a.Request)
                 .Select(assign => new AssignedRequestsDTO
                 {
                     Id = assign.Id,
                     EmployeeId = assign.EmployeeId,
                     EmployeeName = assign.Employee.EmployeeName,
                     ProjectName = assign.Request.ProjectTeam.Project.ProjectName,
                     TeamId = assign.TeamId,
                     TeamName = assign.Team.Name,
                     ProjectPositionId = assign.ProjectPositionId,
                     ProjectPositionName = assign.ProjectPosition.PositionName,
                     RequestId = assign.RequestId,
                     RequestName = assign.Request.RequestName
                 }).ToList();
            return AssignedRequests;
        }

        public AssignedRequestsDTO GetById(int id)
        {
            var assign = _context.AssignedRequests.Include(a => a.ProjectPosition).Include(a => a.Employee)
                                .Include(a => a.Team).Include(a => a.Request)
                                .Where(a => a.Id == id).FirstOrDefault();
            if (assign == null)
            {
                throw new NotExistException("Not Exist Exception");
            }
            else
            {
                var assignedRequestsDTO = new AssignedRequestsDTO
                {
                    Id = assign.Id,
                    EmployeeId = assign.EmployeeId,
                    EmployeeName = assign.Employee.EmployeeName,
                    ProjectName = assign.Request.ProjectTeam.Project.ProjectName,
                    TeamId = assign.TeamId,
                    TeamName = assign.Team.Name,
                    ProjectPositionId = assign.ProjectPositionId,
                    ProjectPositionName = assign.ProjectPosition.PositionName,
                    RequestId = assign.RequestId,
                    RequestName = assign.Request.RequestName
                };
                return assignedRequestsDTO;
            }

        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(int id, AssignedRequestsDTO assignedRequestsDTO)
        {
            AssignedRequests assignedRequests = new AssignedRequests();
            assignedRequests.TeamId = assignedRequestsDTO.TeamId;
            assignedRequests.RequestId = assignedRequestsDTO.RequestId;
            if (id != assignedRequestsDTO.Id)
            {
                throw new NotExistException("Not Exist Exception");
            }
            try
            {
                _context.Entry(assignedRequests).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw new NotCompletedException("Not Completed Exception");
            }
        }

        public IEnumerable<RequestDTO> GetAllRequestByEmployeeId(int EmployeeId)
        {
            var requests = _context.AssignedRequests.Where(r => r.EmployeeId == EmployeeId).Include(r => r.Employee).Include(r => r.ProjectPosition)
                      .Include(r => r.Request).Include(r => r.Team)
                      .Include(r => r.Request.ProjectTeam).Include(r => r.Request.RequestPeriority)
                                             .Include(r => r.Request.RequestStatus).Include(r => r.Request.RequestSubCategory)
                                             .Include(r => r.Request.RequestMode)
                      .Select(req => new RequestDTO
                      {
                          Id = req.RequestId,
                          RequestName = req.Request.RequestName,
                          RequestCode = req.Request.RequestCode,
                          Description = req.Request.Description,
                          RequestDate = req.Request.RequestDate,
                          RequestTime = (req.Request.RequestTime.Value.Hours + ":" + req.Request.RequestTime.Value.Minutes.ToString().PadLeft(2, '0')).ToString(),

                          RequestModeId = req.Request.RequestModeId,
                          RequestMode = req.Request.RequestMode.Mode,
                          //AssetId = req.Request.AssetId,
                          //AssetCode = req.Request.Asset.AssetCode,
                          ClientId = req.Request.ClientId,
                          ClientName = req.Request.Client.ClientName,
                          RequestSubCategoryId = req.Request.RequestSubCategoryId,
                          RequestSubCategoryName = req.Request.RequestSubCategory.SubCategoryName,
                          ProjectTeamId = req.Request.ProjectTeamId,
                          ProjectName = req.Request.ProjectTeam.Project.ProjectName,
                          RequestStatusId = req.Request.RequestStatusId,
                          RequestStatus = req.Request.RequestStatus.status,
                          RequestPeriorityId = req.Request.RequestPeriorityId,
                          RequestPeriority = req.Request.RequestPeriority.periorty,
                      }).ToList();
            return requests;
        }

        public IEnumerable<RequestDTO> GetAllRequestByEmployeeIdAndTeamId(int EmployeeId, int TeamId)
        {
            var requests = _context.AssignedRequests.Where(r => r.EmployeeId == EmployeeId && r.TeamId == TeamId).Include(r => r.Employee).Include(r => r.ProjectPosition)
                       .Include(r => r.Request).Include(r => r.Team)
                       .Include(r => r.Request.ProjectTeam).Include(r => r.Request.RequestPeriority)
                                              .Include(r => r.Request.RequestStatus).Include(r => r.Request.RequestSubCategory)
                                              .Include(r => r.Request.RequestMode)
                       .Select(req => new RequestDTO
                       {
                           Id = req.RequestId,
                           RequestName = req.Request.RequestName,
                           RequestCode = req.Request.RequestCode,
                           Description = req.Request.Description,
                           RequestDate = req.Request.RequestDate,
                           RequestTime = (req.Request.RequestTime.Value.Hours + ":" + req.Request.RequestTime.Value.Minutes.ToString().PadLeft(2, '0')).ToString(),

                           RequestModeId = req.Request.RequestModeId,
                           RequestMode = req.Request.RequestMode.Mode,
                           //AssetId = req.Request.AssetId,
                           //AssetCode = req.Request.Asset.AssetCode,
                           ClientId = req.Request.ClientId,
                           ClientName = req.Request.Client.ClientName,
                           RequestSubCategoryId = req.Request.RequestSubCategoryId,
                           RequestSubCategoryName = req.Request.RequestSubCategory.SubCategoryName,
                           ProjectTeamId = req.Request.ProjectTeamId,
                           RequestStatusId = req.Request.RequestStatusId,
                           RequestStatus = req.Request.RequestStatus.status,
                           RequestPeriorityId = req.Request.RequestPeriorityId,
                           RequestPeriority = req.Request.RequestPeriority.periorty,
                       }).ToList();
            return requests;
        }
    }
}
