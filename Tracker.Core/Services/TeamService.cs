using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data.DTO;
using Tracker.Data.Models;
using Tracker.Domain;
using Tracker.Domain.IServices;

namespace Tracker.Core.Services
{
    public class TeamService : ITeamService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TeamService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public int AddTeam(TeamDTO team)
        {
            _unitOfWork.Team.Add(team);
            return team.ID;
        }

        public IEnumerable<Team> GetAll()
        {
            return _unitOfWork.Team.GetAll();
        }

        public Team GetTeamById(int id)
        {
            return _unitOfWork.Team.GetById(id);
        }

        public void UpdateTeam(int Id, Team team)
        {
            _unitOfWork.Team.Update(Id, team);
        }
    }
}
