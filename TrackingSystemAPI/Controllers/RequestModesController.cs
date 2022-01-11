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
    public class RequestModesController : ControllerBase
    {
        private readonly IRequestModeService _requestModeService;
        public RequestModesController(IRequestModeService requestModeService)
        {
            _requestModeService = requestModeService;
        }

        // GET: api/RequestModes
        [HttpGet]
        public IEnumerable<RequestMode> GetrequestModes()
        {
            return _requestModeService.GetAllRequestMode();
        }

        // GET: api/RequestModes/5
        [HttpGet("{id}")]
        public ActionResult<RequestMode> GetRequestMode(int id)
        {
            var requestMode = _requestModeService.GetRequestModeById(id);
            return requestMode;
        }

        // PUT: api/RequestModes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutRequestMode(int id, RequestMode requestMode)
        {
            _requestModeService.UpdateRequestMode(id, requestMode);
            return CreatedAtAction("GetRequestMode", new { id = requestMode.Id }, requestMode);
        }

        // POST: api/RequestModes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult<RequestMode> PostRequestMode(RequestMode requestMode)
        {
            _requestModeService.AddRequestMode(requestMode);
            return CreatedAtAction("GetRequestMode", new { id = requestMode.Id }, requestMode);
        }

        // DELETE: api/RequestModes/5
        [HttpDelete("{id}")]
        public ActionResult<RequestMode> DeleteRequestMode(int id)
        {
            _requestModeService.DeleteRequestMode(id);
            return Ok();
        }
    }
}
