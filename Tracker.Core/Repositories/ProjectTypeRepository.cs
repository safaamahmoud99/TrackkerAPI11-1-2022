using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracker.Data.Models;
using Tracker.Domain.IRepositories;

namespace Tracker.Core.Repositories
{

    public class ProjectTypeRepository : IProjectTypeRepository
    {
        private readonly ApplicationDbContext _context;
        public ProjectTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(ProjectType projectType)
        {
            //try
            //{
                if (projectType != null && projectType.TypeName!="")
                {
                    _context.projectTypes.Add(projectType);
                    _context.SaveChanges();

                }
                else
                {
                    throw new NotCompletedException("Not Completed Exception");
                }
            //}
            //catch (Exception)
            //{
            //    throw new NotExistException("Data Not completed ");
            //}
        }

        public void Delete(int id)
        {
            ProjectType projectType = _context.projectTypes.Find(id);
            if (projectType != null)
            {
                _context.projectTypes.Remove(projectType);
                _context.SaveChanges();
            }
            else
            {
                throw new NotExistException("Not Exist Exception");
            }
        }

        public ProjectType Find(int id)
        {
            return _context.projectTypes.Find(id);
        }

        public IEnumerable<ProjectType> GetAll()
        {
            return _context.projectTypes.ToList();
        }

        public ProjectType GetById(int id)
        {
            ProjectType projectType = _context.projectTypes.Where(o => o.Id == id).FirstOrDefault();
            if (projectType == null)
            {
                throw new NotExistException("Not Exist Exception");
            }
            else
            {
                return projectType;

            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(int id, ProjectType projectType)
        {
            if (id != projectType.Id)
            {
                throw new NotExistException("Not Exist Exception");
            }
            if (projectType != null && projectType.TypeName != "")
            {
                _context.Entry(projectType).State = EntityState.Modified;
                _context.SaveChanges();
            }
            else
            {
                throw new NotCompletedException("Data Not Completed");
            }
        }
    }
}
