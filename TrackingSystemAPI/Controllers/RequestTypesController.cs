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
    public class RequestTypesController : ControllerBase
    {
        private readonly IRequestTypeService _requestTypeService;

        public RequestTypesController(IRequestTypeService requestTypeService)
        {
            _requestTypeService = requestTypeService;
        }
        // GET: api/RequestTypes
        [HttpGet]
        public IEnumerable<Problems> GetrequestTypes()
        {
            return _requestTypeService.GetAllRequestType();
        }

        // GET: api/RequestTypes/5
        [HttpGet("{id}")]
        public ActionResult<Problems> GetRequestType(int id)
        {
            var requestType = _requestTypeService.GetRequestTypeById(id);
            return requestType;
        }

        // PUT: api/RequestTypes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutRequestType(int id, Problems requestType)
        {
            _requestTypeService.UpdateRequestType(id,requestType);
            return CreatedAtAction("GetRequestType", new { id = requestType.Id }, requestType);
        }

        // POST: api/RequestTypes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult<Problems> PostRequestType(Problems requestType)
        {
            _requestTypeService.AddRequestType(requestType);
            return CreatedAtAction("GetRequestType", new { id = requestType.Id }, requestType);
        }

        // DELETE: api/RequestTypes/5
        [HttpDelete("{id}")]
        public ActionResult<Problems> DeleteRequestType(int id)
        {
            _requestTypeService.DeleteRequestType(id);
            return Ok();
        }
    }
}
