using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tracker.Data.Models
{
    public class RequestSubCategory
    {
        //cablecut problems of each department
        public int Id { get; set; }
        public string SubCategoryName { get; set; }
        public int RequestCategoryId { get; set; }
        [ForeignKey("RequestCategoryId")]
        public virtual RequestCategory RequestCategory { get; set; }
    }
}
