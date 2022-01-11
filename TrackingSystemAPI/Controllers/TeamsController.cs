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
    public class TeamsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        private readonly ITeamService _teamService;

        public TeamsController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        // GET: api/Teams
        [HttpGet]
        public IEnumerable<Team> Getteams()
        {
            return  _teamService.GetAll();
        }

        // GET: api/Teams/5
        [HttpGet("{id}")]
        public ActionResult<Team> GetTeam(int id)
        {
            var team =_teamService.GetTeamById(id);
            return team;
        }

        // PUT: api/Teams/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutTeam(int id, Team team)
        {
            _teamService.UpdateTeam(id,team);
            return Ok();
        }

        // POST: api/Teams
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public int PostTeam(TeamDTO team)
        {
          return  _teamService.AddTeam(team);
        }

        // DELETE: api/Teams/5
        [HttpDelete("{id}")]
        public ActionResult<Team> DeleteTeam(int id)
        {
            return Ok();
        }  
    }
}
