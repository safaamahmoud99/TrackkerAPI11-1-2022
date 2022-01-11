using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracker.Data.DTO;
using Tracker.Domain.IServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Tracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectSiteAssetController : ControllerBase
    {
        private readonly IProjectSiteAssetService _projectSiteAssetService;

        public ProjectSiteAssetController(IProjectSiteAssetService projectSiteAssetService)
        {
            _projectSiteAssetService = projectSiteAssetService;
        }
        // GET: api/<ProjectSiteAssetController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        [Route("GetAllProjectSiteAssetBySiteId/{SiteId}/{ProjectId}")]
        public IEnumerable<ProjectSiteAssetDTO> GetAllProjectSiteAssetBySiteId(int SiteId, int ProjectId)
        {
            return _projectSiteAssetService.GetAllProjectSiteAssetBySiteId(SiteId, ProjectId);
        }
        [Route("GetAllProjectSiteAssetByProjectId/{ProjectId}")]
        public IEnumerable<ProjectSiteAssetDTO> GetAllProjectSiteAssetByProjectId(int ProjectId)
        {
            return _projectSiteAssetService.GetAllProjectSiteAssetByProjectId(ProjectId);
        }
        [Route("GetAllAssetsSerialsByAssetId/{AssetId}")]
        public IEnumerable<ProjectSiteAssetDTO> GetAllAssetsSerialsByAssetId(int AssetId)
        {
            return _projectSiteAssetService.GetAllAssetsSerialsByAssetId(AssetId);
        }
        [Route("GetProjectSiteAssetBySerialNumber/{SerialNumber}")]
        public ProjectSiteAssetDTO GetProjectSiteAssetBySerialNumber(string SerialNumber)
        {
            return _projectSiteAssetService.GetProjectSiteAssetBySerialNumber(SerialNumber);
        }
        // GET api/<ProjectSiteAssetController>/5
        [HttpGet("{id}")]
        public ProjectSiteAssetDTO Get(int id)
        {
            return _projectSiteAssetService.GetProjectSiteAssetDTOById(id);
        }

        // POST api/<ProjectSiteAssetController>
        [HttpPost]
        public void Post(ProjectSiteAssetDTO projectSiteAssetDTO)
        {
            _projectSiteAssetService.AddProjectSiteAssetDTO(projectSiteAssetDTO);
        }

        // PUT api/<ProjectSiteAssetController>/5
        [HttpPut("{id}")]
        public void Put(int id, ProjectSiteAssetDTO projectSiteAssetDTO)
        {
            _projectSiteAssetService.UpdateProjectSiteAssetDTO(id, projectSiteAssetDTO);
        }

        // DELETE api/<ProjectSiteAssetController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _projectSiteAssetService.DeleteProjectSiteAssetDTO(id);
            return Ok();
        }
    }
}
