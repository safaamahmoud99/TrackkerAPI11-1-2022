using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracker.Data.DTO
{
  public class siteDto
    {
        public int Id { get; set; }
        public string Sitename { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int GovernorateId { get; set; }
        public string GovernorateName { get; set; }
        public int CityId { get; set; }
        public string CityName {set; get;}

    }
}
