using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracker.Data.Models;
using Tracker.Domain.IServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Tracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OriginsController : ControllerBase
    {
        private readonly IOriginsService _originsService;

        public OriginsController(IOriginsService originsService)
        {
            _originsService = originsService;
        }
        // GET: api/<OriginsController>
        [HttpGet]
        public IEnumerable<Origin> Get()
        {
            return _originsService.GetAllOrigins();
        }

        // GET api/<OriginsController>/5
        [HttpGet("{id}")]
        public ActionResult<Origin> Get(int id)
        {
            return _originsService.GetOriginsById(id);
        }

        // POST api/<OriginsController>
        [HttpPost]
        public ActionResult<Origin> Post(Origin origin)
        {
            _originsService.AddOrigin(origin);
            return CreatedAtAction("get", new { Id = origin.Id }, origin);
        }

        // PUT api/<OriginsController>/5
        [HttpPut("{id}")]
        public ActionResult<Origin> Put(int id, Origin origin)
        {
            _originsService.UpdateOrigin(id,origin);
            return CreatedAtAction("get", new { Id = origin.Id }, origin);
        }

        // DELETE api/<OriginsController>/5
        [HttpDelete("{id}")]
        public ActionResult<Origin> Delete(int id)
        {
            _originsService.DeleteOrigin(id);
            return Ok();
        }
    }
}
