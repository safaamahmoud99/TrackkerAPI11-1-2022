using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public void Add(Sites Site)
        {
            try
            {
                if (Site != null)
                {
                    _context.Add(Site);
                    _context.SaveChanges();
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

        public Sites Get(int id)
        {
            var Site = _context.Sites.Find(id);

            if (Site == null)
            {
                throw new NotExistException("Not Exist Exception");
            }
            else
            {
                return Site;
            }
        }

        public IEnumerable<Sites> GetAll()
        {
            return _context.Sites.ToList();
        }

        public void Update(int SiteId, Sites Site)
        {

            if (SiteId != Site.Id)
            {
                throw new NotExistException("Not Exist Exception");
            }
            _context.Entry(Site).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();

            }
            catch (Exception)
            {
                throw new NotCompletedException("Not Completed Exception");
            }
        }
    }
}