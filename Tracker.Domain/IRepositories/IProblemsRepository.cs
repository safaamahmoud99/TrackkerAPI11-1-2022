using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracker.Data.Models;

namespace Tracker.Domain.IRepositories
{
   public interface IProblemsRepository 
    {
        IEnumerable<Problems> GetAll();
        Problems GetById(int id);
        Problems Find(int id);
        void Add(Problems problems);
        void Update(int id,Problems problems);
        void Delete(int id);
        void Save();
    }
}
