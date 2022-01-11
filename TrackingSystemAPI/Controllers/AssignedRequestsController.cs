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
    public class AssignedRequestsController : ControllerBase
    {
        private readonly IAssignedRequestService _assignedRequestService;

        public AssignedRequestsController(IAssignedRequestService assignedRequestService, IRequestDescriptionRepository requestDescriptionRepository)
        {
            _assignedRequestService = assignedRequestService;
        }

        // GET: api/AssignedRequests
        [HttpGet]
        public IEnumerable<AssignedRequestsDTO> GetAssignedRequestsDTO()
        {
            return _assignedRequestService.GetAllAssignedRequests();
        }

        // GET: api/AssignedRequests/5
        [HttpGet("{id}")]
        public ActionResult<AssignedRequestsDTO> GetAssignedRequestsDTO(int id)
        {
            var assignedRequestsDTO = _assignedRequestService.GetAssignedRequestById(id);
            return assignedRequestsDTO;
        }
        [HttpGet]
        [Route("GetAllRequestByEmployeeId/{EmployeeId}")]
        public IEnumerable<RequestDTO> GetAllRequestByEmployeeId(int EmployeeId)
        {
            var assignedRequestsDTO = _assignedRequestService.GetAllRequestByEmployeeId(EmployeeId);
            return assignedRequestsDTO;
        }
        [HttpGet]
        [Route("GetAllRequestByEmployeeIdAndTeamId/{EmployeeId}/{TeamId}")]
        public IEnumerable<RequestDTO> GetAllRequestByEmployeeIdAndTeamId(int EmployeeId, int TeamId)
        {
            var assignedRequestsDTO = _assignedRequestService.GetAllRequestByEmployeeIdAndTeamId(EmployeeId, TeamId);
            return assignedRequestsDTO;
        }

        // PUT: api/AssignedRequests/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutAssignedRequestsDTO(int id, AssignedRequestsDTO assignedRequestsDTO)
        {
            _assignedRequestService.AddAssignedRequest(assignedRequestsDTO);
            return CreatedAtAction("GetAssignedRequestsDTO", new { id = assignedRequestsDTO.Id }, assignedRequestsDTO);
        }

        // POST: api/AssignedRequests
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public IActionResult PostAssignedRequestsDTO(AssignedRequestsDTO assignedRequestsDTO)
        {
           _assignedRequestService.AddAssignedRequest(assignedRequestsDTO);
            return CreatedAtAction("GetAssignedRequestsDTO", new { id = assignedRequestsDTO.Id }, assignedRequestsDTO);
        }

        // DELETE: api/AssignedRequests/5
        [HttpDelete("{id}")]
        public ActionResult<AssignedRequests> DeleteAssignedRequestsDTO(int id)
        {
            _assignedRequestService.DeleteAssignedRequest(id);
            return Ok();
        }
    }
}
