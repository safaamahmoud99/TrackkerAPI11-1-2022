using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracker.Data.DTO;
using Tracker.Data.Models;

namespace Tracker.Domain.IRepositories
{
    public interface IAssignedRequestsRepository 
    {
        IEnumerable<AssignedRequestsDTO> GetAll();
        AssignedRequestsDTO GetById(int id);
        IEnumerable<RequestDTO> GetAllRequestByEmployeeId(int EmployeeId);
        IEnumerable<RequestDTO> GetAllRequestByEmployeeIdAndTeamId(int EmployeeId, int TeamId);
        AssignedRequests Find(int id);
        void Add(AssignedRequestsDTO assignedRequestsDTO);
        void Update(int id,AssignedRequestsDTO assignedRequestsDTO);
        void Delete(int id);
        void Save();
    }
}
