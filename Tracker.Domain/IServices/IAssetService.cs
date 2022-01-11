using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data.DTO;
using Tracker.Data.Models;

namespace Tracker.Domain.IServices
{
    public interface IAssetService
    {
        IEnumerable<AssetDTO> GetAllAssets();
        AssetDTO GetAssetById(int id);
        void AddAsset(AssetDTO assetDTO);
        void UpdateAsset(int Id, AssetDTO assetDTO);
        void DeleteAsset(int id);
    }
}
