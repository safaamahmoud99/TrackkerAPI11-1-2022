using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using  Tracker.Data.DTO;
using  Tracker.Data.Models;
using Tracker.Data.ViewModels;
using Tracker.Domain.IRepositories;
using Tracker.Domain.IServices;

namespace Tracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectTeamController : ControllerBase
    {
        private readonly IProjectTeamService _projectTeamService;

        public ProjectTeamController(IProjectTeamService projectTeamService)
        {
            _projectTeamService = projectTeamService;
        }
        // GET: api/ProjectTeam
        [HttpGet]
        public IEnumerable<ProjectTeamDTO> GetProjectTeamDTO()
        {
            return _projectTeamService.GetAllProjectTeams();
        }

        // GET: api/ProjectTeam/5
        [HttpGet("{id}")]
        public ActionResult<ProjectTeamDTO> GetProjectTeamDTO(int id)
        {
            var projectTeamDTO = _projectTeamService.GetProjectTeamById(id);
            return projectTeamDTO;
        }
        [HttpGet]
        [Route("GetProjectTeamsByProjectId/{ProjectId}")]
        public IEnumerable<ProjectTeamDTO> GetProjectTeamsByProjectId(int ProjectId)
        {
            return _projectTeamService.GetProjectTeamsByProjectId(ProjectId);
        }
        [HttpGet]
        [Route("GetProjectTeamsByProjectPositionId/{ProjectPositionId}")]
        public IEnumerable<ProjectTeamDTO> GetProjectTeamsByProjectPositionId(int ProjectPositionId)
        {
            return _projectTeamService.GetProjectTeamsByProjectPositionId(ProjectPositionId);
        }

        [HttpGet]
        [Route("GetEmployeessByTeamId/{TeamId}/{PositionId}")]
        public IEnumerable<ProjectTeamDTO> GetEmployeessByTeamId(int TeamId, int PositionId)
        {
            return _projectTeamService.GetEmployeessByTeamId(TeamId,PositionId);
        }
        [HttpGet]
        
        [Route("GetProjectTeamByProjectIdAndTeamIdAndProjectPositionId/{ProjectId}/{TeamId}/{ProjectPositionId}")]
        public ProjectTeamDTO GetProjectTeamByProjectIdAndTeamIdAndProjectPositionId(int ProjectId, int TeamId, int ProjectPositionId)
        {
            //ProjectPositionId may be 1 as teamLeader or 3 as ProjectManager
            return _projectTeamService.GetProjectTeamByProjectIdAndTeamIdAndProjectPositionId(ProjectId, TeamId, ProjectPositionId);
        }
        [HttpGet]
        [Route("GetProjectTeamByProjectPositionIdAndEmployeeId/{ProjectPositionId}/{EmployeeId}")]
        public IEnumerable<ProjectTeamDTO> GetProjectTeamByProjectPositionIdAndEmployeeId(int ProjectPositionId, int EmployeeId)
        {
            return _projectTeamService.GetProjectTeamByProjectPositionIdAndEmployeeId(ProjectPositionId, EmployeeId);
        }
        [HttpPost]
        [Route("GetAllProjectTeamsByProjectIds")]
        public List<ProjectTeamDTO> GetAllProjectTeamsByProjectIds(ProjectsVM model)
        {
            return _projectTeamService.GetAllProjectTeamsByProjectIds(model);
        }
        [HttpGet]
        [Route("GetTeamIdByEmployeeId/{EmployeeId}")]
        public ProjectTeamDTO GetTeamIdByEmployeeId(int EmployeeId)
        {
            return _projectTeamService.GetTeamIdByEmployeeId(EmployeeId);
        }
        [HttpGet]
        [Route("GetTeamLeaderByTeamIdAndProjectPositionId/{TeamId}/{ProjectPositionId}")]
        public ProjectTeamDTO GetTeamLeaderByTeamIdAndProjectPositionId(int TeamId, int ProjectPositionId)
        {
            return _projectTeamService.GetTeamLeaderByTeamIdAndProjectPositionId(TeamId,ProjectPositionId);
        }

        // PUT: api/ProjectTeam/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutProjectTeamDTO(int id, ProjectTeamDTO projectTeamDTO)
        {
            _projectTeamService.UpdateProjectTeam(id, projectTeamDTO);
            return CreatedAtAction("GetProjectTeamDTO", new { id = projectTeamDTO.ID }, projectTeamDTO);
        }

        //update by id
        [HttpPut("{id}")]
        [Route("updateteamsByProjectId/{id}")]
        public IActionResult PutteamssDTOByProjectId(int id, List<ProjectTeamDTO> projectTeamDTOs)
        {
            _projectTeamService.UpdateByProjectId(id, projectTeamDTOs);
            return CreatedAtAction("GetProjectTeamDTO", new { id = projectTeamDTOs.Count() }, projectTeamDTOs);
        }

        // POST: api/ProjectTeam
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public void PostProjectTeamDTO(List<ProjectTeamDTO> projectTeamDTO)
        {
            _projectTeamService.AddProjectTeam(projectTeamDTO);
            // return CreatedAtAction("GetProjectTeamDTO", new { id = projectTeamDTO.Count() }, projectTeamDTO);
        }

        // DELETE: api/ProjectTeam/5
        [HttpDelete("{id}")]
        public ActionResult<ProjectTeam> DeleteProjectTeamDTO(int id)
        {
            _projectTeamService.Delete(id);
            return Ok();
        }
    }
}
