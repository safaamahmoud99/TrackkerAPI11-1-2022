using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracker.Data.Models;

namespace Tracker.Domain.IRepositories
{
   public interface IRequestStatusRepository 
    {
        IEnumerable<RequestStatus> GetAll();
        RequestStatus GetById(int id);
        RequestStatus Find(int id);
        void Add(RequestStatus requestStatus);
        void Update(int id,RequestStatus requestStatus);
        void Delete(int id);
        void Save();
    }
}
