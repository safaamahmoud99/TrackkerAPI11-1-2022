using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data.DTO;
using Tracker.Domain;
using Tracker.Domain.IServices;

namespace Tracker.Core.Services
{
    public class ProjectDocumentService : IProjectDocumentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProjectDocumentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void AddProjectDocuments(List<ProjectDocumentDTO> projectDocumentDTO)
        {
            _unitOfWork.ProjectDocument.Add(projectDocumentDTO);
        }

        public void DeleteProjectDocument(int id)
        {
            _unitOfWork.ProjectDocument.Delete(id);
        }

        public IEnumerable<ProjectDocumentDTO> GetAllProjectDocuments()
        {
            return _unitOfWork.ProjectDocument.GetAll();
        }

        public ProjectDocumentDTO GetProjectDocumentById(int id)
        {
           return _unitOfWork.ProjectDocument.GetById(id);
        }

        public IEnumerable<ProjectDocumentDTO> GetProjectDocumentsByProjectId(int ProjectId)
        {
            return _unitOfWork.ProjectDocument.GetProjectDocumentsByProjectId(ProjectId);
        }

        public void UpdateByProjectId(int ProjectId, List<ProjectDocumentDTO> projectDocumentDTOs)
        {
            _unitOfWork.ProjectDocument.UpdateByProjectId(ProjectId, projectDocumentDTOs);
        }

        public void UpdateProjectDocument(int id, ProjectDocumentDTO projectDocumentDTO)
        {
            _unitOfWork.ProjectDocument.Update(id,projectDocumentDTO);
        }
    }
}
