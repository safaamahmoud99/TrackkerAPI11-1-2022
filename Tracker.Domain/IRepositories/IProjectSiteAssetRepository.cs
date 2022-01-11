using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data.DTO;

namespace Tracker.Domain.IRepositories
{
    public interface IProjectSiteAssetRepository
    {
        IEnumerable<ProjectSiteAssetDTO> GetAll();
        IEnumerable<ProjectSiteAssetDTO> GetAllProjectSiteAssetBySiteId(int SiteId, int ProjectId);
        IEnumerable<ProjectSiteAssetDTO> GetAllProjectSiteAssetByProjectId(int ProjectId);
        IEnumerable<ProjectSiteAssetDTO> GetAllAssetsSerialsByAssetId(int AssetId);
        ProjectSiteAssetDTO GetProjectSiteAssetBySerialNumber(string SerialNumber);
        ProjectSiteAssetDTO GetById(int id);
        void Add(ProjectSiteAssetDTO ProjectSiteAssetDTO);
        void Update(int Id, ProjectSiteAssetDTO ProjectSiteAssetDTO);
        void Delete(int id);
    }
}
