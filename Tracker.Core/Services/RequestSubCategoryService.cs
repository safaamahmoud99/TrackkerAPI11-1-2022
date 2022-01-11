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
    public class RequestSubCategoryService : IRequestSubCategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RequestSubCategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void AddRequestSubCategory(RequestSubCategoryDTO requestSubCategoryDTO)
        {
            _unitOfWork.SubCategory.Add(requestSubCategoryDTO);
        }

        public void DeleteRequestSubCategory(int id)
        {
            _unitOfWork.SubCategory.Delete(id);
        }

        public IEnumerable<RequestSubCategoryDTO> GetAllRequestSubCategory()
        {
            return _unitOfWork.SubCategory.GetAll();
        }

        public RequestSubCategoryDTO GetRequestSubCategoryById(int id)
        {
            return _unitOfWork.SubCategory.GetById(id);
        }

        public void UpdateRequestSubCategory(int id, RequestSubCategoryDTO requestSubCategoryDTO)
        {
            _unitOfWork.SubCategory.Update(id,requestSubCategoryDTO);
        }
    }
}
