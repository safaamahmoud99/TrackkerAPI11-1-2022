using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracker.Data.Models;

namespace Tracker.Domain.IRepositories
{
   public interface IDepartmentRepository 
    {
        IEnumerable<Department> GetAll();
        Department GetById(int id);
        Department GetDepartmentByEmployeeId(int EmployeeId);
        Department Find(int id);
        void Add(Department department);
        void Update(int id,Department department);
        void Delete(int id);
        void Save();
    }
}
