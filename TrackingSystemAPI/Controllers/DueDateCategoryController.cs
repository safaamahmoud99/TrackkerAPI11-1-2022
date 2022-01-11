using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracker.Data.Models;
using Tracker.Domain.IServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Tracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DueDateCategoryController : ControllerBase
    {
        private IDueDateCategoryService _dueDateCategoryService;

        public DueDateCategoryController(IDueDateCategoryService dueDateCategoryService)
        {
            _dueDateCategoryService = dueDateCategoryService;
        }
        // GET: api/<DueDateCategoryController>
        [HttpGet]
        public IEnumerable<DueDateCategory> Get()
        {
            return _dueDateCategoryService.GetAllDueDateCategories();
        }

        // GET api/<DueDateCategoryController>/5
        [HttpGet("{id}")]
        public ActionResult<DueDateCategory> Get(int id)
        {
            return _dueDateCategoryService.GetDueDateCategoryById(id);
        }

        // POST api/<DueDateCategoryController>
        [HttpPost]
        public void Post( DueDateCategory dueDateCategory)
        {
            _dueDateCategoryService.AddDueDateCategory(dueDateCategory);
        }

        // PUT api/<DueDateCategoryController>/5
        [HttpPut("{id}")]
        public void Put(int id, DueDateCategory dueDateCategory)
        {
            _dueDateCategoryService.UpdateDueDateCategory(id, dueDateCategory);
        }

        // DELETE api/<DueDateCategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _dueDateCategoryService.DeleteDueDateCategory(id);
        }
    }
}
