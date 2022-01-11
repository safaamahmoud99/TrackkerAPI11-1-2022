using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tracker.Data.Models
{
    public class Request
    {

        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string RequestName { get; set; }
        public string RequestCode { get; set; }
        public string Description { get; set; }
        public DateTime RequestDate { get; set; }
        public TimeSpan? RequestTime { get; set; }
        public bool? IsAssigned { get; set; }
        public bool? IsSolved { get; set; }
        //public int AssetId { get; set; }
        //[ForeignKey("AssetId")]
        //public virtual Asset Asset { get; set; }
        public int RequestModeId { get; set; }
        [ForeignKey("RequestModeId")]
        public virtual RequestMode RequestMode { get; set; }
        public int RequestSubCategoryId { get; set; }
        [ForeignKey("RequestSubCategoryId")]
        public virtual RequestSubCategory RequestSubCategory { get; set; }
        //public int ProjectId { get; set; }
        //[ForeignKey("ProjectId")]
        //public virtual Project Project { get; set; }
        public int ProjectSiteAssetId { get; set; }
        [ForeignKey("ProjectSiteAssetId")]
        public virtual ProjectSiteAsset ProjectSiteAsset { get; set; }
        public int ClientId { get; set; }
        [ForeignKey("ClientId")]
        public virtual Client Client { get; set; }
        public string CreatedById { get; set; }
        [ForeignKey("CreatedById")]
        public virtual ApplicationUser User { get; set; }
        public int RequestStatusId { get; set; }
        [ForeignKey("RequestStatusId")]
        public virtual RequestStatus RequestStatus { get; set; }
        public int RequestPeriorityId { get; set; }
        [ForeignKey("RequestPeriorityId")]
        public virtual RequestPeriority RequestPeriority { get; set; }
        public int ProjectTeamId { get; set; }
        [ForeignKey("ProjectTeamId")]
        public virtual ProjectTeam ProjectTeam { get; set; }


    }
}
