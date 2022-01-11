using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tracker.Data.DTO
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeCode { get; set; }
        public string Position { get; set; }
        public string DepartmentName { get; set; }
        public int DepartmentId { get; set; }
        public string gender { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string MaritalStatus { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; }
        public DateTime HiringDateHiringDate { get; set; }
    }
}
