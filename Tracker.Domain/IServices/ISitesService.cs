using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data.DTO;
using Tracker.Data.Models;

namespace Tracker.Domain.IServices
{
    public interface ISitesService
    {
        siteDto GetSite(int id);
        IEnumerable<siteDto> GetAllSites();
        void AddSite(siteDto Site);
        void DeleteSite(int SiteId);
        void UpdateSite(int SiteId, siteDto Site);
    }
}
