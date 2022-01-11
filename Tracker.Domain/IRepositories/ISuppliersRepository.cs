using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data.Models;

namespace Tracker.Domain.IRepositories
{
    public interface ISuppliersRepository
    {
        IEnumerable<Supplier> GetAll();
        Supplier GetById(int id);
        void Add(Supplier supplier);
        void Update(int id, Supplier supplier);
        void Delete(int id);
    }
}
