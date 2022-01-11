using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tracker.Data.Models
{
    public class RequestStatus
    {
        enum Status
        {
            Closed,
            Solved,
            Pending
        }
      
        public int Id { get; set; }
        public string status { get; set; }
       
    }
}
