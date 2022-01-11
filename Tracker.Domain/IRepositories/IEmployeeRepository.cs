using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracker.Data.DTO;
using Tracker.Data.Models;

namespace Tracker.Domain.IRepositories
{
   public interface IEmployeeRepository 
    {
        IEnumerable<EmployeeDTO> GetAll();
        EmployeeDTO GetById(int id);
        List<EmployeeDTO> GetEmployeeByDepartmentId(int departmentId);
        Employee Find(int id);
        void Add(EmployeeDTO employeeDTO);
        void Update(int id,EmployeeDTO employeeDTO);
        void Delete(int id);
        void DeleteEmployeeAndProjectTeam(int EmployeeId);
        void Save();
    }
}
