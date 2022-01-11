using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracker.Data.Models;
using Tracker.Domain.IRepositories;

namespace Tracker.Core.Repositories
{
    public class ProjectPositionRepository : IProjectPositionRepository
    {
        private readonly ApplicationDbContext _context;
        public ProjectPositionRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(ProjectPosition projectPosition)
        {
            try
            {
                if (projectPosition != null)
                {
                    _context.projectPositions.Add(projectPosition);
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
            ProjectPosition projectPosition = _context.projectPositions.Find(id);
            if (projectPosition != null)
            {
                _context.projectPositions.Remove(projectPosition);
                _context.SaveChanges();
            }
            else
            {
                throw new NotExistException("Not Exist Exception");
            }
        }
        public ProjectPosition Find(int id)
        {
           return _context.projectPositions.Find(id);
        }

        public IEnumerable<ProjectPosition> GetAll()
        {
           return _context.projectPositions.ToList();
        }

        public ProjectPosition GetById(int id)
        {
            ProjectPosition projectPosition= _context.projectPositions.Where(p => p.Id == id).FirstOrDefault();
            if (projectPosition == null)
            {
                throw new NotExistException("Not Exist Exception");
            }
            else
            {
                return projectPosition;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(int id,ProjectPosition projectPosition)
        {
            if (id != projectPosition.Id)
            {
                throw new NotExistException("Not Exist Exception");
            }
            try
            {
                _context.Entry(projectPosition).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw new NotCompletedException("Not Completed Exception");
            }
        }
    }
}
