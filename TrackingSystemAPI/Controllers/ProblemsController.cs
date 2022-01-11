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
    public class ProblemsController : ControllerBase
    {
        private readonly IProblemsService _problemsService;

        public ProblemsController(IProblemsService problemsService)
        {
            _problemsService = problemsService;
        }

        // GET: api/Problems
        [HttpGet]
        public IEnumerable<Problems> GetrequestTypes()
        {
            return _problemsService.GetAllProblems();
        }

        // GET: api/Problems/5
        [HttpGet("{id}")]
        public ActionResult<Problems> GetProblems(int id)
        {
            return _problemsService.GetProblemById(id); 
        }

        // PUT: api/Problems/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutProblems(int id, Problems problems)
        {
            _problemsService.UpdateProblem(id, problems);
            return CreatedAtAction("GetProblems", new { id = problems.Id }, problems);
        }

        // POST: api/Problems
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult<Problems> PostProblems(Problems problems)
        {
            _problemsService.AddProblem(problems);
            return CreatedAtAction("GetProblems", new { id = problems.Id }, problems);
        }

        // DELETE: api/Problems/5
        [HttpDelete("{id}")]
        public ActionResult<Problems> DeleteProblems(int id)
        {
            _problemsService.DeleteProblem(id);
            return Ok();
        }
    }
}
