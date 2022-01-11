using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data.Models;

namespace Tracker.Data.DTO
{
    public class SiteClientsDTO
    {
        public int Id { get; set; }
        public int SiteId { get; set; }
        public string SiteName { get; set; }
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public int ProjectSiteId { get; set; }
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public List<Client> Clients { get; set; }
    }
}
