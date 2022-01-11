using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracker.Data.Models;
using Tracker.Domain.IRepositories;

namespace Tracker.Core.Repositories
{
    public class OrganizationRepository : IOrganizationRepository
    {
        private readonly ApplicationDbContext _context;
        public OrganizationRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public int Add(Organization organization)
        {
            try
            {
                if (organization != null)
                {
                    Organization org = new Organization();
                    org.Id = organization.Id;
                    org.OrganizationName = organization.OrganizationName;
                    org.OrganizationCode = organization.OrganizationCode;
                    org.Address = organization.Address;
                    org.lat = organization.lat;
                    org.lng = organization.lng;
                    org.IsDeleted = false;
                    _context.organizations.Add(org);
                    _context.SaveChanges();
                    organization.Id=org.Id;
                    return organization.Id;
                }
                else
                {
                    throw new NotCompletedException("Not Completed Exception");
                }
            }
            catch (Exception)
            {
                throw new NotExistException("Not Exist Exception");
            }
        }

        public void Delete(Organization organization)
        {
            // Organization organization = Find(id);
            if (organization != null)
            {
                Organization org = new Organization();
                org.Id = organization.Id;
                org.OrganizationName = organization.OrganizationName;
                org.OrganizationCode = organization.OrganizationCode;
                org.Address = organization.Address;
                org.lat = organization.lat;
                org.lng = organization.lng;
                org.IsDeleted = true;
                _context.Entry(org).State = EntityState.Modified;
                _context.SaveChanges();
            }
            else
            {
                throw new NotExistException("Not Exist Exception");
            }
        }

        public Organization Find(int id)
        {
            return _context.organizations.Find(id);
        }

        public IEnumerable<Organization> GetAll()
        {
            var Orgs = _context.organizations.Where(o => o.IsDeleted == false).Select(organization => new Organization
            {
                Id = organization.Id,
                OrganizationName = organization.OrganizationName,
                OrganizationCode = organization.OrganizationCode,
                Address = organization.Address,
                lat = organization.lat,
                lng = organization.lng,
            }).ToList();
            return Orgs;
        }

        public Organization GetById(int id)
        {
            Organization org=  _context.organizations.Where(o => o.Id == id).FirstOrDefault();
            if (org == null)
            {
                throw new NotExistException("Not Exist Exception");
            }
            else
            {
                return org;
            }

        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(int id, Organization organization)
        {
            if (id != organization.Id)
            {
                throw new NotExistException("Not Exist Exception");
            }

            try
            {
            _context.Entry(organization).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw new NotCompletedException("Not Completed Exception");
            }
        }
    }
}
