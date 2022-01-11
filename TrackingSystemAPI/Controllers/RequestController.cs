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
using TrackingSystemAPI.DTO;

namespace Tracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly IRequestService _requestService;

        public RequestController(IRequestService requestService)
        {
            _requestService = requestService;
        }

        // GET: api/Request
        [HttpGet]
        public IEnumerable<RequestDTO> GetRequestDTO()
        {
            return _requestService.GetAllRequests();
        }
        [Route("GetAllRequestByClientId/{ClientId}")]
        public IEnumerable<RequestDTO> GetAllRequestByClientId(int ClientId)
        {
            return _requestService.GetAllRequestByClientId(ClientId);
        }
        [HttpGet]
        [Route("GetAllRequestByProjectSiteAssetId/{ProjectSiteAssetId}")]
        public IEnumerable<RequestDTO> GetAllRequestByProjectSiteAssetId(int ProjectSiteAssetId)
        {
            return _requestService.GetAllRequestByProjectSiteAssetId(ProjectSiteAssetId);
        }
        [HttpGet]
        [Route("GetAllRequestByProjectId/{ProjectId}")]
        public IEnumerable<RequestDTO> GetAllRequestByProjectId(int ProjectId)
        {
            return _requestService.GetAllRequestByProjectId(ProjectId);
        }
        [HttpPost]
        [Route("GetAllRequestByProjectTeamId")]
        public List<RequestDTO> GetAllRequestByProjectTeamId(ProjectTeamVM model)
        {
            return _requestService.GetAllRequestByProjectTeamId(model);
        }

        // GET: api/Request/5
        [HttpGet("{id}")]
        public ActionResult<RequestDTO> GetRequestDTO(int id)
        {
            var requestDTO = _requestService.GetRequestById(id);
            return requestDTO;
        }

        // PUT: api/Request/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutRequestDTO(int id, RequestDTO requestDTO)
        {
            _requestService.UpdateRequests(id,requestDTO);
            return CreatedAtAction("GetRequestDTO", new { id = requestDTO.Id }, requestDTO);
        }

        // POST: api/Request
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public int PostRequestDTO(RequestDTO requestDTO)
        {
            return _requestService.AddRequests(requestDTO);
            //return CreatedAtAction("GetRequestDTO", new { id = requestDTO.Id }, requestDTO);
        }

        // DELETE: api/Request/5
        [HttpDelete("{id}")]
        public ActionResult<RequestDTO> DeleteRequestDTO(int id)
        {
            _requestService.DeleteRequests(id);
            return Ok();
        }
        [HttpGet]
        [Route("GetAllRequestByRequestStatus/{requestStatusId}")]
        public List<RequestDTO> GetAllRequestByRequestStatus(int requestStatusId)
        {
            return _requestService.GetAllRequestByRequestStatus(requestStatusId);
        }
        [HttpGet]
        [Route("GetAllRequestByRequestStatusAndProjectTeamId/{requestStatusId}/{ProjectTeamId}")]
        public ActionResult<RequestDTO> GetAllRequestByRequestStatusAndProjectTeamId(int requestStatusId, int ProjectTeamId)
        {
            return _requestService.GetAllRequestByRequestStatusAndProjectTeamId(requestStatusId, ProjectTeamId);
        }

        [Route("CountProjects/{ProjectId}")]
        public int CountProjects(int ProjectId)
        {
            return _requestService.CountProjects(ProjectId);
        }

        [Route("CountInProgressProjects/{ProjectId}")]
        public int CountInProgressProjects(int ProjectId)
        {
            return _requestService.CountInProgressProjects(ProjectId);
        }

        [Route("CountOpenProjects/{ProjectId}")]
        public int CountOpenProjects(int ProjectId)
        {
            return _requestService.CountOpenProjects(ProjectId);
        }

        [Route("CountClosedProjects/{ProjectId}")]
        public int CountClosedProjects(int ProjectId)
        {
            return _requestService.CountClosedProjects(ProjectId);
        }
    }
}
