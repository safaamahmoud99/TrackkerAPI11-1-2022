using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using  Tracker.Data.DTO;
using  Tracker.Data.Models;
using Tracker.Domain.IRepositories;
using Tracker.Domain.IServices;

namespace Tracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;
        
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        // GET: api/Project
        [HttpGet]
        public IEnumerable<ProjectDTO> GetProjectDTO()
        {
            return  _projectService.GetAllProjects();
        }

        // GET: api/Project/5
        [HttpGet("{id}")]
        public ActionResult<ProjectDTO> GetProjectDTO(int id)
        {
            var projectDTO = _projectService.GetProjectById(id); //await _context.ProjectDTO.FindAsync(id);
            return projectDTO;
        }
        [HttpGet]
        [Route("GetProjectsByClientId/{ClientId}")]
        public Project GetProjectsByClientId(int ClientId)
        {
            return _projectService.GetProjectsByClientId(ClientId);
        }
        [HttpGet]
        [Route("GetClientByProjectId/{ProjectId}")]
        public IEnumerable<ClientDTO> GetClientByProjectId(int ProjectId)
        {
            return _projectService.GetClientByProjectId(ProjectId);
        }
        // PUT: api/Project/5
        [HttpPut("{id}")]
        public IActionResult PutProjectDTO(int id, ProjectDTO projectDTO)
        {
            _projectService.UpdateProject(id, projectDTO);
            return CreatedAtAction("GetProjectDTO", new { id = projectDTO.Id }, projectDTO);
        }

        // POST: api/Project
        [HttpPost]
        public int PostProjectDTO(ProjectDTO projectDTO)
        {
            _projectService.AddProject(projectDTO);
            return projectDTO.Id;

        }
        // DELETE: api/Project/5
       /// [HttpPut]
        [HttpPut]
        [Route("SoftDelete/{id}")]
        public ActionResult<Project> DeleteProjectDTO(int id, ProjectDTO projectDTO)
        {
            _projectService.SoftDelete(projectDTO);
            return Ok();
        }
        [HttpGet]
        [Route("GetAllProjectsByEmployeeId/{EmployeeId}")]
        public IEnumerable<ProjectDTO> GetAllProjectsByEmployeeId(int EmployeeId)
        {
            var projectDTO = _projectService.GetAllProjectsByEmployeeId(EmployeeId); //await _context.ProjectDTO.FindAsync(id);
            return projectDTO;
        }
        //[HttpGet]
        //[Route("GetClientsByEmployeeId/{EmployeeId}")]
        //public IEnumerable<ProjectDTO> GetClientsByEmployeeId(int EmployeeId)
        //{
        //    var projectDTO = _projectService.GetClientsByEmployeeId(EmployeeId); //await _context.ProjectDTO.FindAsync(id);


        //    return projectDTO;
        //}
        [HttpGet]
        [Route("GetAllProjectsByProjectTypeId/{ProjectTypeId}")]
        public List<ProjectDTO> GetAllProjectsByProjectTypeId(int ProjectTypeId)
        {
            return _projectService.GetAllProjectsByProjectTypeId(ProjectTypeId);
        }
    }
}
