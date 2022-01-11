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
    public class ProjectService : IProjectService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProjectService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public int AddProject(ProjectDTO projectDTO)
        {
            _unitOfWork.Project.Add(projectDTO);
            return projectDTO.Id;
        }

        public IEnumerable<ProjectDTO> GetAllProjects()
        {
            return _unitOfWork.Project.GetAll();
        }

        public IEnumerable<ProjectDTO> GetAllProjectsByEmployeeId(int EmployeeId)
        {
            return _unitOfWork.Project.GetAllProjectsByEmployeeId(EmployeeId);
        }

        public List<ProjectDTO> GetAllProjectsByProjectTypeId(int ProjectTypeId)
        {
            return _unitOfWork.Project.GetAllProjectsByProjectTypeId(ProjectTypeId);
        }

        public IEnumerable<ClientDTO> GetClientByProjectId(int ProjectId)
        {
            return _unitOfWork.Project.GetClientByProjectId(ProjectId);
        }

        public ProjectDTO GetProjectById(int id)
        {
            return _unitOfWork.Project.GetById(id);
        }

        public Project GetProjectsByClientId(int ClientId)
        {
            return _unitOfWork.Project.GetProjectsByClientId(ClientId);
        }

        public void SoftDelete(ProjectDTO projectDTO)
        {
            _unitOfWork.Project.SoftDelete(projectDTO);
        }

        public void UpdateProject(int id, ProjectDTO projectDTO)
        {
            _unitOfWork.Project.Update(id,projectDTO);
        }
    }
}
