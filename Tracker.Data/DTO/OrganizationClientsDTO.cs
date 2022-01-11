using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data.Models;

namespace Tracker.Data.DTO
{
    public class OrganizationClientsDTO
    {
        public int Id { get; set; }
        public int OrganizationId { get; set; }
        public string OrganizationName { get; set; }
        public string OrganizationCode { get; set; }
        public string Location { get; set; }
        public float? lat { get; set; }
        public float? lng { get; set; }
        public bool? IsDeleted { get; set; }
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public List<Client> Clients { get; set; }

    }
}
