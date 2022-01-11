using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data.DTO;

namespace Tracker.Domain.IServices
{
    public interface IProjectSiteAssetService
    {
        IEnumerable<ProjectSiteAssetDTO> GetAllProjectSiteAssetDTOs();
        IEnumerable<ProjectSiteAssetDTO> GetAllProjectSiteAssetBySiteId(int SiteId, int ProjectId);
        IEnumerable<ProjectSiteAssetDTO> GetAllProjectSiteAssetByProjectId(int ProjectId);
        IEnumerable<ProjectSiteAssetDTO> GetAllAssetsSerialsByAssetId(int AssetId);
        ProjectSiteAssetDTO GetProjectSiteAssetBySerialNumber(string SerialNumber);
        ProjectSiteAssetDTO GetProjectSiteAssetDTOById(int id);
        void AddProjectSiteAssetDTO(ProjectSiteAssetDTO ProjectSiteAssetDTO);
        void UpdateProjectSiteAssetDTO(int Id, ProjectSiteAssetDTO ProjectSiteAssetDTO);
        void DeleteProjectSiteAssetDTO(int id);
    }
}
