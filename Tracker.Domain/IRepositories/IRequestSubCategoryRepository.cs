using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracker.Data.DTO;
using Tracker.Data.Models;

namespace Tracker.Domain.IRepositories
{
   public interface IRequestSubCategoryRepository 
    {
        IEnumerable<RequestSubCategoryDTO> GetAll();
        RequestSubCategoryDTO GetById(int id);
        RequestSubCategory Find(int id);
        void Add(RequestSubCategoryDTO requestSubCategoryDTO);
        void Update(int id,RequestSubCategoryDTO requestSubCategoryDTO);
        void Delete(int id);
        void Save();
    }
}
