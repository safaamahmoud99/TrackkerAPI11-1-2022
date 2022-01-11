using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data.Models;

namespace Tracker.Domain.IServices
{
    public interface IOrganizationService
    {
        IEnumerable<Organization> GetAllOrganizations();
        Organization GetOrganizationById(int id);
        int AddOrganization(Organization organization);
        void UpdateOrganization(int id,Organization organization);
        public void DeleteOrganization(Organization organization);
    }
}
