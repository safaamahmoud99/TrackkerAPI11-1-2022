using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracker.Data.DTO;
using Tracker.Data.Models;

namespace Tracker.Domain.IRepositories
{
   public interface IRequestCategoryRepository
    {
        IEnumerable<RequestCategoryDTO> GetAll();
        RequestCategoryDTO GetById(int id);
        RequestCategory Find(int id);
        void Add(RequestCategoryDTO requestCategoryDTO);
        void Update(int id,RequestCategoryDTO requestCategoryDTO);
        void Delete(int id);
        void Save();
    }
}
