using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracker.Data.Models;

namespace Tracker.Domain.IRepositories
{
   public interface IOrganizationRepository 
    {
        IEnumerable<Organization> GetAll();
        Organization GetById(int id);
        Organization Find(int id);
        int Add(Organization organization);
        void Update(int id,Organization organization);
        public void Delete(Organization organization);
        void Save();
    }
}
