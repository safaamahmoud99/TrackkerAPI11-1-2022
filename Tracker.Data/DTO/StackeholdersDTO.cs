using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tracker.Data.DTO
{
    public class StackeholdersDTO
    {
        public int Id { get; set; }
        public string StackeholderName { get; set; }
        public string Mobile { get; set; }
        public string Rank { get; set; }
        public string Description { get; set; }
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
    }
}
