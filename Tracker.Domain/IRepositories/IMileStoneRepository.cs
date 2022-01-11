using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracker.Data.DTO;
using Tracker.Data.Models;

namespace Tracker.Domain.IRepositories
{
  public interface IMileStoneRepository 
    {
        IEnumerable<MileStoneDTO> GetAll();
        MileStoneDTO GetById(int id);
        IEnumerable<MileStoneDTO> GetMileStonesByProjectId(int ProjectId);
        void UpdateByProjectId(int ProjectId, List<MileStoneDTO> mileStoneDTOs);
        MileStone Find(int id);
        void Add(List<MileStoneDTO> mileStone);
        void Update(int id,MileStoneDTO mileStone);
        void Delete(int id);
        void Save();
    }
}
