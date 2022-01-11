using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracker.Data.DTO;
using Tracker.Data.Models;

namespace Tracker.Domain.IRepositories
{
    public interface IProjectDocumentRepository 
    {
        IEnumerable<ProjectDocumentDTO> GetAll();
        ProjectDocumentDTO GetById(int id);
        IEnumerable<ProjectDocumentDTO> GetProjectDocumentsByProjectId(int ProjectId);
        void UpdateByProjectId(int ProjectId, List<ProjectDocumentDTO> projectDocumentDTOs);
        ProjectDocument Find(int id);
        void Add(List<ProjectDocumentDTO> projectDocumentDTO);
        void Update(int id,ProjectDocumentDTO projectDocumentDTO);
        void Delete(int id);
        void Save();
    }
}
