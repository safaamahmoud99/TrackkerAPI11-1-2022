using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracker.Data.DTO;
using Tracker.Data.Models;
using Tracker.Domain.IRepositories;

namespace Tracker.Core.Repositories
{
    public class ProjectDocumentRepository : IProjectDocumentRepository
    {
        private readonly ApplicationDbContext _context;
        public ProjectDocumentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(List<ProjectDocumentDTO> projectDocumentDTO)
        {
            try
            {
                if (projectDocumentDTO != null)
                {
                    foreach (var item in projectDocumentDTO)
                    {
                        ProjectDocument projectDocument = new ProjectDocument();
                        projectDocument.Id = item.Id;
                        projectDocument.ProjectId = item.ProjectId;
                        projectDocument.DocumentName = item.DocumentName;
                        projectDocument.DocumentFile = item.DocumentFile;
                        projectDocument.Description = item.Description;
                        _context.Add(projectDocument);
                        _context.SaveChanges();
                    }
                }
                else
                {
                    throw new NotCompletedException("Not Completed Exception");
                }
            }
            catch (Exception)
            {
                throw new NotExistException("Not Exist Exception");
            }

        }

        public void Delete(int id)
        {

            ProjectDocument projectDocument = _context.projectDocuments.Find(id);
            if (projectDocument != null)
            {
                _context.projectDocuments.Remove(projectDocument);
                _context.SaveChanges();
            }
            else
            {
                throw new NotExistException("Not Exist Exception");
            }
        }
        public ProjectDocument Find(int id)
        {
            return _context.projectDocuments.Find(id);
        }

        public IEnumerable<ProjectDocumentDTO> GetAll()
        {
            var ProjectDocuments = _context.projectDocuments.Select(e => new ProjectDocumentDTO
            {
                Id = e.Id,
                ProjectId = e.ProjectId,
                DocumentFile = e.DocumentFile,
                DocumentName = e.DocumentName,
                ProjectName = e.Project.ProjectName,
                Description = e.Description

            }).ToList();
            return ProjectDocuments;
        }

        public ProjectDocumentDTO GetById(int id)
        {
            var projectDocument = _context.projectDocuments.Include(d => d.Project).FirstOrDefault(d => d.Id == id);
            if (projectDocument == null)
            {
                throw new NotExistException("Not Exist Exception");
            }
            else
            {
                var projectDocumentDTO = new ProjectDocumentDTO()
                {
                    Id = projectDocument.Id,
                    Description = projectDocument.Description,
                    DocumentName = projectDocument.DocumentName,
                    DocumentFile = projectDocument.DocumentFile,
                    ProjectId = projectDocument.ProjectId,
                    ProjectName = projectDocument.Project.ProjectName
                };
                return projectDocumentDTO;
            }

        }
        public IEnumerable<ProjectDocumentDTO> GetProjectDocumentsByProjectId(int ProjectId)
        {
            var projectDocument = _context.projectDocuments.Where(d => d.ProjectId == ProjectId).Select(projectDocument =>
                new ProjectDocumentDTO()
                {
                    Id = projectDocument.Id,
                    Description = projectDocument.Description,
                    DocumentName = projectDocument.DocumentName,
                    DocumentFile = projectDocument.DocumentFile,
                    ProjectId = projectDocument.ProjectId,
                    ProjectName = projectDocument.Project.ProjectName
                }).ToList();
            return projectDocument;
        }
        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(int id, ProjectDocumentDTO projectDocumentDTO)
        {
            if (id != projectDocumentDTO.Id)
            {
                throw new NotExistException("Not Exist Exception");
            }
            try
            {
                ProjectDocument projectDocument = new ProjectDocument();
                projectDocument.Id = projectDocumentDTO.Id;
                projectDocument.ProjectId = projectDocumentDTO.ProjectId;
                projectDocument.Description = projectDocumentDTO.Description;
                _context.Entry(projectDocument).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw new NotCompletedException("Not Completed Exception");
            }

        }
        public void UpdateByProjectId(int ProjectId, List<ProjectDocumentDTO> projectDocumentDTOs)
        {
            if (ProjectId == 0)
            {
                throw new NotExistException("Not Exist Exception");
            }
            try
            {
                foreach (var item in projectDocumentDTOs)
                {
                    ProjectDocument projectDocument = new ProjectDocument();
                    projectDocument.Id = item.Id;
                    item.ProjectId = ProjectId;
                    projectDocument.ProjectId = item.ProjectId;
                    projectDocument.Description = item.Description;
                    projectDocument.DocumentFile = item.DocumentFile;
                    projectDocument.DocumentFile = item.DocumentFile;
                    projectDocument.DocumentName = item.DocumentName;
                    _context.Entry(projectDocument).State = EntityState.Modified;
                    _context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw new NotCompletedException("Not Completed Exception");
            }
        }
    }
}
