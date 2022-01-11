using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracker.Data.Models;

namespace Tracker.Domain.IRepositories
{
   public interface IRequestTypeRepository
    {
        IEnumerable<Problems> GetAll();
        Problems GetById(int id);
        Problems Find(int id);
        void Add(Problems requestType);
        void Update(int id,Problems requestType);
        void Delete(int id);
        void Save();
    }
}
