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
    public class ProjectPositionService : IProjectPositionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProjectPositionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void AddProjectPosition(ProjectPosition projectPosition)
        {
            _unitOfWork.ProjectPosition.Add(projectPosition);
        }

        public void DeleteProjectPosition(int id)
        {
            _unitOfWork.ProjectPosition.Delete(id);
        }

        public IEnumerable<ProjectPosition> GetAllProjectPositions()
        {
            return _unitOfWork.ProjectPosition.GetAll();
        }

        public ProjectPosition GetProjectPositionById(int id)
        {
           return _unitOfWork.ProjectPosition.GetById(id);
        }

        public void UpdateProjectPosition(int id, ProjectPosition projectPosition)
        {
            _unitOfWork.ProjectPosition.Update(id,projectPosition);
        }
    }
}
