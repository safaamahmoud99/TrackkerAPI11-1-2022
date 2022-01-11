using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data.DTO;

namespace Tracker.Domain.IServices
{
    public interface IAssignedRequestService
    {
        IEnumerable<AssignedRequestsDTO> GetAllAssignedRequests();
        AssignedRequestsDTO GetAssignedRequestById(int id);
        IEnumerable<RequestDTO> GetAllRequestByEmployeeId(int EmployeeId);
        IEnumerable<RequestDTO> GetAllRequestByEmployeeIdAndTeamId(int EmployeeId, int TeamId);
        void AddAssignedRequest(AssignedRequestsDTO assignedRequestsDTO);
        void UpdateAssignedRequest(int id,AssignedRequestsDTO assignedRequestsDTO);
        void DeleteAssignedRequest(int id);
    }
}
