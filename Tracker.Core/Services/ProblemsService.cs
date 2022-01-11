using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data.Models;
using Tracker.Domain;
using Tracker.Domain.IServices;

namespace Tracker.Core.Services
{
    public class ProblemsService : IProblemsService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProblemsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void AddProblem(Problems problems)
        {
            _unitOfWork.Problems.Add(problems);
        }

        public void DeleteProblem(int id)
        {
            _unitOfWork.Problems.Delete(id);
        }

        public IEnumerable<Problems> GetAllProblems()
        {
            return _unitOfWork.Problems.GetAll();
        }

        public Problems GetProblemById(int id)
        {
           return _unitOfWork.Problems.GetById(id);
        }

        public void UpdateProblem(int id, Problems problems)
        {
            _unitOfWork.Problems.Update(id,problems);
        }
    }
}
