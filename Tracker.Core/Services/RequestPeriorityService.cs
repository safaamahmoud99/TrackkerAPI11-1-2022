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
    public class RequestPeriorityService : IRequestPeriorityService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RequestPeriorityService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void AddRequestPeriority(RequestPeriority requestPeriority)
        {
            _unitOfWork.RequestPeriority.Add(requestPeriority);
        }

        public void DeleteRequestPeriority(int id)
        {
            _unitOfWork.RequestPeriority.Delete(id);
        }

        public IEnumerable<RequestPeriority> GetAllRequestPeriority()
        {
            return _unitOfWork.RequestPeriority.GetAll();
        }

        public RequestPeriority GetRequestPeriorityById(int id)
        {
            return _unitOfWork.RequestPeriority.GetById(id);
        }

        public void UpdateRequestPeriority(int id, RequestPeriority requestPeriority)
        {
            _unitOfWork.RequestPeriority.Update(id,requestPeriority);
        }
    }
}
