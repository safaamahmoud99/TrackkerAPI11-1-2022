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
    public class SitesController : ControllerBase
    {
        private readonly ISitesService _sitesService;

        public SitesController(ISitesService sitesService)
        {
            _sitesService = sitesService;
        }
        // GET: api/<SitesController>
        [HttpGet]
        public IEnumerable<siteDto> Get()
        {
            return _sitesService.GetAllSites();
        }

        // GET api/<SitesController>/5
        [HttpGet("{id}")]
        public ActionResult<siteDto> Get(int id)
        {
            return _sitesService.GetSite(id);
        }

        // POST api/<SitesController>
        [HttpPost]
        public ActionResult<siteDto> Post(siteDto Sites)
        {
            _sitesService.AddSite(Sites);
            return CreatedAtAction("Get", new { id = Sites.Id }, Sites);

        }

        // PUT api/<SitesController>/5
        [HttpPut("{id}")]
        public void Put(int id, siteDto Sites)
        {
            _sitesService.UpdateSite(id, Sites);
          //  return CreatedAtAction("Get", new { id = Sites.Id }, Sites);

        }

        // DELETE api/<SitesController>/5
        [HttpDelete("{id}")]
        public ActionResult<Sites> Delete(int id)
        {
            _sitesService.DeleteSite(id);
            return Ok();
        }
    }
}
