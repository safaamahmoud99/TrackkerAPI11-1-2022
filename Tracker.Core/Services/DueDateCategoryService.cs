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
   public class DueDateCategoryService : IDueDateCategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DueDateCategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void AddDueDateCategory(DueDateCategory dueDateCategory)
        {
            _unitOfWork.DueDateCategory.Add(dueDateCategory);
        }

        public void DeleteDueDateCategory(int id)
        {
            _unitOfWork.DueDateCategory.Delete(id);
        }

        public IEnumerable<DueDateCategory> GetAllDueDateCategories()
        {
            return _unitOfWork.DueDateCategory.GetAll();
        }

        public DueDateCategory GetDueDateCategoryById(int id)
        {
            return _unitOfWork.DueDateCategory.GetById(id);
        }

        public void UpdateDueDateCategory(int Id, DueDateCategory dueDateCategory)
        {
            _unitOfWork.DueDateCategory.Update(Id, dueDateCategory);
        }
    }
}
