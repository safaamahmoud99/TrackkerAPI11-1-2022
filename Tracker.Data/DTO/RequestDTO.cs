using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tracker.Data.DTO
{
    public class RequestDTO
    {
        public int Id { get; set; }
        public string RequestName { get; set; }
        public string RequestCode { get; set; }
        public string Description { get; set; }
        public DateTime RequestDate { get; set; }
        public string RequestTime { get; set; }
        public bool? IsSolved { get; set; }
        public bool? IsAssigned { get; set; }
        public int RequestSubCategoryId { get; set; }
        public string RequestSubCategoryName { get; set; }
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public int ProjectTeamId { get; set; }
        public string ProjectName { get; set; }
        public string TeamName { get; set; }
        public int RequestModeId { get; set; }
        public string RequestMode { get; set; }
        public int AssetId { get; set; }
        public string AssetName { get; set; }
        public string SerialNumber { get; set; }
        public string Sitename { get; set; }
        public int ProjectSiteAssetId{ get; set; }
        public int RequestStatusId { get; set; }
        public string RequestStatus { get; set; }
        public int RequestPeriorityId { get; set; }
        public string RequestPeriority { get; set; }
        public string CreatedById { get; set; }
        public string CreatedBy { get; set; }
    }
}
