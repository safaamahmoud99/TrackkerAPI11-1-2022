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
    public class ProjectSiteAssetService : IProjectSiteAssetService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProjectSiteAssetService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void AddProjectSiteAssetDTO(ProjectSiteAssetDTO ProjectSiteAssetDTO)
        {
            _unitOfWork.ProjectSiteAsset.Add(ProjectSiteAssetDTO);
        }

        public void DeleteProjectSiteAssetDTO(int id)
        {
            _unitOfWork.ProjectSiteAsset.Delete(id);
        }

        public IEnumerable<ProjectSiteAssetDTO> GetAllAssetsSerialsByAssetId(int AssetId)
        {
            return _unitOfWork.ProjectSiteAsset.GetAllAssetsSerialsByAssetId(AssetId);
        }

        public IEnumerable<ProjectSiteAssetDTO> GetAllProjectSiteAssetByProjectId(int ProjectId)
        {
            return _unitOfWork.ProjectSiteAsset.GetAllProjectSiteAssetByProjectId(ProjectId);
        }

        public IEnumerable<ProjectSiteAssetDTO> GetAllProjectSiteAssetBySiteId(int SiteId, int ProjectId)
        {
           return _unitOfWork.ProjectSiteAsset.GetAllProjectSiteAssetBySiteId(SiteId,ProjectId);
        }

        public IEnumerable<ProjectSiteAssetDTO> GetAllProjectSiteAssetDTOs()
        {
            throw new NotImplementedException();
        }

        public ProjectSiteAssetDTO GetProjectSiteAssetBySerialNumber(string SerialNumber)
        {
            return _unitOfWork.ProjectSiteAsset.GetProjectSiteAssetBySerialNumber(SerialNumber);
        }

        public ProjectSiteAssetDTO GetProjectSiteAssetDTOById(int id)
        {
            return _unitOfWork.ProjectSiteAsset.GetById(id);
        }

        public void UpdateProjectSiteAssetDTO(int Id, ProjectSiteAssetDTO ProjectSiteAssetDTO)
        {
            _unitOfWork.ProjectSiteAsset.Update(Id, ProjectSiteAssetDTO);
        }
    }
}
