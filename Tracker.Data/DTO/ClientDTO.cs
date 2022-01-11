using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tracker.Data.DTO
{
    public class ClientDTO
    {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public string ClientCode { get; set; }
        public int OrganizationId { get; set; }
        public string OrganizationName { get; set; }
        public string gender { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; }

    }
}
