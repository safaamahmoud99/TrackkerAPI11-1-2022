using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracker.Data.Models;
using Tracker.Domain.IRepositories;

namespace Tracker.Core.Repositories
{
    public class RequestTypeRepository : IRequestTypeRepository
    {
        private readonly ApplicationDbContext _context;
        public RequestTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(Problems requestType)
        {
            try
            {
                if (requestType != null)
                {
                    _context.requestTypes.Add(requestType);
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
            Problems requestType = _context.requestTypes.Find(id);
            if (requestType != null)
            {
                _context.requestTypes.Remove(requestType);
                _context.SaveChanges();
            }
            else
            {
                throw new NotExistException("Not Exist Exception");
            }

        }
        public Problems Find(int id)
        {
            return _context.requestTypes.Find(id);
        }

        public IEnumerable<Problems> GetAll()
        {
            return _context.requestTypes.ToList();

        }

        public Problems GetById(int id)
        {
            Problems problems= _context.requestTypes.Where(r => r.Id == id).FirstOrDefault();
            if (problems == null)
            {
                throw new NotExistException("Not Exist Exception");
            }
            else
            {
                return problems;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(int id,Problems requestType)
        {
            throw new NotImplementedException();
        }
    }
}
