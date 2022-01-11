using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data.Models;

namespace Tracker.Domain.IServices
{
    public interface IDueDateCategoryService
    {
         IEnumerable<DueDateCategory> GetAllDueDateCategories();
        DueDateCategory GetDueDateCategoryById(int id);
        void AddDueDateCategory(DueDateCategory dueDateCategory);
        void UpdateDueDateCategory(int Id, DueDateCategory dueDateCategory);
        void DeleteDueDateCategory(int id);
    }
}
