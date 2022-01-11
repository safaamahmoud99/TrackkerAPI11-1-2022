using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data.Models;

namespace Tracker.Domain.IServices
{
    public interface IProblemsService
    {
        IEnumerable<Problems> GetAllProblems();
        Problems GetProblemById(int id);
        void AddProblem(Problems problems);
        void UpdateProblem(int id,Problems problems);
        void DeleteProblem(int id);
    }
}
