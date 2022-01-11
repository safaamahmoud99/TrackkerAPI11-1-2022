using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Tracker.Data.ViewModels
{
    public class EmployeeViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int ProfessionID { get; set; }
        public string gender { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string MaritalStatus { get; set; }
        public string Phone { get; set; }
        public string RelevantPhone { get; set; }
        public string Email { get; set; }
        public DateTime HiringDateHiringDate { get; set; }


        public IFormFile Photo;
    }
}
