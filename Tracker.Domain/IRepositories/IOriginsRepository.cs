using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data.Models;

namespace Tracker.Domain.IRepositories
{
    public interface IOriginsRepository
    {
        IEnumerable<Origin> GetAll();
        Origin GetById(int id);
        void Add(Origin origin);
        void Update(int Id, Origin origin);
        void Delete(int id);
    }
}
