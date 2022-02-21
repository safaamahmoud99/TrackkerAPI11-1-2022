using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracker.Data.Models
{
  public class City
    {
        public int Id { get; set; }
        public string cityName { get; set; }
        public int GovernorateId { get; set; }

        [ForeignKey("GovernorateId")]
        public virtual Governorate  Governorate { get; set; }
    }
}
