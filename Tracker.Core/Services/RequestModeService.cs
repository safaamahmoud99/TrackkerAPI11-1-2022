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
    public class RequestModeService : IRequestModeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RequestModeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void AddRequestMode(RequestMode RequestMode)
        {
            _unitOfWork.RequestMode.Add(RequestMode);
        }

        public void DeleteRequestMode(int id)
        {
            _unitOfWork.RequestMode.Delete(id);
        }

        public RequestMode FindRequestMode(int id)
        {
            return _unitOfWork.RequestMode.Find(id);
        }

        public IEnumerable<RequestMode> GetAllRequestMode()
        {
           return _unitOfWork.RequestMode.GetAll();
        }

        public RequestMode GetRequestModeById(int id)
        {
            return _unitOfWork.RequestMode.GetById(id);
        }

        public void UpdateRequestMode(int id, RequestMode RequestMode)
        {
            _unitOfWork.RequestMode.Update(id,RequestMode);
        }
    }
}
