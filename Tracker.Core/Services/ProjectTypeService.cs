using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data.Models;
using Tracker.Domain;
using Tracker.Domain.IServices;

namespace Tracker.Core.Services
{
    public class ProjectTypeService : IProjectTypeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProjectTypeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void AddProjectType(ProjectType projectType)
        {
            _unitOfWork.ProjectType.Add(projectType);
        }

        public void DeleteProjectType(int id)
        {
            _unitOfWork.ProjectType.Delete(id);
        }

        public IEnumerable<ProjectType> GetAllProjectTypes()
        {
            return _unitOfWork.ProjectType.GetAll();
        }

        public ProjectType GetProjectTypeById(int id)
        {
            return _unitOfWork.ProjectType.GetById(id);
        }

        public void UpdateProjectType(int id, ProjectType projectType)
        {
            _unitOfWork.ProjectType.Update(id,projectType);
        }
    }
}
