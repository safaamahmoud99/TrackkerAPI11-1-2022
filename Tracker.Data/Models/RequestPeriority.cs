using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tracker.Data.Models
{
    enum Periorty
    {
        High,
        Med,
        Low,
        Normal
    }
    public class RequestPeriority
    {
        public int Id { get; set; }
        public string periorty { get; set; }
       
    }
}
