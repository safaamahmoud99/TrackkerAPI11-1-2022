using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracker.Data.Models;
using Tracker.Domain.IRepositories;

namespace Tracker.Core.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _context;
        public DepartmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(Department department)
        {
            try
            {
                if (department != null)
                {
                    _context.departments.Add(department);
                    _context.SaveChanges();

                }
                else
                {
                    throw new NotCompletedException("Not Completed Exception");
                }
            }
            catch (Exception)
            {
                throw new NotExistException("Not Exist Exception");
            }
        }

        public void Delete(int id)
        {
            Department department = _context.departments.Find(id);
            if (department != null)
            {
                _context.departments.Remove(department);
                _context.SaveChanges();
            }
            else
            {
                throw new NotExistException("Not Exist Exception");
            }
        }
        public Department Find(int id)
        {
            return _context.departments.Find(id);
        }

        public IEnumerable<Department> GetAll()
        {
          return  _context.departments.ToList();
        }

        public Department GetById(int id)
        {
            Department department= _context.departments.Where(d => d.Id == id).FirstOrDefault();
            if (department == null)
            {
                throw new NotExistException("Not Exist Exception");
            }
            else
            {
                return department;
            }           
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(int id,Department department)
        {
            if (id != department.Id)
            {
                throw new NotExistException("Not Exist Exception");
            }
           
            try
            {
                _context.Entry(department).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw new NotCompletedException("Not Completed Exception");
            }
        }
        public Department GetDepartmentByEmployeeId(int EmployeeId)
        {
            var dep = _context.Employees.Where(e => e.Id == EmployeeId).Select(d => new Department
            {
                Id = d.Department.Id,
                Name = d.Department.Name
            });
            return dep.FirstOrDefault();
        }
    }
}
