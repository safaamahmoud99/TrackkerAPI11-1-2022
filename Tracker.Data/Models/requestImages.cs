using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tracker.Data.Models
{
    public class requestImages
    {
        public int Id { get; set; }
        public string imageName { get; set; }
        public int requestId { get; set; }
        [ForeignKey("requestId")]
        public virtual Request Request { get; set; }
    }
}
