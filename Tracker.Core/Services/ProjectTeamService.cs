using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data.DTO;
using Tracker.Data.ViewModels;
using Tracker.Domain;
using Tracker.Domain.IServices;

namespace Tracker.Core.Services
{
    public class ProjectTeamService : IProjectTeamService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProjectTeamService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void AddProjectTeam(List<ProjectTeamDTO> projectTeamDTO)
        {
            _unitOfWork.ProjectTeam.Add(projectTeamDTO);
        }

        public void Delete(int id)
        {
            _unitOfWork.ProjectTeam.Delete(id);
        }

        public IEnumerable<ProjectTeamDTO> GetAllProjectTeams()
        {
            return _unitOfWork.ProjectTeam.GetAll();
        }

        public List<ProjectTeamDTO> GetAllProjectTeamsByProjectIds(ProjectsVM model)
        {
            return _unitOfWork.ProjectTeam.GetAllProjectTeamsByProjectIds(model);
        }

        public IEnumerable<ProjectTeamDTO> GetEmployeessByTeamId(int TeamId, int PositionId)
        {
            return _unitOfWork.ProjectTeam.GetEmployeessByTeamId(TeamId, PositionId);
        }

        public List<int> GetProjectIdByPosition(int positionId)
        {
            return _unitOfWork.ProjectTeam.GetProjectIdByPosition(positionId);
        }

        public ProjectTeamDTO GetProjectTeamById(int id)
        {
            return _unitOfWork.ProjectTeam.GetById(id);
        }

        public ProjectTeamDTO GetProjectTeamByProjectIdAndTeamIdAndProjectPositionId(int ProjectId, int TeamId, int ProjectPositionId)
        {
            return _unitOfWork.ProjectTeam.GetProjectTeamByProjectIdAndTeamIdAndProjectPositionId(ProjectId, TeamId, ProjectPositionId);
        }

        public IEnumerable<ProjectTeamDTO> GetProjectTeamByProjectPositionIdAndEmployeeId(int ProjectPositionId, int EmployeeId)
        {
            return _unitOfWork.ProjectTeam.GetProjectTeamByProjectPositionIdAndEmployeeId(ProjectPositionId, EmployeeId);
        }

        public IEnumerable<ProjectTeamDTO> GetProjectTeamsByProjectId(int ProjectId)
        {
            return _unitOfWork.ProjectTeam.GetProjectTeamsByProjectId(ProjectId);
        }

        public IEnumerable<ProjectTeamDTO> GetProjectTeamsByProjectPositionId(int ProjectPositionId)
        {
            return _unitOfWork.ProjectTeam.GetProjectTeamsByProjectPositionId(ProjectPositionId);
        }

        public ProjectTeamDTO GetTeamIdByEmployeeId(int EmployeeId)
        {
           return  _unitOfWork.ProjectTeam.GetTeamIdByEmployeeId(EmployeeId);
        }

        public ProjectTeamDTO GetTeamLeaderByTeamIdAndProjectPositionId(int TeamId, int ProjectPositionId)
        {
            return _unitOfWork.ProjectTeam.GetTeamLeaderByTeamIdAndProjectPositionId(TeamId, ProjectPositionId);
        }

        public void UpdateByProjectId(int ProjectId, List<ProjectTeamDTO> projectTeamDTOs)
        {
             _unitOfWork.ProjectTeam.UpdateByProjectId(ProjectId, projectTeamDTOs);
        }

        public void UpdateProjectTeam(int id, ProjectTeamDTO projectTeamDTO)
        {
            _unitOfWork.ProjectTeam.Update(id,projectTeamDTO);
        }
    }
}
