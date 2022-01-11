using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracker.Data.DTO;
using Tracker.Data.Models;
using TrackingSystemAPI.DTO;

namespace Tracker.Domain.IRepositories
{
   public interface IProjectRepository 
    {
        IEnumerable<ProjectDTO> GetAll();
        ProjectDTO GetById(int id);
        Project GetProjectsByClientId(int ClientId);
       // IEnumerable<ProjectDTO> GetClientsByEmployeeId(int EmployeeId);
        IEnumerable<ClientDTO> GetClientByProjectId(int ProjectId);
        IEnumerable<ProjectDTO> GetAllProjectsByEmployeeId(int EmployeeId);
        List<ProjectDTO> GetAllProjectsByProjectTypeId(int ProjectTypeId);
        Project Find(int id);
        int Add(ProjectDTO projectDTO);
        void Update(int id,ProjectDTO projectDTO);
        void SoftDelete(ProjectDTO projectDTO);
        void Save();

    }
}
