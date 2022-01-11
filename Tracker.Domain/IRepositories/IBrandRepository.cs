using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracker.Data.Models;

namespace Tracker.Domain.IRepositories
{
    public interface IBrandRepository
    {
        IEnumerable<Brand> GetAll();
        Brand GetById(int id);
        void Add(Brand Brand);
        void Update(int Id, Brand Brand);
        void Delete(int id);
    }
}
