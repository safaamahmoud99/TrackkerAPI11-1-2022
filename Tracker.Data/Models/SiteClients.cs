using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tracker.Data.Models
{
    public class SiteClients
    {
        public int Id { get; set; }
        public int ProjectSiteId { get; set; }
        [ForeignKey("ProjectSiteId")]
        public virtual ProjectSites ProjectSites { get; set; }
        public int ClientId { get; set; }
        [ForeignKey("ClientId")]
        public virtual Client Client { get; set; }
    }
}
