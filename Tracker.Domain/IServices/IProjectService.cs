using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data.DTO;
using Tracker.Data.Models;

namespace Tracker.Domain.IServices
{
    public interface IProjectService
    {
        IEnumerable<ProjectDTO> GetAllProjects();
        ProjectDTO GetProjectById(int id);
        Project GetProjectsByClientId(int ClientId);
        // IEnumerable<ProjectDTO> GetClientsByEmployeeId(int EmployeeId);
        IEnumerable<ClientDTO> GetClientByProjectId(int ProjectId);
        IEnumerable<ProjectDTO> GetAllProjectsByEmployeeId(int EmployeeId);
        List<ProjectDTO> GetAllProjectsByProjectTypeId(int ProjectTypeId);
        int AddProject(ProjectDTO projectDTO);
        void UpdateProject(int id,ProjectDTO projectDTO);
        void SoftDelete(ProjectDTO projectDTO);
    }
}
