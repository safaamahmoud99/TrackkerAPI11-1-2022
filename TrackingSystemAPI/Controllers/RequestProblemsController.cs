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
    public class RequestProblemsController : ControllerBase
    {
        private readonly IRequestProblemService _requestProblemService;

        public RequestProblemsController(IRequestProblemService requestProblemService)
        {
            _requestProblemService = requestProblemService;
        }

        // GET: api/RequestProblems
        [HttpGet]
        public IEnumerable<RequestProblemsDTO> GetRequestProblemsDTO()
        {
            return _requestProblemService.GetAllRequestProblem();
        }

        // GET: api/RequestProblems/5
        [HttpGet("{id}")]
        public ActionResult<RequestProblemsDTO> GetRequestProblemsDTO(int id)
        {
            var requestProblemsDTO = _requestProblemService.GetRequestProblemById(id);
            return requestProblemsDTO;
        }
        [HttpGet]
        [Route("GetProblemByEmployeeIdAndRequestId/{EmployeeId}/{RequestId}")]
        public RequestProblemsDTO GetProblemByEmployeeIdAndRequestId(int EmployeeId, int RequestId)
        {
            return _requestProblemService.GetProblemByEmployeeIdAndRequestId(EmployeeId, RequestId);
        }

        [HttpGet]
        [Route("GetAllRequestByProblemId/{ProblemId}")]
        public IEnumerable<RequestProblemsDTO> GetAllRequestByProblemId(int ProblemId)
        {
            return _requestProblemService.GetAllRequestByProblemId(ProblemId);
        }
        // PUT: api/RequestProblems/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutRequestProblemsDTO(int id, RequestProblems requestProblems)
        {
            _requestProblemService.UpdateRequestProblem(id, requestProblems);
            return CreatedAtAction("GetRequestProblemsDTO", new { id = requestProblems.Id }, requestProblems);
        }

        // POST: api/RequestProblems
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult<RequestProblemsDTO> PostRequestProblemsDTO(RequestProblems requestProblems)
        {
            _requestProblemService.AddRequestProblem(requestProblems);
            return CreatedAtAction("GetRequestProblemsDTO", new { id = requestProblems.Id }, requestProblems);
        }

        // DELETE: api/RequestProblems/5
        [HttpDelete("{id}")]
        public ActionResult<RequestProblems> DeleteRequestProblemsDTO(int id)
        {
            _requestProblemService.DeleteRequestProblem(id);
            return Ok();
        }
    }
}
