using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data.DTO;
using Tracker.Data.Models;
using Tracker.Domain.IRepositories;

namespace Tracker.Core.Repositories
{
    public class SitesRepository : ISitesRepository
    {
        private readonly ApplicationDbContext _context;
        public SitesRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(siteDto Site)
        {

            if (Site != null)
            {
                                             
                var S = new Sites();
                S.Id = Site.Id;
                S.Sitename = Site.Sitename;
                S.Phone = Site.Phone;
                S.Address = Site.Address;
                S.GovernorateId = Site.GovernorateId;
                S.CityId = Site.CityId;
                _context.Sites.Add(S);
                _context.SaveChanges();                                    
                }
            
            else
            {
                throw new NotCompletedException("Not Completed Exception");
            }
        }

        public void Delete(int SiteId)
        {
            var Site = _context.Sites.Find(SiteId);
            if (Site != null)
            {
                _context.Sites.Remove(Site);
                _context.SaveChanges();
            }
            else
            {
                throw new NotExistException("Not Exist Exception");
            }
        }

        public siteDto Get(int id)
        {
            var S = _context.Sites.Include(S => S.Governorate).Include(S=>S.City).FirstOrDefault(e => e.Id == id);
            var site = new siteDto
            {
                Id = S.Id,
                Sitename = S.Sitename,
                Phone = S.Phone,
                Address = S.Address,
                GovernorateId = S.GovernorateId,
                GovernorateName = S.Governorate.governorateName,
                CityId = S.CityId,
                CityName = S.City.cityName
            };
            if (S==null)
            {
                throw new NotExistException("site not found");
            }              
                return site;
        }

        public IEnumerable<siteDto> GetAll()
        {
            var sites = _context.Sites.Select(s => new siteDto
            {
                Id = s.Id,
                Sitename = s.Sitename,
                Phone=s.Phone,
                Address=s.Address,
                GovernorateId=s.GovernorateId,
                GovernorateName=s.Governorate.governorateName,
                CityId=s.CityId,
                CityName=s.City.cityName
            }).ToList();
            return sites;  
        }

        public void Update(int SiteId, siteDto Site)
        {
            if (SiteId!=Site.Id)
            {
                throw new NotExistException("Not Exist Exception");
            }
            else
            {
                var s = new Sites();
                s.Id = Site.Id;
                s.Sitename = Site.Sitename;
                s.GovernorateId = Site.GovernorateId;
                s.Phone = Site.Phone;
                s.Address = Site.Address;
                s.CityId = Site.CityId;            
                _context.Entry(s).State = EntityState.Modified;
                _context.SaveChanges();
            }


        }
    }
}