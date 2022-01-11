using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracker.Data.Models;
using Tracker.Domain.IRepositories;

namespace Tracker.Core.Repositories
{
    public class RequestStatusRepository : IRequestStatusRepository
    {
        private readonly ApplicationDbContext _context;
        public RequestStatusRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(RequestStatus requestStatus)
        {
            try
            {
                if (requestStatus != null)
                {
                    _context.requestStatuses.Add(requestStatus);
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
            RequestStatus requestStatus = _context.requestStatuses.Find(id);
            if (requestStatus != null)
            {
                _context.requestStatuses.Remove(requestStatus);
                _context.SaveChanges();
            }
            else
            {
                throw new NotExistException("Not Exist Exception");
            }
        }
        public RequestStatus Find(int id)
        {
            return _context.requestStatuses.Find(id);
        }

        public IEnumerable<RequestStatus> GetAll()
        {
            return _context.requestStatuses.ToList();
        }

        public RequestStatus GetById(int id)
        {
            RequestStatus requestStatus = _context.requestStatuses.Where(s => s.Id == id).FirstOrDefault();
            if (requestStatus == null)
            {
                throw new NotExistException("Not Exist Exception");
            }
            else
            {
                return requestStatus;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(int id, RequestStatus requestStatus)
        {
            if (id != requestStatus.Id)
            {
                throw new NotExistException("Not Exist Exception");
            }
            try
            {
                _context.Entry(requestStatus).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception)
            {

            }
        }
    }
}
