using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tracker.Data.DTO;
using Tracker.Data.Models;
using Tracker.Domain.IServices;

namespace Tracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly ICityService _cityService;
        public CitiesController(ICityService cityService )
        {
            _cityService=cityService;
        }

        // GET: api/Cities
        [HttpGet]
        public IEnumerable<cityDto> GetCities()
        {
            return _cityService.GetAllCities(); 
        }

        // GET: api/Cities/5
        [HttpGet("{id}")]
        public ActionResult<cityDto> GetCity(int id)
        {
            return _cityService.GetCity(id);
        }

        // PUT: api/Cities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public void  PutCity(int id, cityDto city)
        {
            _cityService.UpdateCity(id, city);
          //  return CreatedAtAction("Get", new { id = city.Id }, city);
        }

        // POST: api/Cities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public  ActionResult<cityDto> PostCity(cityDto city)
        {
            _cityService.AddCity(city);
            return CreatedAtAction("GetCity", new { id = city.Id }, city);
        }

        // DELETE: api/Cities/5
        [HttpDelete("{id}")]
        public ActionResult<cityDto> DeleteCity(int id)
        {
             _cityService.DeleteCity(id);
              return Ok();
        }

        [HttpGet("Getgovbycity/{id}")]
        public IEnumerable<cityDto> Getgovbycity(int id)
        {
            return _cityService.GetCitybegov(id);
        }
    }
}
