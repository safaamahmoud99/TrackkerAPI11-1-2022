using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data.DTO;
using Tracker.Data.Models;

namespace Tracker.Domain.IRepositories
{
    public interface IProjectSitesRepository
    {
        IEnumerable<ProjectSitesDTO> GetAll();
        IEnumerable<Sites> GetAllSitesByProjectId(int ProjectId);
        ProjectSites GetProjectSiteByProjectIdAndSiteId(int ProjectId,int SiteId);
        ProjectSitesDTO GetById(int id);
        void Add(ProjectSitesDTO ProjectSitesDTO);
        Task<IEnumerable<ProjectSites>> Update(int ProjectId, List<Sites> LstSites);
        void Delete(int id);
    }
}
