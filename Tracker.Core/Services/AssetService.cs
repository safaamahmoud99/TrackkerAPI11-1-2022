using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data.DTO;
using Tracker.Data.Models;
using Tracker.Domain;
using Tracker.Domain.IServices;

namespace Tracker.Core.Services
{
    public class AssetService : IAssetService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AssetService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void AddAsset(AssetDTO assetDTO)
        {
            _unitOfWork.Asset.Add(assetDTO);
        }

        public void DeleteAsset(int id)
        {
            _unitOfWork.Asset.Delete(id);
        }

        public IEnumerable<AssetDTO> GetAllAssets()
        {
            return _unitOfWork.Asset.GetAll();
        }

        public AssetDTO GetAssetById(int id)
        {
            return _unitOfWork.Asset.GetById(id);
        }

        public void UpdateAsset(int Id, AssetDTO assetDTO)
        {
            _unitOfWork.Asset.Update(Id,assetDTO);
        }
    }
}
