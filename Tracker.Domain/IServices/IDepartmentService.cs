using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data.Models;

namespace Tracker.Domain.IServices
{
    public interface IDepartmentService
    {
        IEnumerable<Department> GetAllDepartments();
        Department GetDepartmentById(int id);
        Department GetDepartmentByEmployeeId(int EmployeeId);
        void AddDepartment(Department department);
        void UpdateDepartment(int id, Department department);
        void DeleteDepartment(int id);
    }
}
