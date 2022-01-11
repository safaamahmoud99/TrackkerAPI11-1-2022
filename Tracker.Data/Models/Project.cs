using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tracker.Data.Models
{
    public class Project
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public string ProjectCode { get; set; }
        public decimal Cost { get; set; }
        public int ProjectPeriod { get; set; }
        public DateTime? PlanndedStartDate { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? ActualStartDate { get; set; }
        public DateTime? PlanndedEndDate { get; set; }
        public DateTime? ActualEndDate { get; set; }
        public string Description { get; set; }
        public int? ProjectTypeId { get; set; }
        [ForeignKey("ProjectTypeId")]
        public virtual ProjectType ProjectType { get; set; }
        public int OrganizationId { get; set; }
        [ForeignKey("OrganizationId")]
        public virtual Organization Organization { get; set; }
        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }
        //public int ClientId { get; set; }
        //[ForeignKey("ClientId")]
        //public virtual Client Client { get; set; }
        // try git in vs
    }
}
