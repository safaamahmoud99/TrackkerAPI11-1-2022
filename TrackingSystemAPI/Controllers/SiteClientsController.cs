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
    public class SiteClientsController : ControllerBase
    {
        private readonly ISiteClientsService _siteClientsService;

        public SiteClientsController(ISiteClientsService siteClientsService)
        {
            _siteClientsService = siteClientsService;
        }
        // GET: api/<SiteClientsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<SiteClientsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        [Route("GetAllAssignedClientsByProjectId/{ProjectId}")]
        public IEnumerable<ClientDTO> GetAllAssignedClientsByProjectId(int ProjectId)
        {
            return _siteClientsService.GetAllAssignedClientsByProjectId(ProjectId);
        }
        [Route("GetAllUnassignedClients/{SiteId}/{ProjectId}")]
        public IEnumerable<Client> GetAllUnassignedClients(int SiteId, int ProjectId)
        {
           return _siteClientsService.GetAllUnassignedClients(SiteId,ProjectId);
        }
        [Route("GetAllAssignedClients/{SiteId}/{ProjectId}")]
        public IEnumerable<Client> GetAllAssignedClients(int SiteId, int ProjectId)
        {
           return _siteClientsService.GetAllAssignedClients(SiteId,ProjectId);
        }
        [Route("GetAllUnassignedClientsforAnotherProjectAndAssignedByThisProjectId/{SiteId}/{ProjectId}")]
        public IEnumerable<Client> GetAllUnassignedClientsforAnotherProjectAndAssignedByThisProjectId(int SiteId, int ProjectId)
        {
           return _siteClientsService.GetAllUnassignedClientsforAnotherProjectAndAssignedByThisProjectId(SiteId,ProjectId);
        }
        // POST api/<SiteClientsController>
        [HttpPost]
        public void Post(SiteClientsDTO siteClientsDTO)
        {
            _siteClientsService.AddSiteClientsDTO(siteClientsDTO);
        }

        // PUT api/<SiteClientsController>/5
        [HttpPut("{projectSiteId}")]
        public async Task<IEnumerable<SiteClients>> Put(int projectSiteId, List<Client> clients)
        {
            return await _siteClientsService.UpdateByprojectSiteId(projectSiteId,clients);
        }
        // DELETE api/<SiteClientsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
