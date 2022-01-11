using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data.DTO;
using Tracker.Data.ViewModels;

namespace Tracker.Domain.IServices
{
    public interface IProjectTeamService
    {
        IEnumerable<ProjectTeamDTO> GetAllProjectTeams();
        ProjectTeamDTO GetProjectTeamById(int id);
        IEnumerable<ProjectTeamDTO> GetProjectTeamsByProjectId(int ProjectId);
        IEnumerable<ProjectTeamDTO> GetProjectTeamsByProjectPositionId(int ProjectPositionId);
        IEnumerable<ProjectTeamDTO> GetEmployeessByTeamId(int TeamId, int PositionId);
        ProjectTeamDTO GetProjectTeamByProjectIdAndTeamIdAndProjectPositionId(int ProjectId, int TeamId, int ProjectPositionId);
        IEnumerable<ProjectTeamDTO> GetProjectTeamByProjectPositionIdAndEmployeeId(int ProjectPositionId, int EmployeeId);
        List<ProjectTeamDTO> GetAllProjectTeamsByProjectIds(ProjectsVM model);
        ProjectTeamDTO GetTeamIdByEmployeeId(int EmployeeId);
        List<int> GetProjectIdByPosition(int positionId);
        ProjectTeamDTO GetTeamLeaderByTeamIdAndProjectPositionId(int TeamId, int ProjectPositionId);
        void UpdateByProjectId(int ProjectId, List<ProjectTeamDTO> projectTeamDTOs);
        void AddProjectTeam(List<ProjectTeamDTO> projectTeamDTO);
        void UpdateProjectTeam(int id,ProjectTeamDTO projectTeamDTO);
        void Delete(int id);
    }
}
