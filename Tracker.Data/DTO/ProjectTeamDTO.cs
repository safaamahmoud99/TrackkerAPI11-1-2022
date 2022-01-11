using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tracker.Data.DTO
{
    public class ProjectTeamDTO
    {
        public int ID { get; set; }
      //  
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int ProjectId { get; set; }
        public int TeamId { get; set; }
        public string teamName { get; set; }
        public string  ProjectName { get; set; }
        public int DepartmentId { get; set; }
        public string  DepartmentName { get; set; }
        public int ProjectPositionId { get; set; }
        public string ProjectPositionName { get; set; }
    }
}
