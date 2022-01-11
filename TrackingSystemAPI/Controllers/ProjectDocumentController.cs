using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
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
    public class ProjectDocumentController : ControllerBase
    {
        private readonly IProjectDocumentService _projectDocumentService;

        public ProjectDocumentController(IProjectDocumentService projectDocumentService)
        {
            _projectDocumentService = projectDocumentService;
        }

        // GET: api/ProjectDocument
        [HttpGet]
        public  IEnumerable<ProjectDocumentDTO> GetProjectDocumentDTO()
        {
            return _projectDocumentService.GetAllProjectDocuments();
        }

        // GET: api/ProjectDocument/5
        [HttpGet("{id}")]
        public ActionResult<ProjectDocumentDTO> GetProjectDocumentDTO(int id)
        {
            var projectDocumentDTO = _projectDocumentService.GetProjectDocumentById(id);
            return projectDocumentDTO;
        }
        [HttpGet]
        [Route("GetProjectDocumentsByProjectId/{ProjectId}")]
        public IEnumerable<ProjectDocumentDTO> GetProjectDocumentsByProjectId(int ProjectId)
        {
            return _projectDocumentService.GetProjectDocumentsByProjectId(ProjectId);
        }
        // PUT: api/ProjectDocument/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutProjectDocumentDTO(int id, ProjectDocumentDTO projectDocumentDTO)
        {
            _projectDocumentService.UpdateProjectDocument(id, projectDocumentDTO);
            return NoContent();
        }

        //update by id
        [HttpPut("{id}")]
        [Route("PutDocumentsDTOByProjectId/{id}")]
        public IActionResult PutDocumentsDTOByProjectId(int id, List<ProjectDocumentDTO>projectDocumentDTOs )
        {
            _projectDocumentService.UpdateByProjectId(id, projectDocumentDTOs);
            return Ok();
        }
        [HttpPost, DisableRequestSizeLimit]
        [Route("uploadfile")]
        public IActionResult Upload()
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("wwwroot", "documentFiles");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    return Ok(new { dbPath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode( 500,$"the error is {ex.Message}");
            }
        }

        // POST: api/ProjectDocument
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [Route("SaveDocument")]
        public void PostProjectDocumentDTO(List<ProjectDocumentDTO> projectDocumentDTO)
        {
            _projectDocumentService.AddProjectDocuments(projectDocumentDTO);
            //return CreatedAtAction("GetProjectDocumentDTO", new { id = projectDocumentDTO.Count() }, projectDocumentDTO);
        }

        // DELETE: api/ProjectDocument/5
        [HttpDelete("{id}")]
        public  ActionResult<ProjectDocument> DeleteProjectDocumentDTO(int id)
        {
            _projectDocumentService.DeleteProjectDocument(id);
            return Ok();
        }
    }
}
