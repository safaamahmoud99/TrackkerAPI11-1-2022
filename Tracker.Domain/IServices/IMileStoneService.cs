using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data.DTO;
using Tracker.Data.Models;

namespace Tracker.Domain.IServices
{
    public interface IMileStoneService
    {
        IEnumerable<MileStoneDTO> GetAllMileStones();
        MileStoneDTO GetMileStoneById(int id);
        IEnumerable<MileStoneDTO> GetMileStonesByProjectId(int ProjectId);
        void UpdateByProjectId(int ProjectId, List<MileStoneDTO> mileStoneDTOs);
        void AddMileStone(List<MileStoneDTO> mileStone);
        void UpdateMileStone(int id,MileStoneDTO mileStone);
        void DeleteMileStone(int id);
    }
}
