using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracker.Data.Models;
using Tracker.Domain.IRepositories;

namespace Tracker.Core.Repositories
{
    public class RequestModeRepository:IRequestModeRepository
    {
        private readonly ApplicationDbContext _context;
        public RequestModeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(RequestMode RequestMode)
        {
            try
            {
                if (RequestMode != null)
                {
                    _context.requestModes.Add(RequestMode);
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
            RequestMode RequestMode = _context.requestModes.Find(id);
            if (RequestMode != null)
            {
                _context.requestModes.Remove(RequestMode);
                _context.SaveChanges();
            }
            else
            {
                throw new NotExistException("Not Exist Exception");
            }
        }
        public RequestMode Find(int id)
        {
            return _context.requestModes.Find(id);
        }

        public IEnumerable<RequestMode> GetAll()
        {
            return _context.requestModes.ToList();
        }

        public RequestMode GetById(int id)
        {
            RequestMode requestMode= _context.requestModes.Where(d => d.Id == id).FirstOrDefault();
            if (requestMode == null)
            {
                throw new NotExistException("Not Exist Exception");
            }
            else
            {
                return requestMode;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(int id,RequestMode RequestMode)
        {
            if (id != RequestMode.Id)
            {
                throw new NotExistException("Not Exist Exception");
            }
            try
            {
                _context.Entry(RequestMode).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw new NotCompletedException("Not Completed Exception");
            }
        }
    }
}
