using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data.DTO;
using Tracker.Data.Models;

namespace Tracker.Domain.IServices
{
    public interface ITeamService
    {
        IEnumerable<Team> GetAll();
        Team GetTeamById(int id);
        int AddTeam(TeamDTO team);
        void UpdateTeam(int Id, Team team);
    }
}
