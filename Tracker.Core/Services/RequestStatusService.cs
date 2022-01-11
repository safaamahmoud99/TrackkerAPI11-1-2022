using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data.Models;
using Tracker.Domain;
using Tracker.Domain.IServices;

namespace Tracker.Core.Services
{
    public class RequestStatusService : IRequestStatusService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RequestStatusService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddRequestStatus(RequestStatus requestStatus)
        {
            _unitOfWork.RequestStatus.Add(requestStatus);
        }

        public void DeleteRequestStatus(int id)
        {
            _unitOfWork.RequestStatus.Delete(id);
        }

        public IEnumerable<RequestStatus> GetAllRequestStatus()
        {
            return _unitOfWork.RequestStatus.GetAll();
        }

        public RequestStatus GetRequestStatusById(int id)
        {
           return _unitOfWork.RequestStatus.GetById(id);
        }

        public void UpdateRequestStatus(int id, RequestStatus requestStatus)
        {
            _unitOfWork.RequestStatus.Update(id,requestStatus);
        }
    }
}
