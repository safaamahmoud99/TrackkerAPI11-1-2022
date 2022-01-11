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
    public class RequestCategoryController : ControllerBase
    {
        private readonly IRequestCategoryService _requestCategoryService;

        public RequestCategoryController(IRequestCategoryService requestCategoryService)
        {
            _requestCategoryService = requestCategoryService;
        }

        // GET: api/RequestCategory
        [HttpGet]
        public IEnumerable<RequestCategoryDTO> GetRequestCategoryDTO()
        {
            return _requestCategoryService.GetAllRequestCategory();
        }

        // GET: api/RequestCategory/5
        [HttpGet("{id}")]
        public ActionResult<RequestCategoryDTO> GetRequestCategoryDTO(int id)
        {
            var requestCategoryDTO = _requestCategoryService.GetRequestCategoryById(id);
            return requestCategoryDTO;
        }

        // PUT: api/RequestCategory/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutRequestCategoryDTO(int id, RequestCategoryDTO requestCategoryDTO)
        {

            _requestCategoryService.UpdateRequestCategory(id, requestCategoryDTO);
            return CreatedAtAction("GetRequestCategoryDTO", new { id = requestCategoryDTO.Id }, requestCategoryDTO);
        }

        // POST: api/RequestCategory
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult<RequestCategoryDTO> PostRequestCategoryDTO(RequestCategoryDTO requestCategoryDTO)
        {
            _requestCategoryService.AddRequestCategory(requestCategoryDTO);
            return CreatedAtAction("GetRequestCategoryDTO", new { id = requestCategoryDTO.Id }, requestCategoryDTO);
        }

        // DELETE: api/RequestCategory/5
        [HttpDelete("{id}")]
        public ActionResult<RequestCategory> DeleteRequestCategoryDTO(int id)
        {
            _requestCategoryService.DeleteRequestCategory(id);
            return Ok();
        }
    }
}
