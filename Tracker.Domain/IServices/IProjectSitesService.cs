using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data.DTO;
using Tracker.Data.Models;

namespace Tracker.Domain.IServices
{
    public interface IProjectSitesService
    {
        IEnumerable<ProjectSitesDTO> GetAllProjectSitesDTOs();
        IEnumerable<Sites> GetAllSitesByProjectId(int ProjectId);
        ProjectSites GetProjectSiteByProjectIdAndSiteId(int ProjectId, int SiteId);
        ProjectSitesDTO GetProjectSitesDTOById(int id);
        void AddProjectSitesDTO(ProjectSitesDTO ProjectSitesDTO);
        Task<IEnumerable<ProjectSites>> Update(int ProjectId, List<Sites> LstSites);
        void DeleteProjectSitesDTO(int id);
    }
}
