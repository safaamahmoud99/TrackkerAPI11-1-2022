using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tracker.Data.DTO
{
    public class ProjectDTO
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public string ProjectCode { get; set; }
        public int? ProjectTypeId { get; set; }
        public string ProjectTypeName { get; set; }
        public decimal Cost { get; set; }
        public int ProjectPeriod { get; set; }
        public bool? IsDeleted { get; set; }

        public DateTime? PlanndedStartDate { get; set; }
        public DateTime? ActualStartDate { get; set; }
        public DateTime? PlanndedEndDate { get; set; }
        public DateTime? ActualEndDate { get; set; }
        public string Description { get; set; }
        public int OrganizationId { get; set; }
        public string OrganizationName { get; set; }
        public int EmployeeId { get; set; }
        public string  EmployeeName { get; set; }
        public int ClientId { get; set; }
        public string  ClientName { get; set; }
        public string ClientCode { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string ClientMobile { get; set; }
        public List<StackeholdersDTO> stackeholdersDTOs { get; set; }
    }
}
