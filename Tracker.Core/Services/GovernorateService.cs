using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Domain;
using Tracker.Data.Models;
using Tracker.Domain.IServices;
using Tracker.Data.DTO;

namespace Tracker.Core.Services
{
   public class GovernorateService: IGovernorateService
    {
        private readonly IUnitOfWork _unitOfWork;

        public GovernorateService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddGovernorate(GovernorateDto governorate)
        {
            _unitOfWork.Governorate.Add(governorate); 
        }

        public void DeleteGovernorate(int governorateId)
        {
            _unitOfWork.Governorate.Delete(governorateId);
        }

        public IEnumerable<GovernorateDto> GetAllGovernorates()
        {
            return _unitOfWork.Governorate.GetAll();
        }

        public GovernorateDto GetGovernorate(int id)
        {
          return  _unitOfWork.Governorate.Get(id);
        }

        public void UpdateGovernorate(int id, GovernorateDto governorate)
        {
            _unitOfWork.Governorate.Update(id, governorate);
        }
    }
}
