using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data.DTO;
using Tracker.Domain;
using Tracker.Domain.IServices;

namespace Tracker.Core.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void AddEmployee(EmployeeDTO employeeDTO)
        {
            _unitOfWork.Employee.Add(employeeDTO);
        }

        public void DeleteEmployee(int id)
        {
            _unitOfWork.Employee.Delete(id);
        }

        public void DeleteEmployeeAndProjectTeam(int EmployeeId)
        {
            _unitOfWork.Employee.DeleteEmployeeAndProjectTeam(EmployeeId);
        }

        public IEnumerable<EmployeeDTO> GetAllEmployees()
        {
            return _unitOfWork.Employee.GetAll();
        }

        public List<EmployeeDTO> GetEmployeeByDepartmentId(int departmentId)
        {
            return _unitOfWork.Employee.GetEmployeeByDepartmentId(departmentId);
        }

        public EmployeeDTO GetEmployeeById(int id)
        {
            return _unitOfWork.Employee.GetById(id);
        }

        public void UpdateEmployee(int id, EmployeeDTO employeeDTO)
        {
            _unitOfWork.Employee.Update(id,employeeDTO);
        }
    }
}
