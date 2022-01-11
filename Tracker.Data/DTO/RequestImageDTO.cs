using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tracker.Data.DTO
{
    public class RequestImageDTO
    {
        public int Id { get; set; }
        public string imageName { get; set; }
        public int requestId { get; set; }
    }
}
