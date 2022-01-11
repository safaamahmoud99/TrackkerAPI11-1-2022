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
    public class RequestDescriptionService : IRequestDescriptionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RequestDescriptionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void AddRequestDescription(RequestDescriptionDTO requestDescriptionDTO)
        {
            _unitOfWork.RequestDescription.Add(requestDescriptionDTO);
        }

        public void DeleteRequestDescription(int id)
        {
            _unitOfWork.RequestDescription.Delete(id);
        }

        public IEnumerable<RequestDescriptionDTO> GetAllDescriptionsByRequestId(int RequestId)
        {
            return _unitOfWork.RequestDescription.GetAllDescriptionsByRequestId(RequestId);
        }

        public IEnumerable<RequestDescriptionDTO> GetAllRequestDescription()
        {
            return _unitOfWork.RequestDescription.GetAll();
        }

        public RequestDescriptionDTO GetRequestDescriptionById(int id)
        {
            return _unitOfWork.RequestDescription.GetById(id);
        }

        public void UpdateRequestDescription(int id, RequestDescriptionDTO requestDescriptionDTO)
        {
            _unitOfWork.RequestDescription.Update(id,requestDescriptionDTO);
        }
    }
}
