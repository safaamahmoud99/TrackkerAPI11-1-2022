using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data.DTO;
using Tracker.Data.Models;

namespace Tracker.Domain.IServices
{
    public interface IProjectDocumentService
    {
        IEnumerable<ProjectDocumentDTO> GetAllProjectDocuments();
        ProjectDocumentDTO GetProjectDocumentById(int id);
        IEnumerable<ProjectDocumentDTO> GetProjectDocumentsByProjectId(int ProjectId);
        void UpdateByProjectId(int ProjectId, List<ProjectDocumentDTO> projectDocumentDTOs);
        void AddProjectDocuments(List<ProjectDocumentDTO> projectDocumentDTO);
        void UpdateProjectDocument(int id,ProjectDocumentDTO projectDocumentDTO);
        void DeleteProjectDocument(int id);
    }
}
