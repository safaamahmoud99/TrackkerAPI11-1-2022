using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data.Models;
using Tracker.Data.DTO;

namespace Tracker.Domain.IRepositories
{
    public interface ISitesRepository
    {
        siteDto Get(int id);
        IEnumerable<siteDto> GetAll();
        void Add(siteDto Site);
        void Delete(int SiteId);
        void Update(int SiteId, siteDto Site);
    }
}
