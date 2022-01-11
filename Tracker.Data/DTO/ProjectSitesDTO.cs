using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data.Models;

namespace Tracker.Data.DTO
{
    public class ProjectSitesDTO
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public int SiteId { get; set; }
        public string SiteName { get; set; }
        public List<Sites> LstSites { get; set; }
    }
}
