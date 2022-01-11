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
    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void AddDepartment(Department department)
        {
            _unitOfWork.Department.Add(department);
        }

        public void DeleteDepartment(int id)
        {
            _unitOfWork.Department.Delete(id);
        }

        public IEnumerable<Department> GetAllDepartments()
        {
            return _unitOfWork.Department.GetAll();
        }

        public Department GetDepartmentByEmployeeId(int EmployeeId)
        {
           return _unitOfWork.Department.GetDepartmentByEmployeeId(EmployeeId);
        }

        public Department GetDepartmentById(int id)
        {
           return _unitOfWork.Department.GetById(id);
        }

        public void UpdateDepartment(int id, Department department)
        {
            _unitOfWork.Department.Update(id,department);
        }
    }
}
