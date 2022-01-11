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
    public class ProjectPositionsController : ControllerBase
    {
        private readonly IProjectPositionService _projectPositionService;

        public ProjectPositionsController(IProjectPositionService projectPositionService)
        {
            _projectPositionService = projectPositionService;
        }

        // GET: api/ProjectPositions
        [HttpGet]
        public IEnumerable<ProjectPosition> GetprojectPositions()
        {
            return _projectPositionService.GetAllProjectPositions();
        }

        // GET: api/ProjectPositions/5
        [HttpGet("{id}")]
        public ActionResult<ProjectPosition> GetProjectPosition(int id)
        {
            var projectPosition = _projectPositionService.GetProjectPositionById(id);
            return projectPosition;
        }

        // PUT: api/ProjectPositions/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutProjectPosition(int id, ProjectPosition projectPosition)
        {
            _projectPositionService.UpdateProjectPosition(id, projectPosition);
            return CreatedAtAction("GetProjectPosition", new { id = projectPosition.Id }, projectPosition);
        }

        // POST: api/ProjectPositions
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult<ProjectPosition> PostProjectPosition(ProjectPosition projectPosition)
        {
            _projectPositionService.AddProjectPosition(projectPosition);
            return CreatedAtAction("GetProjectPosition", new { id = projectPosition.Id }, projectPosition);
        }
        // DELETE: api/ProjectPositions/5
        [HttpDelete("{id}")]
        public ActionResult<ProjectPosition> DeleteProjectPosition(int id)
        {
            _projectPositionService.DeleteProjectPosition(id);
            return Ok();
        }
    }
}
