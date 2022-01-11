using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracker.Data.Models;

namespace Tracker.Domain.IRepositories
{
   public interface IRequestModeRepository
    {
        IEnumerable<RequestMode> GetAll();
        RequestMode GetById(int id);
        RequestMode Find(int id);
        void Add(RequestMode RequestMode);
        void Update(int id,RequestMode RequestMode);
        void Delete(int id);
        void Save();
    }
}
