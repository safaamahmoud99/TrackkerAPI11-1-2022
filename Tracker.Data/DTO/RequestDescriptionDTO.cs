using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tracker.Data.DTO
{
    public class RequestDescriptionDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime DescriptionDate { get; set; }
        public int RequestId { get; set; }
        public string RequestName { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
    }
}
