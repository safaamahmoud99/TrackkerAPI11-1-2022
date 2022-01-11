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
    public class RequestProblemRepository : IRequestProblemRepository
    {
        private readonly ApplicationDbContext _context;

        public RequestProblemRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(RequestProblems requestProblems)
        {
            try
            {
                if (requestProblems != null)
                {
                    _context.RequestProblems.Add(requestProblems);
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
            RequestProblems requestProblems = _context.RequestProblems.Find(id);
            if (requestProblems != null)
            {
                _context.RequestProblems.Remove(requestProblems);
                _context.SaveChanges();
            }
            else
            {
                throw new NotExistException("Not Exist Exception");
            }
        }
        public RequestProblems Find(int id)
        {
            return _context.RequestProblems.Find(id);
        }

        public IEnumerable<RequestProblemsDTO> GetAll()
        {
            var requestProblems = _context.RequestProblems.Include(r => r.Request).Select(reqProblem => new RequestProblemsDTO
            {
                Id = reqProblem.Id,
                RequestId = reqProblem.RequestId,
                RequestName = reqProblem.Request.RequestName,
                ProblemId = reqProblem.ProblemId,
                ProblemName = reqProblem.Problems.ProblemName

            }).ToList();
            return requestProblems;
        }

        public RequestProblemsDTO GetById(int id)
        {
            var requestProblems = _context.RequestProblems.Include(r => r.Request).Where(r => r.Id == id).Select(reqProblem => new RequestProblemsDTO
            {
                Id = reqProblem.Id,
                RequestId = reqProblem.RequestId,
                RequestName = reqProblem.Request.RequestName,
                ProblemId = reqProblem.ProblemId,
                ProblemName = reqProblem.Problems.ProblemName

            }).FirstOrDefault();
            if (requestProblems == null)
            {
                throw new NotExistException("Not Exist Exception");
            }
            else
            {
                return requestProblems;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(int id, RequestProblems requestProblems)
        {
            if (id != requestProblems.Id)
            {
                throw new NotExistException("Not Exist Exception");
            }
            try
            {
                _context.Entry(requestProblems).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw new NotCompletedException("Not Completed Exception");
            }
        }
        public IEnumerable<RequestProblemsDTO> GetAllRequestByProblemId(int ProblemId)
        {
            var requestsByProblemId = _context.RequestProblems.Where(r => r.ProblemId == ProblemId)
                .Include(r => r.Request.ProjectTeam).Include(r => r.Request.RequestPeriority)
                                             .Include(r => r.Request.RequestStatus).Include(r => r.Request.RequestSubCategory)
                                             .Include(r => r.Request.RequestMode)
                                             .Include(r => r.Request)
                                             .Select(reqProblem => new RequestProblemsDTO
                                             {
                                                 Id = reqProblem.Id,
                                                 EmployeeId = reqProblem.EmployeeId,
                                                 EmployeeName = reqProblem.Employee.EmployeeName,
                                                 ProblemId = reqProblem.ProblemId,
                                                 ProblemName = reqProblem.Problems.ProblemName,
                                                 RequestId = reqProblem.RequestId,
                                                 IsSolved = reqProblem.Request.IsSolved,
                                                 IsAssigned = reqProblem.Request.IsAssigned,
                                                 RequestName = reqProblem.Request.RequestName,
                                                 RequestCode = reqProblem.Request.RequestCode,
                                                 Description = reqProblem.Request.Description,
                                                 RequestDate = reqProblem.Request.RequestDate,
                                                 RequestTime = (reqProblem.Request.RequestTime).ToString(),
                                                 RequestModeId = reqProblem.Request.RequestModeId,
                                                 RequestMode = reqProblem.Request.RequestMode.Mode,
                                                 //AssetId = reqProblem.Request.AssetId,
                                                 //AssetCode = reqProblem.Request.Asset.AssetCode,
                                                 ClientId = reqProblem.Request.ClientId,
                                                 ClientName = reqProblem.Request.Client.ClientName,
                                                 RequestSubCategoryId = reqProblem.Request.RequestSubCategoryId,
                                                 RequestSubCategoryName = reqProblem.Request.RequestSubCategory.SubCategoryName,
                                                 ProjectTeamId = reqProblem.Request.ProjectTeamId,
                                                 ProjectName = reqProblem.Request.ProjectTeam.Project.ProjectName,
                                                 TeamName = reqProblem.Request.ProjectTeam.Team.Name,
                                                 RequestStatusId = reqProblem.Request.RequestStatusId,
                                                 RequestStatus = reqProblem.Request.RequestStatus.status,
                                                 RequestPeriorityId = reqProblem.Request.RequestPeriorityId,
                                                 RequestPeriority = reqProblem.Request.RequestPeriority.periorty,
                                             }).ToList();
            return requestsByProblemId;
        }

        public RequestProblemsDTO GetProblemByEmployeeIdAndRequestId(int EmployeeId, int RequestId)
        {
            var problemName = _context.RequestProblems.Where(r => r.EmployeeId == EmployeeId && r.RequestId == RequestId).Select(
                problem => new RequestProblemsDTO
                {
                    ProblemId = problem.Id,
                    ProblemName = problem.Problems.ProblemName
                }).FirstOrDefault();
            if (problemName == null)
            {
                throw new NotExistException("Not Exist Exception");
            }
            else
            {
                return problemName;
            }
        }
    }
}
