using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tracker.Data.Models
{
    public class ProjectDocument
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string DocumentName { get; set; }
        public string DocumentFile { get; set; }
        public int ProjectId { get; set; }
        [ForeignKey("ProjectId")]
        public virtual Project Project { get; set; }
    }
}
