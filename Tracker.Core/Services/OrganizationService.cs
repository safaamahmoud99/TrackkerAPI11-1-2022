using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data.Models;
using Tracker.Domain;
using Tracker.Domain.IServices;

namespace Tracker.Core.Services
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrganizationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public int AddOrganization(Organization organization)
        {
            _unitOfWork.Organization.Add(organization);
            return organization.Id;
        }

        public void DeleteOrganization(Organization organization)
        {
            _unitOfWork.Organization.Delete(organization);
        }

        public IEnumerable<Organization> GetAllOrganizations()
        {
            return _unitOfWork.Organization.GetAll();
        }

        public Organization GetOrganizationById(int id)
        {
            return _unitOfWork.Organization.GetById(id);
        }

        public void UpdateOrganization(int id, Organization organization)
        {
            _unitOfWork.Organization.Update(id,organization);
        }
    }
}
