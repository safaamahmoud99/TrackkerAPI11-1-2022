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
    public class RequestSubCategoryController : ControllerBase
    {
        private readonly IRequestSubCategoryService _requestSubCategoryService;

        public RequestSubCategoryController(IRequestSubCategoryService requestSubCategoryService)
        {
            _requestSubCategoryService = requestSubCategoryService;
        }

        // GET: api/RequestSubCategory
        [HttpGet]
        public IEnumerable<RequestSubCategoryDTO> GetRequestSubCategoryDTO()
        {
            return _requestSubCategoryService.GetAllRequestSubCategory();
    }

        // GET: api/RequestSubCategory/5
        [HttpGet("{id}")]
        public ActionResult<RequestSubCategoryDTO> GetRequestSubCategoryDTO(int id)
        {
            var requestSubCategoryDTO = _requestSubCategoryService.GetRequestSubCategoryById(id);
            return requestSubCategoryDTO;
        }

        // PUT: api/RequestSubCategory/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutRequestSubCategoryDTO(int id, RequestSubCategoryDTO requestSubCategoryDTO)
        {
            _requestSubCategoryService.UpdateRequestSubCategory(id,requestSubCategoryDTO);
            return CreatedAtAction("GetRequestSubCategoryDTO", new { id = requestSubCategoryDTO.Id }, requestSubCategoryDTO);
        }

        // POST: api/RequestSubCategory
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult<RequestSubCategoryDTO> PostRequestSubCategoryDTO(RequestSubCategoryDTO requestSubCategoryDTO)
        {
            _requestSubCategoryService.AddRequestSubCategory(requestSubCategoryDTO);
            return CreatedAtAction("GetRequestSubCategoryDTO", new { id = requestSubCategoryDTO.Id }, requestSubCategoryDTO);
        }

        // DELETE: api/RequestSubCategory/5
        [HttpDelete("{id}")]
        public ActionResult<RequestSubCategory> DeleteRequestSubCategoryDTO(int id)
        {
            _requestSubCategoryService.DeleteRequestSubCategory(id);
            return Ok();
        }
    }
}
