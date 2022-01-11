using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using  Tracker.Data.DTO;
using  Tracker.Data.Models;
using Tracker.Domain.IRepositories;
using Tracker.Domain.IServices;

namespace Tracker.API.Controllers
{
    //[Authorize(AuthenticationSchemes =
    //JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private IEmployeeService _employeeService;
        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet]
        public IEnumerable<EmployeeDTO> GetEmployees()
        {
            return _employeeService.GetAllEmployees();
        }
        [HttpGet("{id}")]
        public EmployeeDTO GetEmployee(int id)
        {
            return _employeeService.GetEmployeeById(id);
        }
        [HttpGet]
        [Route("GetEmployeeByDepartmentId/{departmentId}")]
        public List<EmployeeDTO> GetEmployeeByDepartmentId(int departmentId)
        {
            return _employeeService.GetEmployeeByDepartmentId(departmentId);
        }
        [HttpPost]
        public ActionResult<EmployeeDTO> PostEmployee(EmployeeDTO employeeDTO)
        {
            _employeeService.AddEmployee(employeeDTO);
            return CreatedAtAction("GetEmployee", new { id = employeeDTO.Id }, employeeDTO);
        }
        [HttpPost]
        [Route("api/dashboard/UploadImage")]
        public ActionResult UploadFile(IFormFile file)
        {
            var ImagesTypes = new List<string>() { "image/jpg", "image/jpeg", "image/png" };
            string path;
            if (ImagesTypes.Contains(file.ContentType))
            {
                path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/", file.FileName);
                using (Stream stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

            }
            else
            {
                return BadRequest();
            }
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpGet]
        [Route("getImage/{ImageName}")]
        public IActionResult ImageGet(string ImageName)
        {
            if (ImageName == null)
                return Content("filename not present");

            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot/images", ImageName);
            var memory = new MemoryStream();
            var ext = System.IO.Path.GetExtension(path);
            using (var stream = new FileStream(path, FileMode.Open))
            {
                stream.CopyTo(memory);
            }
            memory.Position = 0;
            var contentType = "APPLICATION/octet-stream";
            return File(memory, contentType, Path.GetFileName(path));
        }
        public IActionResult getFile(string FName)
        {
            if (FName == null)
                return Content("filename not present");

            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot/images/", FName);

            var memory = new MemoryStream();
            var ext = System.IO.Path.GetExtension(path);
            using (var stream = new FileStream(path, FileMode.Open))
            {
                stream.CopyTo(memory);
            }
            memory.Position = 0;
            var contentType = "APPLICATION/pdf";
            //return File(Path.GetFileName(path), contentType, FName);
            return File(memory, contentType, Path.GetFileName(path));
        }


        [HttpPut("{id}")]
        public IActionResult PutEmployee(int id, EmployeeDTO employeeDTO)
        {
            _employeeService.UpdateEmployee(id, employeeDTO);
            return CreatedAtAction("GetEmployee", new { id = employeeDTO.Id }, employeeDTO);

        }
        [HttpDelete("{id}")]
        public ActionResult<Employee> DeleteEmployee(int id)
        {
            _employeeService.DeleteEmployee(id);
            return Ok();
        }

    }
}
 