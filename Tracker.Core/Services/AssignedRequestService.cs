using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data.DTO;
using Tracker.Domain;
using Tracker.Domain.IServices;

namespace Tracker.Core.Services
{
    public class AssignedRequestService : IAssignedRequestService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AssignedRequestService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void AddAssignedRequest(AssignedRequestsDTO assignedRequestsDTO)
        {
            _unitOfWork.AssignedRequests.Add(assignedRequestsDTO);
        }

        public void DeleteAssignedRequest(int id)
        {
            _unitOfWork.AssignedRequests.Delete(id);
        }

        public IEnumerable<AssignedRequestsDTO> GetAllAssignedRequests()
        {
            return _unitOfWork.AssignedRequests.GetAll();
        }

        public IEnumerable<RequestDTO> GetAllRequestByEmployeeId(int EmployeeId)
        {
            return _unitOfWork.AssignedRequests.GetAllRequestByEmployeeId(EmployeeId);
        }

        public IEnumerable<RequestDTO> GetAllRequestByEmployeeIdAndTeamId(int EmployeeId, int TeamId)
        {
            return _unitOfWork.AssignedRequests.GetAllRequestByEmployeeIdAndTeamId(EmployeeId,TeamId);
        }

        public AssignedRequestsDTO GetAssignedRequestById(int id)
        {
            return _unitOfWork.AssignedRequests.GetById(id);
        }

        public void UpdateAssignedRequest(int id, AssignedRequestsDTO assignedRequestsDTO)
        {
            _unitOfWork.AssignedRequests.Update(id, assignedRequestsDTO);
        }
    }
}
