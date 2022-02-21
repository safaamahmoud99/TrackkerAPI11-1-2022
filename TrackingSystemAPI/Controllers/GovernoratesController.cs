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
    public class GovernoratesController : ControllerBase
    {
        private readonly IGovernorateService _GovernorateService;
        public GovernoratesController(IGovernorateService GovernorateService)
        {
            _GovernorateService = GovernorateService;
        }

        // GET: api/Governorates
        [HttpGet]
        public IEnumerable<GovernorateDto> GetGovernorates()
        {
            return _GovernorateService.GetAllGovernorates();
        }

        // GET: api/Governorates/5
        [HttpGet("{id}")]
        public  ActionResult<GovernorateDto> GetGovernorate(int id)
        {
            return _GovernorateService.GetGovernorate(id); 

        }

        // PUT: api/Governorates/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public void  PutGovernorate(int id, GovernorateDto governorate)
        {
            _GovernorateService.UpdateGovernorate(id, governorate);
           // return CreatedAtAction("GetgovernorateDto", new { id = governorate.Id }, governorate);
        }

        // POST: api/Governorates
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public  ActionResult<GovernorateDto>PostGovernorate(GovernorateDto governorate)
        {

            _GovernorateService.AddGovernorate(governorate);

            return CreatedAtAction("GetGovernorate", new { id = governorate.Id }, governorate);
        }

        // DELETE: api/Governorates/5
        [HttpDelete("{id}")]
        public ActionResult<Governorate> DeleteGovernorate(int id)
        {

            _GovernorateService.DeleteGovernorate(id);
            return Ok();
        }

       
    }
}
