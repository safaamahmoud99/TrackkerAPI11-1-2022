using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tracker.Data.Models
{
    public class Organization
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string OrganizationName { get; set; }
        public string OrganizationCode { get; set; }
        //public string Mobile { get; set; }
        //public string Phone { get; set; }
        public string Address { get; set; }
        //public string ResponsiblePerson { get; set; }
        public string Location { get; set; }
        public float? lat { get; set; }
        public float? lng { get; set; }
        public bool? IsDeleted { get; set; }

    }
}
