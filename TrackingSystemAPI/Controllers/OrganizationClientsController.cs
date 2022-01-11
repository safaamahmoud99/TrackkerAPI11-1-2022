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
    public class OrganizationClientsController : ControllerBase
    {
        private readonly IOrganizationClientsService _organizationClientsService;

        public OrganizationClientsController(IOrganizationClientsService organizationClientsService)
        {
            _organizationClientsService = organizationClientsService;
        }
        // GET: api/<OrganizationClientsController>
        [HttpGet]
        public IEnumerable<OrganizationClientsDTO> Get()
        {
            return  _organizationClientsService.GetAll();
        }
        [Route("GetOrganizationProjectsByClientId/{ClientId}")]

         public IEnumerable<ProjectDTO> GetOrganizationProjectsByClientId(int ClientId)
        {
            return _organizationClientsService.GetOrganizationProjectsByClientId(ClientId);
        }
        [Route("GetAllUnassignedClients")]
        public IEnumerable<Client> GetAllUnassignedClients()
        {
            return _organizationClientsService.GetAllUnassignedClients();
        }
        [Route("GetAllAssignedClientsByOrganizationId/{OrganizationId}")]
        public IEnumerable<Client> GetAllAssignedClientsByOrganizationId(int OrganizationId)
        {
            return _organizationClientsService.GetAllAssignedClientsByOrganizationId(OrganizationId);
        }
        [Route("GetAllAssignedClientsDataByOrganizationId/{OrganizationId}")]
        public IEnumerable<Client> GetAllAssignedClientsDataByOrganizationId(int OrganizationId)
        {
            return _organizationClientsService.GetAllAssignedClientsDataByOrganizationId(OrganizationId);
        }
        [Route("GetAllUnassignedClientsforAnotherOrganizationAndAssignedByThisOrganizationId/{OrganizationId}")]
        public IEnumerable<Client> GetAllUnassignedClientsforAnotherOrganizationAndAssignedByThisOrganizationId(int OrganizationId)
        {
            return _organizationClientsService.GetAllUnassignedClientsforAnotherOrganizationAndAssignedByThisOrganizationId(OrganizationId);
        }

        [HttpPost]
        public void Post(OrganizationClientsDTO organizationClientsDTO)
        {
            _organizationClientsService.Add(organizationClientsDTO);
        }
        // GET api/<OrganizationClientsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<OrganizationClientsController>


        // PUT api/<OrganizationClientsController>/5
        [HttpPut("{OrganizationId}")]
        public async Task<IEnumerable<OrganizationClients>> Put(int OrganizationId, List<Client> clients)
        {
            return await _organizationClientsService.UpdateByOrganizationId(OrganizationId, clients);
        }

        // DELETE api/<OrganizationClientsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
