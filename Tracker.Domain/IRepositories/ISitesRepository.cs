using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data.Models;

namespace Tracker.Domain.IRepositories
{
    public interface ISitesRepository
    {
        Sites Get(int id);
        IEnumerable<Sites> GetAll();
        void Add(Sites Site);
        void Delete(int SiteId);
        void Update(int SiteId, Sites Site);
    }
}
