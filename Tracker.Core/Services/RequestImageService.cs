using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data.DTO;
using Tracker.Data.Models;
using Tracker.Domain;
using Tracker.Domain.IServices;

namespace Tracker.Core.Services
{
    public class RequestImageService : IRequestImageService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RequestImageService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void AddRequestImage(List<RequestImageDTO> request)
        {
            _unitOfWork.RequestImage.Add(request);
        }

        public IEnumerable<requestImages> GetAllRequestImage()
        {
            return _unitOfWork.RequestImage.GetAll();
        }

        public requestImages GetRequestImageById(int id)
        {
            return _unitOfWork.RequestImage.GetById(id);
        }

        public IEnumerable<RequestImageDTO> GetRequestImageByRequestId(int requestID)
        {
            return _unitOfWork.RequestImage.GetRequestImageByRequestId(requestID);
        }
    }
}
