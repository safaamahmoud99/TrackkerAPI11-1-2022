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
    public class OriginsRepository : IOriginsRepository
    {
        private readonly ApplicationDbContext _context;
        public OriginsRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(Origin origin)
        {
            try
            {
                if (origin != null)
                {
                    _context.Origins.Add(origin);
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

        public void Delete(int id)
        {
            Origin origin = GetById(id);
            if (origin != null)
            {
                _context.Origins.Remove(origin);
                _context.SaveChanges();
            }
            else
            {
                throw new NotExistException("Not Exist Exception");
            }
        }

        public IEnumerable<Origin> GetAll()
        {
            return _context.Origins.ToList();
        }

        public Origin GetById(int id)
        {
            Origin origin = _context.Origins.Where(a => a.Id == id).FirstOrDefault();
            if (origin == null)
            {
                throw new NotExistException("Not Exist Exception");
            }
            else
            {
                return origin;
            }
        }

        public void Update(int Id, Origin origin)
        {
            if (Id != origin.Id)
            {
                throw new NotExistException("Not Exist Exception");
            }
            _context.Entry(origin).State = EntityState.Modified;
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
