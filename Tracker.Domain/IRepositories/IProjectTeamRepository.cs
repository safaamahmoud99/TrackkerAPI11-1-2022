using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracker.Data.DTO;
using Tracker.Data.Models;
using Tracker.Data.ViewModels;

namespace Tracker.Domain.IRepositories
{
   public interface IProjectTeamRepository 
    {
        IEnumerable<ProjectTeamDTO> GetAll();
        ProjectTeamDTO GetById(int id);
        IEnumerable<ProjectTeamDTO> GetProjectTeamsByProjectId(int ProjectId);
        IEnumerable<ProjectTeamDTO> GetProjectTeamsByProjectPositionId(int ProjectPositionId);
        IEnumerable<ProjectTeamDTO> GetEmployeessByTeamId(int TeamId, int PositionId);
        ProjectTeamDTO GetProjectTeamByProjectIdAndTeamIdAndProjectPositionId(int ProjectId,int TeamId, int ProjectPositionId);
        IEnumerable<ProjectTeamDTO> GetProjectTeamByProjectPositionIdAndEmployeeId(int ProjectPositionId, int EmployeeId);
        List<ProjectTeamDTO> GetAllProjectTeamsByProjectIds(ProjectsVM model);
        ProjectTeamDTO GetTeamIdByEmployeeId(int EmployeeId);
        List<int> GetProjectIdByPosition(int positionId);
        ProjectTeamDTO GetTeamLeaderByTeamIdAndProjectPositionId(int TeamId, int ProjectPositionId);
        void UpdateByProjectId(int ProjectId, List<ProjectTeamDTO> projectTeamDTOs);
        ProjectTeam Find(int id);
        void Add(List<ProjectTeamDTO> projectTeamDTO);
        void Update(int id,ProjectTeamDTO projectTeamDTO);
        void Delete(int id);
        void Save();
    }
}
