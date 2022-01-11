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
    public class OrganizationsController : ControllerBase
    {
        private readonly IOrganizationService _organizationService;

        public OrganizationsController(IOrganizationService organizationService)
        {
            _organizationService = organizationService;
        }

        // GET: api/Organizations
        [HttpGet]
        public IEnumerable<Organization> Getorganizations()
        {
            return  _organizationService.GetAllOrganizations();
        }

        // GET: api/Organizations/5
        [HttpGet("{id}")]
        public ActionResult<Organization> GetOrganization(int id)
        {
            var organization =_organizationService.GetOrganizationById(id);
            return organization;
        }

        // PUT: api/Organizations/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutOrganization(int id, Organization organization)
        {
            _organizationService.UpdateOrganization(id, organization);
            return CreatedAtAction("GetOrganization", new { id = organization.Id }, organization);
        }

        // POST: api/Organizations
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public  int PostOrganization(Organization organization)
        {
            _organizationService.AddOrganization(organization);
            return organization.Id;
            //return CreatedAtAction("GetOrganization", new { id = organization.Id }, organization);
        }

        // DELETE: api/Organizations/5
        [HttpPut]
        [Route("SoftDelete/{id}")]
        public ActionResult<Organization> DeleteOrganization(int id, Organization organization)
        {

            _organizationService.DeleteOrganization(organization);
            return Ok();
        }
    }
}
