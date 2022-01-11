using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data.Models;

namespace Tracker.Domain.IRepositories
{
    public interface IDueDateCategoryRepository
    {
        IEnumerable<DueDateCategory> GetAll();
        DueDateCategory GetById(int id);
        void Add(DueDateCategory dueDateCategory);
        void Update(int id, DueDateCategory dueDateCategory);
        void Delete(int id);
    }
}
