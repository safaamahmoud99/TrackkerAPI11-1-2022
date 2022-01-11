using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracker.Data.DTO;
using Tracker.Data.Models;
using Tracker.Domain.IServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Tracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectSitesController : ControllerBase
    {
        private readonly IProjectSitesService _projectSitesService;

        public ProjectSitesController(IProjectSitesService projectSitesService)
        {
            _projectSitesService = projectSitesService;
        }
        // GET: api/<ProjectSitesController>
        [HttpGet]
        public IEnumerable<ProjectSitesDTO> Get()
        {
            return _projectSitesService.GetAllProjectSitesDTOs();
        }
        [Route("GetAllSitesByProjectId/{ProjectId}")]
        public IEnumerable<Sites> GetAllSitesByProjectId(int ProjectId)
        {
            return _projectSitesService.GetAllSitesByProjectId(ProjectId);
        }
        [Route("GetProjectSiteByProjectIdAndSiteId/{ProjectId}/{SiteId}")]
        public ProjectSites GetProjectSiteByProjectIdAndSiteId(int ProjectId, int SiteId)
        {
            return _projectSitesService.GetProjectSiteByProjectIdAndSiteId(ProjectId, SiteId);
        }
        // GET api/<ProjectSitesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProjectSitesController>
        [HttpPost]
        public void Post(ProjectSitesDTO projectSitesDTO)
        {
            _projectSitesService.AddProjectSitesDTO(projectSitesDTO);
        }

        // PUT api/<ProjectSitesController>/5
        [HttpPut("{ProjectId}")]
        public async Task<IEnumerable<ProjectSites>> Put(int ProjectId, List<Sites> LstSites)
        {
            return await _projectSitesService.Update(ProjectId, LstSites);
        }

        // DELETE api/<ProjectSitesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
