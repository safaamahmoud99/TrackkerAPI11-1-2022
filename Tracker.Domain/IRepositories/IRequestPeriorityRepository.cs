using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracker.Data.Models;

namespace Tracker.Domain.IRepositories
{
  public  interface IRequestPeriorityRepository 
    {
        IEnumerable<RequestPeriority> GetAll();
        RequestPeriority GetById(int id);
        RequestPeriority Find(int id);
        void Add(RequestPeriority requestPeriority);
        void Update(int id,RequestPeriority requestPeriority);
        void Delete(int id);
        void Save();
    }
}
