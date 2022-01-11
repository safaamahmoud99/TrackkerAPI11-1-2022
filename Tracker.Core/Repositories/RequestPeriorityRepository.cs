using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracker.Data.Models;
using Tracker.Domain.IRepositories;

namespace Tracker.Core.Repositories
{
    public class RequestPeriorityRepository : IRequestPeriorityRepository
    {
        private readonly ApplicationDbContext _context;
        public RequestPeriorityRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(RequestPeriority requestPeriority)
        {
            try
            {
                if (requestPeriority != null)
                {
                    _context.requestPeriorities.Add(requestPeriority);
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
            RequestPeriority requestPeriority = _context.requestPeriorities.Find(id);
            if (requestPeriority != null)
            {
                _context.requestPeriorities.Remove(requestPeriority);
                _context.SaveChanges();
            }
            else
            {
                throw new NotExistException("Not Exist Exception");
            }
        }
        public RequestPeriority Find(int id)
        {
           return _context.requestPeriorities.Find(id);
        }

        public IEnumerable<RequestPeriority> GetAll()
        {
           return _context.requestPeriorities.ToList();
        }

        public RequestPeriority GetById(int id)
        {
            RequestPeriority requestPeriority= _context.requestPeriorities.Where(rp => rp.Id == id).FirstOrDefault();
            if (requestPeriority == null)
            {
                throw new NotExistException("Not Exist Exception");
            }
            else
            {
                return requestPeriority;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(int id,RequestPeriority requestPeriority)
        {
            throw new NotImplementedException();
        }
    }
}
