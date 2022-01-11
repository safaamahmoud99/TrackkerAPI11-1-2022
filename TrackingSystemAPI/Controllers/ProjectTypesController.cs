using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using  Tracker.Data.Models;
using Tracker.Data.ViewModels;
using Tracker.Domain.IServices;

namespace Tracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectTypesController : ControllerBase
    {
        private readonly IProjectTypeService _projectTypeService;

        public ProjectTypesController(IProjectTypeService  projectTypeService)
        {
            _projectTypeService = projectTypeService;
        }

        // GET: api/ProjectTypes
        [HttpGet]
        public IEnumerable<ProjectType> GetprojectTypes()
        {
            return  _projectTypeService.GetAllProjectTypes();
        }

        // GET: api/ProjectTypes/5
        [HttpGet("{id}")]
        public ActionResult<ProjectType> GetProjectType(int id)
        {
            var projectType = _projectTypeService.GetProjectTypeById(id);
            return projectType;
        }

        // PUT: api/ProjectTypes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutProjectType(int id, ProjectType projectType)
        {
            try
            {
                _projectTypeService.UpdateProjectType(id, projectType);
                return CreatedAtAction("GetProjectType", new { id = projectType.Id }, projectType);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "code", Message = ex.Message });
            }

        }

        // POST: api/ProjectTypes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult<ProjectType> PostProjectType(ProjectType projectType)
        {
            try
            {
                _projectTypeService.AddProjectType(projectType);
                return CreatedAtAction("GetProjectType", new { id = projectType.Id }, projectType);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "code", Message = ex.Message });
            }
        }

        // DELETE: api/ProjectTypes/5
        [HttpDelete("{id}")]
        public ActionResult<ProjectType> DeleteProjectType(int id)
        {
            _projectTypeService.DeleteProjectType(id);
            return Ok();
        }
    }
}
