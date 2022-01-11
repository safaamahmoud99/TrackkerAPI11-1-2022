using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data.DTO;
using Tracker.Data.Models;

namespace Tracker.Domain.IServices
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeDTO> GetAllEmployees();
        EmployeeDTO GetEmployeeById(int id);
        List<EmployeeDTO> GetEmployeeByDepartmentId(int departmentId);
        void AddEmployee(EmployeeDTO employeeDTO);
        void UpdateEmployee(int id,EmployeeDTO employeeDTO);
        void DeleteEmployee(int id);
        void DeleteEmployeeAndProjectTeam(int EmployeeId);
    }
}
