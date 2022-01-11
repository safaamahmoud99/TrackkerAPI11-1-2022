using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tracker.Data.DTO
{
    public class ProjectDocumentDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string DocumentName { get; set; }
        public string DocumentFile { get; set; }
        public int ProjectId { get; set; }
        public string  ProjectName { get; set; }
    }
}
