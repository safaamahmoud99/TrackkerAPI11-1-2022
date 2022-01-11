using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracker.Data.Models;
using Tracker.Domain.IRepositories;

namespace Tracker.Core.Repositories
{
    public class ProblemsRepository : IProblemsRepository
    {
        private readonly ApplicationDbContext _context;

        public ProblemsRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(Problems problems)
        {
            try
            {
                if (problems != null)
                {
                    _context.Problems.Add(problems);
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
            var problem = _context.Problems.Find(id);
            if (problem != null)
            {
                _context.Problems.Remove(problem);
                _context.SaveChanges();
            }
            else
            {
                throw new NotExistException("Not Exist Exception");
            }
        }

        public Problems Find(int id)
        {
            return _context.Problems.Find(id);
        }

        public IEnumerable<Problems> GetAll()
        {
            return _context.Problems.ToList();
        }

        public Problems GetById(int id)
        {
            var problem = _context.Problems.Where(p => p.Id == id).FirstOrDefault();
            if (problem == null)
            {
                throw new NotExistException("Not Exist Exception");
            }
            else
            {
                return problem;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(int id, Problems problems)
        {
            if (id != problems.Id)
            {
                throw new NotExistException("Not Exist Exception");
            }
            try
            {
                _context.Entry(problems).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw new NotCompletedException("Not Completed Exception");
            }
        }
    }
}
