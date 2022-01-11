using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracker.Data.DTO;
using Tracker.Data.Models;
using Tracker.Data.ViewModels;
using Tracker.Domain.IRepositories;
using TrackingSystemAPI.DTO;

namespace Tracker.Core.Repositories
{
    public class ProjectTeamRepository : IProjectTeamRepository
    {
        private readonly ApplicationDbContext _context;
        public ProjectTeamRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public void Add(List<ProjectTeamDTO> projectTeamDTO)
        {
            try
            {
                if (projectTeamDTO != null)
                {
                    foreach (var item in projectTeamDTO)
                    {
                        ProjectTeam projectTeam = new ProjectTeam();
                        projectTeam.EmployeeId = item.EmployeeId;
                        //projectTeam.teamName = item.teamName;
                        projectTeam.ProjectId = item.ProjectId;
                        projectTeam.DepartmentId = item.DepartmentId;
                        projectTeam.ProjectPositionId = item.ProjectPositionId;
                        projectTeam.TeamId = item.TeamId;
                        _context.projectTeams.Add(projectTeam);
                        _context.SaveChanges();
                    }
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
        }
        public void Delete(int id)
        {
            ProjectTeam projectTeam = _context.projectTeams.Find(id);
            if (projectTeam != null)
            {
                _context.projectTeams.Remove(projectTeam);
                _context.SaveChanges();
            }
            else
            {
                throw new NotExistException("Not Exist Exception");
            }
        }
        public ProjectTeam Find(int id)
        {
            return _context.projectTeams.Find(id);
        }

        public IEnumerable<ProjectTeamDTO> GetAll()
        {

            var projectTeam = _context.projectTeams.Select(Pteam => new ProjectTeamDTO
            {
                EmployeeId = Pteam.EmployeeId,
                // teamName = Pteam.teamName,
                EmployeeName = Pteam.Employee.EmployeeName,
                ProjectId = Pteam.ProjectId,
                TeamId = Pteam.TeamId,
                ProjectName = Pteam.Project.ProjectName,
                DepartmentId = Pteam.DepartmentId,
                DepartmentName = Pteam.Department.Name,
                ProjectPositionId = Pteam.ProjectPositionId,
                ProjectPositionName = Pteam.ProjectPosition.PositionName,
            }).ToList();
            return projectTeam;
        }

        public ProjectTeamDTO GetById(int id)
        {
            var projectTeam = _context.projectTeams
                              .Include(p => p.Employee).Include(p => p.Department)
                              .Include(p => p.Project).Include(p => p.ProjectPosition)
                              .Include(p => p.Team)
                              .FirstOrDefault(predicate => predicate.Id == id);

            if (projectTeam == null)
            {
                throw new NotExistException("Not Exist Exception");
            }
            else
            {
                ProjectTeamDTO projectTeamDTO = new ProjectTeamDTO
                {
                    EmployeeId = projectTeam.EmployeeId,
                    teamName = projectTeam.Team.Name,
                    EmployeeName = projectTeam.Employee.EmployeeName,
                    ProjectId = projectTeam.ProjectId,
                    TeamId = projectTeam.TeamId,
                    ProjectName = projectTeam.Project.ProjectName,
                    DepartmentId = projectTeam.DepartmentId,
                    DepartmentName = projectTeam.Department.Name,
                    ProjectPositionId = projectTeam.ProjectPositionId,
                    ProjectPositionName = projectTeam.ProjectPosition.PositionName,
                };
                return projectTeamDTO;
            }

        }
        public IEnumerable<ProjectTeamDTO> GetProjectTeamsByProjectId(int ProjectId)
        {
            var projectTeam = _context.projectTeams.Where(p => p.ProjectId == ProjectId).Select(projectTeam => new ProjectTeamDTO
            {
                ID = projectTeam.Id,
                EmployeeId = projectTeam.EmployeeId,
                teamName = projectTeam.Team.Name,
                TeamId = projectTeam.TeamId,
                EmployeeName = projectTeam.Employee.EmployeeName,
                ProjectId = projectTeam.ProjectId,
                ProjectName = projectTeam.Project.ProjectName,
                DepartmentId = projectTeam.DepartmentId,
                DepartmentName = projectTeam.Department.Name,
                ProjectPositionId = projectTeam.ProjectPositionId,
                ProjectPositionName = projectTeam.ProjectPosition.PositionName,
            }).Distinct().ToList();
            return projectTeam;
        }
        public IEnumerable<ProjectTeamDTO> GetProjectTeamsByProjectPositionId(int ProjectPositionId)
        {
            var projectTeam = _context.projectTeams.Where(p => p.ProjectPositionId == ProjectPositionId).Select(projectTeam => new ProjectTeamDTO
            {
                ID = projectTeam.Id,
                EmployeeId = projectTeam.EmployeeId,
                teamName = projectTeam.Team.Name,
                EmployeeName = projectTeam.Employee.EmployeeName,
                ProjectId = projectTeam.ProjectId,
                ProjectName = projectTeam.Project.ProjectName,
                DepartmentId = projectTeam.DepartmentId,
                TeamId = projectTeam.TeamId,
                DepartmentName = projectTeam.Department.Name,
            }).ToList();
            return projectTeam;
        }
        public ProjectTeamDTO GetProjectTeamByProjectIdAndTeamIdAndProjectPositionId(int ProjectId, int TeamId, int ProjectPositionId)
        {
            var projectTeam = _context.projectTeams.Where(p => p.ProjectId == ProjectId && p.TeamId == TeamId && p.ProjectPositionId == ProjectPositionId).Select(projectTeam => new ProjectTeamDTO
            {
                ID = projectTeam.Id,
                teamName = projectTeam.Team.Name,
                TeamId = projectTeam.TeamId,
                ProjectId = projectTeam.ProjectId,
                ProjectName = projectTeam.Project.ProjectName,
                ProjectPositionId = projectTeam.ProjectPositionId,
                ProjectPositionName = projectTeam.ProjectPosition.PositionName,
            }).FirstOrDefault();
            return projectTeam;
        }
        public IEnumerable<ProjectTeamDTO> GetProjectTeamByProjectPositionIdAndEmployeeId(int ProjectPositionId, int EmployeeId)
        {
            var projectteam = _context.projectTeams.Where(p => p.ProjectPositionId == ProjectPositionId && p.EmployeeId == EmployeeId)
                .Include(p => p.ProjectPosition).Include(p => p.Employee).Select(team => new ProjectTeamDTO
                {
                    ID = team.Id
                }).ToList();

            return projectteam;
        }
        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(int id, ProjectTeamDTO projectTeamDTO)
        {
            if (id != projectTeamDTO.ID)
            {
                throw new NotExistException("Not Exist Exception");
            }
            try
            {
                ProjectTeam projectTeam = new ProjectTeam();
                projectTeam.Id = projectTeamDTO.ID;
                //  projectTeam.teamName = projectTeamDTO.teamName;
                projectTeam.TeamId = projectTeamDTO.TeamId;
                projectTeam.EmployeeId = projectTeamDTO.EmployeeId;
                projectTeam.ProjectId = projectTeamDTO.ProjectId;
                projectTeam.DepartmentId = projectTeamDTO.DepartmentId;
                projectTeam.ProjectPositionId = projectTeamDTO.ProjectPositionId;
                _context.Entry(projectTeam).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw new NotCompletedException("Not Completed Exception");
            }
        }
        public void UpdateByProjectId(int ProjectId, List<ProjectTeamDTO> projectTeamDTOs)
        {
            if (ProjectId == 0)
            {
                throw new NotExistException("Not Exist Exception");
            }
            try
            {
                foreach (var item in projectTeamDTOs)
                {
                    ProjectTeam projectTeam = new ProjectTeam();
                    projectTeam.Id = item.ID;
                    //projectTeam.teamName = item.teamName;
                    projectTeam.TeamId = item.TeamId;
                    projectTeam.EmployeeId = item.EmployeeId;
                    item.ProjectId = ProjectId;
                    projectTeam.ProjectId = item.ProjectId;
                    projectTeam.DepartmentId = item.DepartmentId;
                    projectTeam.ProjectPositionId = item.ProjectPositionId;
                    _context.Entry(projectTeam).State = EntityState.Modified;
                    _context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw new NotCompletedException("Not Completed Exception");
            }
        }

        public IEnumerable<ProjectTeamDTO> GetEmployeessByTeamId(int TeamId, int PositionId)
        {
            var Employees = _context.projectTeams.Where(p => p.TeamId == TeamId && p.ProjectPositionId == PositionId).Select(projectTeam => new ProjectTeamDTO
            {
                EmployeeId = projectTeam.EmployeeId,
                EmployeeName = projectTeam.Employee.EmployeeName,
                ProjectPositionId = projectTeam.ProjectPositionId,
                ProjectPositionName = projectTeam.ProjectPosition.PositionName

            }).ToList();
            return Employees;
        }

        public List<ProjectTeamDTO> GetAllProjectTeamsByProjectIds(ProjectsVM model)
        {
            List<ProjectTeamDTO> projectTeamDTO = new List<ProjectTeamDTO>();
            var Ids = model.ProjectIds.Split(",");
            string[] lstIds = Ids;
            foreach (var item in lstIds)
            {
                int projectId = int.Parse(item);
                var projectTeam = _context.projectTeams.Where(p => p.ProjectId == projectId).Select(projectTeam => new ProjectTeamDTO
                {
                    ID = projectTeam.Id,
                    EmployeeId = projectTeam.EmployeeId,
                    teamName = projectTeam.Team.Name,
                    TeamId = projectTeam.TeamId,
                    EmployeeName = projectTeam.Employee.EmployeeName,
                    ProjectId = projectTeam.ProjectId,
                    ProjectName = projectTeam.Project.ProjectName,
                    DepartmentId = projectTeam.DepartmentId,
                    DepartmentName = projectTeam.Department.Name,
                    ProjectPositionId = projectTeam.ProjectPositionId,
                    ProjectPositionName = projectTeam.ProjectPosition.PositionName,
                }).ToList();
                foreach (var item2 in projectTeam)
                {
                    projectTeamDTO.Add(item2);
                }
            }

            return projectTeamDTO;
        }

        public ProjectTeamDTO GetTeamIdByEmployeeId(int EmployeeId)
        {
            if (EmployeeId == 0)
            {
                throw new NotExistException("Not Exist Exception");
            }
            else
            {
                var Team = _context.projectTeams.Where(p => p.EmployeeId == EmployeeId).Select(projectTeam => new ProjectTeamDTO
                {
                    ID = projectTeam.Id,
                    TeamId = projectTeam.TeamId,
                    teamName = projectTeam.Team.Name

                }).FirstOrDefault();
                return Team;
            }

        }

        public ProjectTeamDTO GetTeamLeaderByTeamIdAndProjectPositionId(int TeamId, int ProjectPositionId)
        {
            if (TeamId == 0 && ProjectPositionId == 0)
            {
                throw new NotExistException("Not Exist Exception");
            }
            else
            {
                var TeamLeader = _context.projectTeams.Where(p => p.TeamId == TeamId && p.ProjectPositionId == ProjectPositionId).Select(projectTeam => new ProjectTeamDTO
                {
                    ID = projectTeam.Id,
                    EmployeeId = projectTeam.EmployeeId,
                    EmployeeName = projectTeam.Employee.EmployeeName
                }).FirstOrDefault();
                return TeamLeader;
            }

        }

        public List<int> GetProjectIdByPosition(int positionId)
        {
            throw new NotImplementedException();
        }
    }
}
