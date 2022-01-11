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
    public class MileStoneService : IMileStoneService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MileStoneService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void AddMileStone(List<MileStoneDTO> mileStone)
        {
            _unitOfWork.MileStone.Add(mileStone);
        }

        public void DeleteMileStone(int id)
        {
            _unitOfWork.MileStone.Delete(id);
        }

        public IEnumerable<MileStoneDTO> GetAllMileStones()
        {
            return _unitOfWork.MileStone.GetAll();
        }

        public MileStoneDTO GetMileStoneById(int id)
        {
            return _unitOfWork.MileStone.GetById(id);
        }

        public IEnumerable<MileStoneDTO> GetMileStonesByProjectId(int ProjectId)
        {
            return _unitOfWork.MileStone.GetMileStonesByProjectId(ProjectId);
        }

        public void UpdateByProjectId(int ProjectId, List<MileStoneDTO> mileStoneDTOs)
        {
            _unitOfWork.MileStone.UpdateByProjectId(ProjectId, mileStoneDTOs);
        }

        public void UpdateMileStone(int id, MileStoneDTO mileStone)
        {
            _unitOfWork.MileStone.Update(id,mileStone);
        }
    }
}
