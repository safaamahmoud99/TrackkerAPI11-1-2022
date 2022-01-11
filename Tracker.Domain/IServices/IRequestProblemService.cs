using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data.DTO;
using Tracker.Data.Models;

namespace Tracker.Domain.IServices
{
   public interface IRequestProblemService
    {
        IEnumerable<RequestProblemsDTO> GetAllRequestProblem();
        RequestProblemsDTO GetRequestProblemById(int id);
        IEnumerable<RequestProblemsDTO> GetAllRequestByProblemId(int ProblemId);
        RequestProblemsDTO GetProblemByEmployeeIdAndRequestId(int EmployeeId, int RequestId);
        void AddRequestProblem(RequestProblems requestProblems);
        void UpdateRequestProblem(int id,RequestProblems requestProblems);
        void DeleteRequestProblem(int id);
    }
}
