using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tracker.Data.Models;
using Tracker.Domain.IRepositories;
using Tracker.Domain.IServices;

namespace Tracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestPerioritiesController : ControllerBase
    {
        private readonly IRequestPeriorityService _requestPeriorityService;

        public RequestPerioritiesController(IRequestPeriorityService requestPeriorityService)
        {
            _requestPeriorityService = requestPeriorityService;
        }

        // GET: api/RequestPeriorities
        [HttpGet]
        public IEnumerable<RequestPeriority> GetrequestPeriorities()
        {
            return _requestPeriorityService.GetAllRequestPeriority();
        }

        // GET: api/RequestPeriorities/5
        [HttpGet("{id}")]
        public ActionResult<RequestPeriority> GetRequestPeriority(int id)
        {
            var requestPeriority = _requestPeriorityService.GetRequestPeriorityById(id);
            return requestPeriority;
        }

        // PUT: api/RequestPeriorities/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutRequestPeriority(int id, RequestPeriority requestPeriority)
        {
            _requestPeriorityService.UpdateRequestPeriority(id, requestPeriority);
            return CreatedAtAction("GetRequestPeriority", new { id = requestPeriority.Id }, requestPeriority);
        }

        // POST: api/RequestPeriorities
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult<RequestPeriority> PostRequestPeriority(RequestPeriority requestPeriority)
        {
            _requestPeriorityService.AddRequestPeriority(requestPeriority);
            return CreatedAtAction("GetRequestPeriority", new { id = requestPeriority.Id }, requestPeriority);
        }

        // DELETE: api/RequestPeriorities/5
        [HttpDelete("{id}")]
        public ActionResult<RequestPeriority> DeleteRequestPeriority(int id)
        {
            _requestPeriorityService.DeleteRequestPeriority(id);
            return Ok();
        }
    }
}
