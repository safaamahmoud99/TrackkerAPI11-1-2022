using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data.Models;

namespace Tracker.Domain.IServices
{
    public interface ISitesService
    {
        Sites GetSite(int id);
        IEnumerable<Sites> GetAllSites();
        void AddSite(Sites Site);
        void DeleteSite(int SiteId);
        void UpdateSite(int SiteId, Sites Site);
    }
}
