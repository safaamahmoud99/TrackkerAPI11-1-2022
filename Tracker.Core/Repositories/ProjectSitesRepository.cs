using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data.DTO;
using Tracker.Data.Models;
using Tracker.Domain.IRepositories;

namespace Tracker.Core.Repositories
{
    public class ProjectSitesRepository : IProjectSitesRepository
    {
        private readonly ApplicationDbContext _context;

        public ProjectSitesRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(ProjectSitesDTO ProjectSitesDTO)
        {
            try
            {
                if (ProjectSitesDTO != null)
                {
                    foreach (var item in ProjectSitesDTO.LstSites)
                    {
                        ProjectSites projectSites = new ProjectSites();
                        projectSites.ProjectId = ProjectSitesDTO.ProjectId;
                        projectSites.SiteId = item.Id;
                        _context.ProjectSites.Add(projectSites);
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
            throw new NotImplementedException();
        }

        public IEnumerable<ProjectSitesDTO> GetAll()
        {
            var ProjectSites = _context.ProjectSites.Select(projectsite => new ProjectSitesDTO
            {
                Id = projectsite.Id,
                ProjectId = projectsite.ProjectId,
                ProjectName = projectsite.Project.ProjectName,
                SiteId = projectsite.SiteId,
                SiteName = projectsite.Sites.Sitename
            }).ToList();
            return ProjectSites;
        }

        public IEnumerable<Sites> GetAllSitesByProjectId(int ProjectId)
        {
            List<Sites> lstSites = new List<Sites>();
            if (ProjectId == 0)
            {
                throw new NotExistException("Not Exist Exception");
            }
            else
            {
                var ProjectSites = _context.ProjectSites.Where(p => p.ProjectId == ProjectId).Select(projectsite => new ProjectSitesDTO
                {
                    Id = projectsite.Id,
                    ProjectId = projectsite.ProjectId,
                    ProjectName = projectsite.Project.ProjectName,
                    SiteId = projectsite.SiteId,
                    SiteName = projectsite.Sites.Sitename
                }).ToList();
                foreach (var item in ProjectSites)
                {
                    Sites sites = new Sites();
                    sites.Id = item.SiteId;
                    sites.Sitename = item.SiteName;
                    lstSites.Add(sites);
                }
                return lstSites;
            }
        }

        public ProjectSitesDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public ProjectSites GetProjectSiteByProjectIdAndSiteId(int ProjectId, int SiteId)
        {
            if (ProjectId == 0 && SiteId==0)
            {
                throw new NotExistException("Not Exist Exception");
            }
            else
            {
                return _context.ProjectSites.Where(ps=>ps.ProjectId==ProjectId && ps.SiteId==SiteId).FirstOrDefault();

            }
        }

        public async Task<IEnumerable<ProjectSites>> Update(int ProjectId, List<Sites> LstSites)
        {

            if (ProjectId == 0)
            {
                throw new NotExistException("Not Exist Exception");
            }
            List<ProjectSites> lstProjectSites = new List<ProjectSites>();
            try
            {
                if (LstSites != null)
                {
                    List<int> modelSitesIds = LstSites.OrderBy(a => a.Id).Select(a => a.Id).ToList();

                    List<int> savedSitesIds = _context.ProjectSites
                        .Where(a => a.ProjectId == ProjectId).OrderBy(a => a.SiteId).Select(a => a.SiteId).ToList();

                    List<int> deletedSitesIds = savedSitesIds.Except(modelSitesIds).ToList();
                    if (deletedSitesIds.Count > 0)
                    {
                        foreach (var siteId in deletedSitesIds)
                        {
                            lstProjectSites = _context.ProjectSites.Where(a => a.SiteId == siteId && a.ProjectId == ProjectId).ToList();
                            if (lstProjectSites.Count > 0)
                            {
                                ProjectSites projectSites  = lstProjectSites[0];
                                if (projectSites != null)
                                {
                                    _context.Entry(projectSites).State = EntityState.Deleted;

                                    _context.SaveChanges();
                                }
                            }
                        }
                    }

                    List<int> savedSitessId2 = await _context.ProjectSites.Where(a => a.ProjectId == ProjectId)
                                                      .OrderBy(a => a.SiteId).Select(a => a.SiteId).ToListAsync();

                    var added = modelSitesIds.Except(savedSitessId2).ToList();
                    if (added.Count > 0)
                    {
                        foreach (var item in added)
                        {
                            ProjectSites projectSites = new ProjectSites();
                            projectSites.ProjectId = ProjectId;
                            projectSites.SiteId = item;
                            _context.ProjectSites.Add(projectSites);
                            lstProjectSites.Add(projectSites);
                            _context.SaveChanges();
                        }
                    }
                    else
                    {
                        foreach (var item in LstSites)
                        {

                            lstProjectSites = _context.ProjectSites.Where(a => a.ProjectId == ProjectId && a.SiteId == item.Id).ToList();
                            if (lstProjectSites.Count == 0)
                            {
                                ProjectSites projectSites = new ProjectSites();
                                projectSites.ProjectId = ProjectId;
                                projectSites.SiteId = item.Id;
                                _context.ProjectSites.Add(projectSites);
                                lstProjectSites.Add(projectSites);
                                _context.SaveChanges();
                            }
                        }
                    }
                }
                else
                {
                    throw new NotCompletedException("Not Completed Exception");
                }
            }
            catch (Exception)
            {
                throw new NotCompletedException("Not Completed Exception");
            }
            return lstProjectSites;

        }
    }
}
