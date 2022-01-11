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
    public class RequestStatusController : ControllerBase
    {
        private readonly IRequestStatusService _requestStatusService;

        public RequestStatusController(IRequestStatusService requestStatusService)
        {
            _requestStatusService = requestStatusService;
        }

        // GET: api/RequestStatus
        [HttpGet]
        public IEnumerable<RequestStatus> GetrequestStatuses()
        {
            return _requestStatusService.GetAllRequestStatus();
        }

        // GET: api/RequestStatus/5
        [HttpGet("{id}")]
        public ActionResult<RequestStatus> GetRequestStatus(int id)
        {
            var requestStatus = _requestStatusService.GetRequestStatusById(id);
            return requestStatus;
        }

        // PUT: api/RequestStatus/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutRequestStatus(int id, RequestStatus requestStatus)
        {
            _requestStatusService.UpdateRequestStatus(id,requestStatus);
            return CreatedAtAction("GetRequestStatus", new { id = requestStatus.Id }, requestStatus);
        }

        // POST: api/RequestStatus
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult<RequestStatus> PostRequestStatus(RequestStatus requestStatus)
        {
            _requestStatusService.AddRequestStatus(requestStatus);
            return CreatedAtAction("GetRequestStatus", new { id = requestStatus.Id }, requestStatus);
        }

        // DELETE: api/RequestStatus/5
        [HttpDelete("{id}")]
        public ActionResult<RequestStatus> DeleteRequestStatus(int id)
        {
            _requestStatusService.DeleteRequestStatus(id);
            return Ok();
        }
    }
}
