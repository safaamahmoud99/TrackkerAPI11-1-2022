using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using  Tracker.Data.DTO;
using  Tracker.Data.Models;
using Tracker.Data.ViewModels;
using Tracker.Domain.IRepositories;
using Tracker.Domain.IServices;

namespace Tracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientsController(IClientService clientService)
        {
            _clientService = clientService;
        }

        // GET: api/Clients
        [HttpGet]
        public IEnumerable<ClientDTO> GetClientDTO()
        {
            return _clientService.GetAllClient();
        }

        // GET: api/Clients/5
        [HttpGet("{id}")]
        public ActionResult<ClientDTO> GetClientDTO(int id)
        {
            var clientDTO = _clientService.GetClientById(id);
            return clientDTO;
        }

        [HttpPost]
        [Route("api/dashboard/UploadImage")]
        public ActionResult UploadFile(IFormFile file)
        {
            var ImagesTypes = new List<string>() { "image/jpg", "image/jpeg", "image/png" };
            string path;
            if (ImagesTypes.Contains(file.ContentType))
            {
                path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/", file.FileName);
                using (Stream stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

            }
            else
            {
                return BadRequest();
            }
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpGet]
        [Route("getImage/{ImageName}")]
        public IActionResult ImageGet(string ImageName)
        {
            if (ImageName == null)
                return Content("filename not present");

            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot/images", ImageName);
            var memory = new MemoryStream();
            var ext = System.IO.Path.GetExtension(path);
            using (var stream = new FileStream(path, FileMode.Open))
            {
                stream.CopyTo(memory);
            }
            memory.Position = 0;
            var contentType = "APPLICATION/octet-stream";
            return File(memory, contentType, Path.GetFileName(path));
        }
        public IActionResult getFile(string FName)
        {
            if (FName == null)
                return Content("filename not present");

            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot/images/", FName);

            var memory = new MemoryStream();
            var ext = System.IO.Path.GetExtension(path);
            using (var stream = new FileStream(path, FileMode.Open))
            {
                stream.CopyTo(memory);
            }
            memory.Position = 0;
            var contentType = "APPLICATION/pdf";
            //return File(Path.GetFileName(path), contentType, FName);
            return File(memory, contentType, Path.GetFileName(path));
        }









        // PUT: api/Clients/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutClientDTO(int id, ClientDTO clientDTO)
        {
            try
            {
                _clientService.UpdateClient(id, clientDTO);
                return CreatedAtAction("GetClientDTO", new { id = clientDTO.Id }, clientDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "code", Message = ex.Message });
            }
        }
        // POST: api/Clients
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult<ClientDTO> PostClientDTO(ClientDTO clientDTO)
        {
            try
            {
                 _clientService.AddClient(clientDTO);
                 return CreatedAtAction("GetClientDTO", new { id = clientDTO.Id }, clientDTO);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "code", Message = ex.Message });
            }
        }

        // DELETE: api/Clients/5
        [HttpDelete("{id}")]
        public ActionResult<Client> DeleteClientDTO(int id)
        {
            _clientService.DeleteClient(id);
            return Ok();
        }
    }
}