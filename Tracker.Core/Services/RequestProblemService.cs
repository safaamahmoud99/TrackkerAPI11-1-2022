using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data.DTO;
using Tracker.Data.Models;
using Tracker.Domain;
using Tracker.Domain.IServices;

namespace Tracker.Core.Services
{
    public class RequestProblemService : IRequestProblemService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RequestProblemService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void AddRequestProblem(RequestProblems requestProblems)
        {
            _unitOfWork.RequestProblem.Add(requestProblems);
        }

        public void DeleteRequestProblem(int id)
        {
            _unitOfWork.RequestProblem.Delete(id);
        }

        public IEnumerable<RequestProblemsDTO> GetAllRequestByProblemId(int ProblemId)
        {
            return _unitOfWork.RequestProblem.GetAllRequestByProblemId(ProblemId);
        }

        public IEnumerable<RequestProblemsDTO> GetAllRequestProblem()
        {
            return _unitOfWork.RequestProblem.GetAll();
        }

        public RequestProblemsDTO GetProblemByEmployeeIdAndRequestId(int EmployeeId, int RequestId)
        {
            return _unitOfWork.RequestProblem.GetProblemByEmployeeIdAndRequestId(EmployeeId, RequestId);
        }

        public RequestProblemsDTO GetRequestProblemById(int id)
        {
          return  _unitOfWork.RequestProblem.GetById(id);
        }

        public void UpdateRequestProblem(int id, RequestProblems requestProblems)
        {
            _unitOfWork.RequestProblem.Update(id,requestProblems);
        }
    }
}
