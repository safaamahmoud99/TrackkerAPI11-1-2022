using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
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
    public class RequestImagesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        private readonly IRequestImageService _requestImageService;

        public RequestImagesController(IRequestImageService requestImageService)
        {
            _requestImageService = requestImageService;
        }
        

        // GET: api/RequestImages
        [HttpGet]
        public IEnumerable<requestImages> GetRequestImageDTO()
        {
            return _requestImageService.GetAllRequestImage();

        }

        // GET: api/RequestImages/5
        [HttpGet("{id}")]
        public ActionResult<requestImages> GetRequestImageDTO(int id)
        {
            var requestimage = _requestImageService.GetRequestImageById(id);
            return requestimage;
        }

        // PUT: api/RequestImages/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutRequestImageDTO(int id, requestImages requestImages)
        {
            _context.Entry(requestImages).State = EntityState.Modified;
            return NoContent();
        }

        // POST: api/RequestImages
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public void PostRequestImageDTO(List<RequestImageDTO> requestImageDTOs)
        {
            _requestImageService.AddRequestImage(requestImageDTOs);
        }

        // DELETE: api/RequestImages/5
        [HttpDelete("{id}")]
        public ActionResult<requestImages> DeleteRequestImageDTO(int id)
        {

            return Ok();
        }

        [HttpGet]
        [Route("GetRequestImageByRequestId/{requestID}")]
        public IEnumerable<RequestImageDTO> GetRequestImageByRequestId(int requestID)
        {
            return _requestImageService.GetRequestImageByRequestId(requestID);
        }

    }

  
}
