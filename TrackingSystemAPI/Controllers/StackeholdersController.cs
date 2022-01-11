using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using  Tracker.Data.DTO;
using  Tracker.Data.Models;
using Tracker.Domain.IRepositories;
using Tracker.Domain.IServices;

namespace Tracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StackeholdersController : ControllerBase
    {
        private readonly IStackeholdersService _stackeholdersService;
        public StackeholdersController(IStackeholdersService stackeholdersService)
        {
            _stackeholdersService = stackeholdersService;
        }

        // GET: api/Stackeholders
        [HttpGet]
        public IEnumerable<StackeholdersDTO> GetStackeholdersDTO()
        {
            return _stackeholdersService.GetAllStackeholders();
        }
        [HttpGet]
        [Route("GetStackeholdersByProjectId/{ProjectId}")]
        public IEnumerable<StackeholdersDTO> GetStackeholdersByProjectId(int ProjectId)
        {
            return _stackeholdersService.GetStackeholdersByProjectId(ProjectId);
        }
        // GET: api/Stackeholders/50
        [HttpGet("{id}")]
        public ActionResult<StackeholdersDTO> GetStackeholdersDTO(int id)
        {
            var stackeholdersDTO = _stackeholdersService.GetStackeholdersById(id);
            return stackeholdersDTO;
        }

        // PUT: api/Stackeholders/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutStackeholdersDTO(int id, StackeholdersDTO stackeholdersDTO)
        {
            _stackeholdersService.UpdateStackeholders(id,stackeholdersDTO);
            return NoContent();
        }
        //update by id
        [HttpPut("{id}")]
        [Route("updatestakehodersByProjectId/{id}")]
        public IActionResult PutStackeholdersDTOByProjectId(int id, List<StackeholdersDTO> stackeholdersDTO)
        {
            _stackeholdersService.UpdateByProjectId(id,stackeholdersDTO);
            return Ok();
        }

        // POST: api/Stackeholders
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult<StackeholdersDTO> PostStackeholdersDTO(List<StackeholdersDTO> stackeholdersDTO)
        {
            _stackeholdersService.AddStackeholders(stackeholdersDTO);
            return CreatedAtAction("GetStackeholdersDTO", new { id = stackeholdersDTO.Count() }, stackeholdersDTO);
        }

        // DELETE: api/Stackeholders/5
        [HttpDelete("{id}")]
        public ActionResult<Stackeholders> DeleteStackeholdersDTO(int id)
        {
            _stackeholdersService.DeleteStackeholders(id);
            return Ok();
        }
    }
}
