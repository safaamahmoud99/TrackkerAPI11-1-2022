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
    public class DueDateCategoryRepository: IDueDateCategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public DueDateCategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(DueDateCategory dueDateCategory)
        {
            try
            {
                if (dueDateCategory != null)
                {
                    _context.DueDateCategory.Add(dueDateCategory);
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
            DueDateCategory dueDateCategory = _context.DueDateCategory.Find(id);
            if (dueDateCategory != null)
            {
                _context.DueDateCategory.Remove(dueDateCategory);
                _context.SaveChanges();
            }
            else
            {
                throw new NotExistException("Not Exist Exception");
            }
        }
        public IEnumerable<DueDateCategory> GetAll()
        {
            return _context.DueDateCategory.ToList();
        }

        public DueDateCategory GetById(int id)
        {
            DueDateCategory dueDateCategory = _context.DueDateCategory.Where(a => a.Id == id).FirstOrDefault();
            if (dueDateCategory == null)
            {
                throw new NotExistException("Not Exist Exception");
            }
            else
            {
                return dueDateCategory;
            }
        }
        public void Update(int id, DueDateCategory dueDateCategory)
        {
            if (id != dueDateCategory.Id)
            {
                throw new NotExistException("Not Exist Exception");
            }
            _context.Entry(dueDateCategory).State = EntityState.Modified;
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
