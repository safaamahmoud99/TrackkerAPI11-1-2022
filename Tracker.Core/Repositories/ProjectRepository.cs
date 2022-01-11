using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Tracker.Data.DTO;
using Tracker.Data.Models;
using Tracker.Domain.IRepositories;

namespace Tracker.Core.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ApplicationDbContext _context;
        public ProjectRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public int Add(ProjectDTO projectDTO)
        {
            try
            {
                if (projectDTO != null)
                {
                    var project = new Project();
                    project.ProjectName = projectDTO.ProjectName;
                    project.ProjectCode = projectDTO.ProjectCode;
                    project.ProjectTypeId = projectDTO.ProjectTypeId;
                    project.Cost = projectDTO.Cost;
                    project.ProjectPeriod = projectDTO.ProjectPeriod;
                    project.IsDeleted = false;

                    project.PlanndedStartDate = projectDTO.PlanndedStartDate;
                    project.ActualStartDate = projectDTO.ActualStartDate;
                    project.PlanndedEndDate = projectDTO.PlanndedEndDate;
                    project.ActualEndDate = projectDTO.ActualEndDate;
                    project.Description = projectDTO.Description;
                    project.OrganizationId = projectDTO.OrganizationId;
                    project.EmployeeId = projectDTO.EmployeeId;
                    //project.ClientId = projectDTO.ClientId;
                    _context.projects.Add(project);
                    _context.SaveChanges();
                    projectDTO.Id=project.Id;
                    return projectDTO.Id;
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

        public void SoftDelete(ProjectDTO projectDTO)
        {
            if (projectDTO != null)
            {
                var project = new Project();
                project.Id = projectDTO.Id;
                project.ProjectName = projectDTO.ProjectName;
                project.ProjectCode = projectDTO.ProjectCode;
                project.ProjectTypeId = projectDTO.ProjectTypeId;
                project.Cost = projectDTO.Cost;
                project.IsDeleted = true;
                project.ProjectPeriod = projectDTO.ProjectPeriod;
                project.PlanndedStartDate = projectDTO.PlanndedStartDate;
                project.ActualStartDate = projectDTO.ActualStartDate;
                project.PlanndedEndDate = projectDTO.PlanndedEndDate;
                project.ActualEndDate = projectDTO.ActualEndDate;
                project.Description = projectDTO.Description;
                project.OrganizationId = projectDTO.OrganizationId;
                project.EmployeeId = projectDTO.EmployeeId;
                //project.ClientId = projectDTO.ClientId;
                _context.Entry(project).State = EntityState.Modified;
                _context.SaveChanges();
            }
            else
            {
                throw new NotExistException("Not Exist Exception");
            }
        }

        public Project Find(int id)
        {
            return _context.projects.Find(id);
        }

        public IEnumerable<ProjectDTO> GetAll()
        {
            var proj = _context.projects.Where(e => e.IsDeleted == false).Select(e => new ProjectDTO
            {
                Id = e.Id,
                ProjectName = e.ProjectName,
                ProjectCode = e.ProjectCode,
                Cost = e.Cost,
                ProjectTypeId = e.ProjectTypeId,
                ProjectTypeName = e.ProjectType.TypeName,
                // IsDeleted=e.IsDeleted,
                ProjectPeriod = e.ProjectPeriod,
                PlanndedStartDate = e.PlanndedStartDate,
                PlanndedEndDate = e.PlanndedEndDate,
                ActualStartDate = e.ActualStartDate,
                ActualEndDate = e.ActualEndDate,
                Description = e.Description,
                OrganizationId = e.OrganizationId,
                OrganizationName = e.Organization.OrganizationName,
                EmployeeId = e.EmployeeId,
                EmployeeName = e.Employee.EmployeeName,
                //ClientId = e.ClientId,
                //ClientName = e.Client.ClientName,
                //ClientMobile=e.Client.Phone
            }).OrderByDescending(p => p.Id).ToList();
            return proj;
        }

        public ProjectDTO GetById(int id)
        {
            var project = _context.projects.Include(p => p.Organization).Include(p => p.Employee).Include(p => p.ProjectType).FirstOrDefault(e => e.Id == id);
            if (project == null)
            {
                throw new NotExistException("Not Exist Exception");
            }
            else
            {
                var projectDTO = new ProjectDTO
                {
                    Id = project.Id,
                    ProjectName = project.ProjectName,
                    ProjectCode = project.ProjectCode,
                    ProjectTypeId = project.ProjectTypeId,
                    ProjectTypeName = project.ProjectType.TypeName,
                    Cost = project.Cost,
                    ProjectPeriod = project.ProjectPeriod,
                    PlanndedStartDate = project.PlanndedStartDate,
                    IsDeleted = project.IsDeleted,
                    ActualStartDate = project.ActualStartDate,
                    PlanndedEndDate = project.PlanndedEndDate,
                    ActualEndDate = project.ActualEndDate,
                    Description = project.Description,
                    OrganizationId = project.OrganizationId,
                    OrganizationName = project.Organization.OrganizationName,
                    EmployeeId = project.EmployeeId,
                    //EmployeeName = project.Employee.EmployeeName,
                    //ClientId = project.ClientId,
                    //ClientName = project.Client.ClientName,
                    //ClientMobile=project.Client.Phone

                };
                return projectDTO;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(int id, ProjectDTO projectDTO)
        {
            if (id != projectDTO.Id)
            {
                throw new NotExistException("Not Exist Exception");
            }
            try
            {
                var project = new Project();
                project.Id = projectDTO.Id;
                project.ProjectName = projectDTO.ProjectName;
                project.ProjectCode = projectDTO.ProjectCode;
                project.ProjectTypeId = projectDTO.ProjectTypeId;
                project.Cost = projectDTO.Cost;
                project.IsDeleted = projectDTO.IsDeleted;
                project.ProjectPeriod = projectDTO.ProjectPeriod;
                project.PlanndedStartDate = projectDTO.PlanndedStartDate;
                project.ActualStartDate = projectDTO.ActualStartDate;
                project.PlanndedEndDate = projectDTO.PlanndedEndDate;
                project.ActualEndDate = projectDTO.ActualEndDate;
                project.Description = projectDTO.Description;
                project.OrganizationId = projectDTO.OrganizationId;
                project.EmployeeId = projectDTO.EmployeeId;
                //project.ClientId = projectDTO.ClientId;
                _context.Entry(project).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw new NotCompletedException("Not Completed Exception");
            }

        }
        //public IEnumerable<ProjectDTO> GetProjectsByClientId(int ClientId)
        //{
        //    var pro = _context.projects.Where(p => p.ClientId == ClientId && p.IsDeleted==false).Select(project => new ProjectDTO
        //    {
        //        ProjectName = project.ProjectName,
        //        ProjectCode = project.ProjectCode
        //    }).OrderByDescending(p => p.Id).ToList();
        //    return pro;
        //}
        public IEnumerable<ClientDTO> GetClientByProjectId(int ProjectId)
        {
            var clientDTO = _context.SiteClients.Where(c => c.ProjectSites.ProjectId == ProjectId).Select(client => new ClientDTO
            {
                ClientName = client.Client.ClientName,
                Id = client.ClientId
            }).ToList();
            return clientDTO;
        }

        public IEnumerable<ProjectDTO> GetAllProjectsByEmployeeId(int EmployeeId)
        {
            var proj = _context.projects.Where(e => e.IsDeleted == false && e.EmployeeId == EmployeeId).
                Include(p => p.Organization).
                Include(p => p.Employee).
                Include(p => p.ProjectType).
                Select(e => new ProjectDTO
                {
                    Id = e.Id,
                    ProjectName = e.ProjectName,
                    ProjectCode = e.ProjectCode,
                    Cost = e.Cost,
                    ProjectTypeId = e.ProjectTypeId,
                    ProjectTypeName = e.ProjectType.TypeName,
                    ProjectPeriod = e.ProjectPeriod,
                    PlanndedStartDate = e.PlanndedStartDate,
                    PlanndedEndDate = e.PlanndedEndDate,
                    ActualStartDate = e.ActualStartDate,
                    ActualEndDate = e.ActualEndDate,
                    Description = e.Description,
                    OrganizationId = e.OrganizationId,
                    OrganizationName = e.Organization.OrganizationName,
                    EmployeeId = e.EmployeeId,
                    EmployeeName = e.Employee.EmployeeName,
                }).OrderByDescending(p => p.Id).ToList();
            return proj;
        }

        //public IEnumerable<ProjectDTO> GetClientsByEmployeeId(int EmployeeId)
        //{
        //    var proj = _context.projects.Where(e => e.IsDeleted == false && e.EmployeeId == EmployeeId).
        //        Include(p => p.Organization).
        //        Include(p => p.Client).
        //        Select(e => new ProjectDTO
        //        { ClientCode=e.Client.ClientCode,
        //        Address=e.Client.Address,
        //            Email=e.Client.Email,
        //            Phone=e.Client.Phone,
        //            Gender=e.Client.gender,
        //            OrganizationId = e.OrganizationId,
        //            OrganizationName = e.Organization.OrganizationName,
        //            EmployeeId = e.EmployeeId,
        //            EmployeeName = e.Employee.EmployeeName,
        //            ClientId = e.ClientId,
        //            ClientName = e.Client.ClientName,
        //        }).ToList();
        //    return proj;
        //}

        public List<ProjectDTO> GetAllProjectsByProjectTypeId(int ProjectTypeId)
        {
            var project = _context.projects.Where(e => e.ProjectTypeId == ProjectTypeId && e.IsDeleted == false).Select(e => new ProjectDTO
            {
                ProjectTypeId = e.ProjectTypeId,
                ActualEndDate = e.ActualEndDate,
                ProjectName = e.ProjectName,
                EmployeeId = e.EmployeeId,
                Id = e.Id,
                IsDeleted = e.IsDeleted,
                OrganizationId = e.OrganizationId,
                OrganizationName = e.Organization.OrganizationName,
                EmployeeName = e.Employee.EmployeeName,
                PlanndedEndDate = e.PlanndedEndDate,
                PlanndedStartDate = e.PlanndedStartDate
            }).OrderByDescending(p => p.Id).ToList();
            return project;
        }

        public Project GetProjectsByClientId(int ClientId)
        {
            var project = _context.SiteClients.Where(p => p.ClientId == ClientId).Select(p => p.ProjectSites.Project).FirstOrDefault();
            return project;
        }
    }
}
