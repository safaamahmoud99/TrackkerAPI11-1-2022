using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tracker.Data.DTO
{
    public class RequestSubCategoryDTO
    {
        public int Id { get; set; }
        public string SubCategoryName { get; set; }
        public int RequestCategoryId { get; set; }
        public string RequestCategoryName { get; set; }
    }
}
