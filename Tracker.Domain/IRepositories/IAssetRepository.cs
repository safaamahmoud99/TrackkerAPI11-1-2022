using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracker.Data.DTO;
using Tracker.Data.Models;

namespace Tracker.Domain.IRepositories
{
   public interface IAssetRepository
    {
        IEnumerable<AssetDTO> GetAll();
        AssetDTO GetById(int id);
        AssetDTO Find(int id);
        void Add(AssetDTO AssetDTO);
        void Update(int id,AssetDTO AssetDTO);
        void Delete(int id);
        void Save();
    }
}
