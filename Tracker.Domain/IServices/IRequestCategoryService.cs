using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data.DTO;
using Tracker.Data.Models;

namespace Tracker.Domain.IServices
{
    public interface IRequestCategoryService
    {
        IEnumerable<RequestCategoryDTO> GetAllRequestCategory();
        RequestCategoryDTO GetRequestCategoryById(int id);
        void AddRequestCategory(RequestCategoryDTO requestCategoryDTO);
        void UpdateRequestCategory(int id,RequestCategoryDTO requestCategoryDTO);
        void DeleteRequestCategory(int id);
    }
}
