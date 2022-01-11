using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracker.Data.DTO;
using Tracker.Data.Models;

namespace Tracker.Domain.IRepositories
{
   public interface IRequestProblemRepository
    {
        IEnumerable<RequestProblemsDTO> GetAll();
        RequestProblemsDTO GetById(int id);
        IEnumerable<RequestProblemsDTO> GetAllRequestByProblemId(int ProblemId);
        RequestProblemsDTO GetProblemByEmployeeIdAndRequestId(int EmployeeId,int RequestId);
        RequestProblems Find(int id);
        void Add(RequestProblems requestProblems);
        void Update(int id,RequestProblems requestProblems);
        void Delete(int id);
        void Save();
    }
}
