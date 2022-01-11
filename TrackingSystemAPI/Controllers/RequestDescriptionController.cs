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
    public class RequestDescriptionController : ControllerBase
    {
        private readonly IRequestDescriptionService _requestDescriptionService;

        public RequestDescriptionController(IRequestDescriptionService requestDescriptionService)
        {
            _requestDescriptionService = requestDescriptionService;
        }

        // GET: api/RequestDescription
        [HttpGet]
        public IEnumerable<RequestDescriptionDTO> GetRequestDescriptionDTO()
        {
            return _requestDescriptionService.GetAllRequestDescription();
        }

        // GET: api/RequestDescription/5
        [HttpGet("{id}")]
        public ActionResult<RequestDescriptionDTO> GetRequestDescriptionDTO(int id)
        {
            var requestDescriptionDTO = _requestDescriptionService.GetRequestDescriptionById(id);
            return requestDescriptionDTO;
        }
        [HttpGet]
        [Route("GetAllDescriptionsByRequestId/{RequestId}")]
        public IEnumerable<RequestDescriptionDTO> GetAllDescriptionsByRequestId(int RequestId)
        {
            return _requestDescriptionService.GetAllDescriptionsByRequestId(RequestId);
        }
        // PUT: api/RequestDescription/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutRequestDescriptionDTO(int id, RequestDescriptionDTO requestDescriptionDTO)
        {
            _requestDescriptionService.UpdateRequestDescription(id, requestDescriptionDTO);
            return CreatedAtAction("GetRequestDescriptionDTO", new { id = requestDescriptionDTO.Id }, requestDescriptionDTO);
        }

        // POST: api/RequestDescription
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public IActionResult PostRequestDescriptionDTO(RequestDescriptionDTO requestDescriptionDTO)
        {
            _requestDescriptionService.AddRequestDescription(requestDescriptionDTO);
            return CreatedAtAction("GetRequestDescriptionDTO", new { id = requestDescriptionDTO.Id }, requestDescriptionDTO);
        }

        // DELETE: api/RequestDescription/5
        [HttpDelete("{id}")]
        public ActionResult<RequestDescription> DeleteRequestDescriptionDTO(int id)
        {
            _requestDescriptionService.DeleteRequestDescription(id);
            return Ok();
        }
    }
}
