using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using  Tracker.Data.Models;
using Tracker.Domain.IRepositories;
using Tracker.Domain.IServices;

namespace Tracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentsController(IDepartmentService departmentService)
        {
            _departmentService=departmentService;
        }

        // GET: api/Departments
        [HttpGet]
        public IEnumerable<Department> Getdepartments()
        {
            return _departmentService.GetAllDepartments(); 
        }

        // GET: api/Departments/5
        [HttpGet("{id}")]
        public ActionResult<Department> GetDepartment(int id)
        {
            var department =  _departmentService.GetDepartmentById(id);
            return department;
        }

        // PUT: api/Departments/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]

        public IActionResult PutDepartment(int id, Department department)
        {
            _departmentService.UpdateDepartment(id, department);
            return CreatedAtAction("GetDepartment", new { id = department.Id }, department);
        }

        // POST: api/Departments
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult<Department> PostDepartment(Department department)
        {
            _departmentService.AddDepartment(department);
            return CreatedAtAction("GetDepartment", new { id = department.Id }, department);
        }

        // DELETE: api/Departments/5
        [HttpDelete("{id}")]
        public ActionResult<Department> DeleteDepartment(int id)
        {
            _departmentService.DeleteDepartment(id);
            return Ok();
        }

        [HttpGet("GetDepartmentByEmployeeId/{EmployeeId}")]
        public Department GetDepartmentByEmployeeId(int EmployeeId)
        {
           return _departmentService.GetDepartmentByEmployeeId(EmployeeId);
        }
    }
}
