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
    public class RequestTypeService : IRequestTypeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RequestTypeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddRequestType(Problems requestType)
        {
            _unitOfWork.RequestType.Add(requestType);
        }

        public void DeleteRequestType(int id)
        {
            _unitOfWork.RequestType.Delete(id);
        }

        public IEnumerable<Problems> GetAllRequestType()
        {
            return _unitOfWork.RequestType.GetAll();
        }

        public Problems GetRequestTypeById(int id)
        {
            return _unitOfWork.RequestType.GetById(id);
        }

        public void UpdateRequestType(int id, Problems requestType)
        {
            _unitOfWork.RequestType.Update(id, requestType);
        }
    }
}
