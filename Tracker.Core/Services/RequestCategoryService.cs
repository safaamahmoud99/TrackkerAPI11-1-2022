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
    public class RequestCategoryService : IRequestCategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RequestCategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void AddRequestCategory(RequestCategoryDTO requestCategoryDTO)
        {
            _unitOfWork.RequestCategory.Add(requestCategoryDTO);
        }

        public void DeleteRequestCategory(int id)
        {
            _unitOfWork.RequestCategory.Delete(id);
        }

        public IEnumerable<RequestCategoryDTO> GetAllRequestCategory()
        {
            return _unitOfWork.RequestCategory.GetAll();
        }

        public RequestCategoryDTO GetRequestCategoryById(int id)
        {
           return _unitOfWork.RequestCategory.GetById(id);
        }

        public void UpdateRequestCategory(int id, RequestCategoryDTO requestCategoryDTO)
        {
            _unitOfWork.RequestCategory.Update(id, requestCategoryDTO);
        }
    }
}
