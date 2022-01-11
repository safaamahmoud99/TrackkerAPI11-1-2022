using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tracker.Data.DTO
{
    public class AssignedRequestsDTO
    {
        public int Id { get; set; }
        public int ProjectPositionId { get; set; }
        public string ProjectPositionName { get; set; }
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int RequestId { get; set; }
        public string RequestName  { get; set; }
        //public int ProjectId { get; set; }
        public string ProjectName { get; set; }
    }
}
