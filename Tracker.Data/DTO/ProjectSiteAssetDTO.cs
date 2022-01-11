using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data.Models;

namespace Tracker.Data.DTO
{
    public class ProjectSiteAssetDTO
    {
        public int Id { get; set; }
        public int WarrantyPeriod { get; set; }
        public DateTime WarrantyStartDate { get; set; }
        public string SerialNumber { get; set; }
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public int Days { get; set; }
        public int AssetId { get; set; }
        public string AssetName { get; set; }
        public int ProjectSiteId { get; set; }
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public int SiteId { get; set; }
        public string Sitename { get; set; }
        public List<Client> clients { get; set; }
    }
}
