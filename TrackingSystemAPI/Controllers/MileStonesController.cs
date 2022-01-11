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
    public class MileStonesController : ControllerBase
    {
        private readonly IMileStoneService _mileStoneService;

        public MileStonesController(IMileStoneService mileStoneService)
        {
            _mileStoneService = mileStoneService;
        }

        // GET: api/MileStones
        [HttpGet]
        public IEnumerable<MileStoneDTO> GetMileStoneDTO()
        {
            return _mileStoneService.GetAllMileStones();
        }

        // GET: api/MileStones/5
        [HttpGet("{id}")]
        public ActionResult <MileStoneDTO> GetMileStoneDTO(int id)
        {
            var mileStoneDTO = _mileStoneService.GetMileStoneById(id);
            return mileStoneDTO;
        }
        [HttpGet]
        [Route("GetMileStonesByProjectId/{ProjectId}")]
        public IEnumerable<MileStoneDTO> GetMileStonesByProjectId(int ProjectId)
        {
            return _mileStoneService.GetMileStonesByProjectId(ProjectId);
        }
        // PUT: api/MileStones/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public  IActionResult PutMileStoneDTO(int id, MileStoneDTO mileStoneDTO)
        {

            _mileStoneService.UpdateMileStone(id, mileStoneDTO);
            return CreatedAtAction("GetMileStoneDTO", new { id = mileStoneDTO.Id }, mileStoneDTO);
        }

        //update by id
        [HttpPut("{id}")]
        [Route("PutmilestonesDTOByProjectId/{id}")]
        public IActionResult PutmilestonesDTOByProjectId(int id, List<MileStoneDTO> mileStoneDTOs)
        {
            _mileStoneService.UpdateByProjectId(id, mileStoneDTOs);
            return CreatedAtAction("GetMileStoneDTO", new { id = mileStoneDTOs.Count() }, mileStoneDTOs);

        }

        // POST: api/MileStones
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
       
        public ActionResult<MileStoneDTO> PostMileStoneDTO(List<MileStoneDTO> mileStoneDTO)
        {
            _mileStoneService.AddMileStone(mileStoneDTO);
            return CreatedAtAction("GetMileStoneDTO", new { id = mileStoneDTO.Count() }, mileStoneDTO);
        }
        // DELETE: api/MileStones/5
        [HttpDelete("{id}")]
        public ActionResult<MileStoneDTO> DeleteMileStoneDTO(int id)
        {
            _mileStoneService.DeleteMileStone(id);
            return Ok();
        }

        
    }
}
