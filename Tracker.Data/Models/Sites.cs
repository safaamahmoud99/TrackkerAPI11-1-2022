using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tracker.Data.Models
{
    public class Sites
    {
       public int Id { get; set; }
        public string Sitename { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int GovernorateId { get; set; }

        [ForeignKey("GovernorateId")]
        public virtual Governorate Governorate { get; set; }
        public int CityId { get; set; }

        [ForeignKey("CityId")]
        public virtual City City { get; set; }
    }
}
