using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data.DTO;
using Tracker.Data.Models;

namespace Tracker.Domain.IServices
{
    public interface IRequestSubCategoryService
    {
        IEnumerable<RequestSubCategoryDTO> GetAllRequestSubCategory();
        RequestSubCategoryDTO GetRequestSubCategoryById(int id);
        void AddRequestSubCategory(RequestSubCategoryDTO requestSubCategoryDTO);
        void UpdateRequestSubCategory(int id,RequestSubCategoryDTO requestSubCategoryDTO);
        void DeleteRequestSubCategory(int id);
    }
}
