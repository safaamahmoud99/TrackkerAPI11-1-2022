using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tracker.Data.Models
{
    public class ProjectSiteAsset
    {
        public int Id { get; set; }
        public int WarrantyPeriod { get; set; }
        public DateTime WarrantyStartDate { get; set; }
        public string SerialNumber { get; set; }
        public int SupplierId { get; set; }
        [ForeignKey("SupplierId")]
        public virtual Supplier Supplier { get; set; }
        public int Days { get; set; }
        public int AssetId { get; set; }
        [ForeignKey("AssetId")]
        public virtual Asset Asset { get; set; }
        public int ProjectSiteId { get; set; }
        [ForeignKey("ProjectSiteId")]
        public virtual ProjectSites ProjectSites { get; set; }

    }
}
