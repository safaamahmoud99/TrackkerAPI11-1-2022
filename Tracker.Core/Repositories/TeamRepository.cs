using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracker.Data.DTO;
using Tracker.Data.Models;
using Tracker.Domain.IRepositories;

namespace Tracker.Core.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly ApplicationDbContext _context;
        public TeamRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public int Add(TeamDTO team)
        {
            int Id;
            try
            {
                if (team != null)
                {
                    Team teamObj = new Team();
                    teamObj.Name = team.Name;
                    _context.Teams.Add(teamObj);
                    _context.SaveChanges();
                    Id= teamObj.Id;
                }
                else
                {
                    throw new NotCompletedException("Not Completed Exception");
                }
            }
            catch (Exception)
            {
                throw new NotExistException("Not Exist Exception");
            }

            foreach (var item in team.projectTeams)
            {
                ProjectTeam projectTeamObj = new ProjectTeam();
                projectTeamObj.EmployeeId = item.EmployeeId;
                projectTeamObj.ProjectId = item.ProjectId;
                projectTeamObj.DepartmentId = item.DepartmentId;
                projectTeamObj.ProjectPositionId = item.ProjectPositionId;
                projectTeamObj.TeamId = Id;
                _context.projectTeams.Add(projectTeamObj);
                _context.SaveChanges();
            }
            return Id;
        }

        public Team Find(int id)
        {
            return _context.Teams.Find(id);

        }

        public IEnumerable<Team> GetAll()
        {
            return _context.Teams.ToList();

        }

        public Team GetById(int id)
        {
            Team team = _context.Teams.Where(a => a.Id == id).FirstOrDefault();
            if (team == null)
            {
                throw new NotExistException("Not Exist Exception");
            }
            else
            {
                return team;
            }

        }

        public void Save()
        {
            _context.SaveChanges();

        }

        public void Update(int id, Team team)
        {
            if (id != team.Id)
            {
                throw new NotExistException("Not Exist Exception");
            }
            _context.Entry(team).State = EntityState.Modified;
            try
            {
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw new NotCompletedException("Not Completed Exception");
            }

        }
    }
}
