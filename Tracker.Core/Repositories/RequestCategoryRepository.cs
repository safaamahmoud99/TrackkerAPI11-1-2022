using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracker.Data.DTO;
using Tracker.Data.Models;
using Tracker.Domain.IRepositories;

namespace Tracker.Core.Repositories
{
    public class RequestCategoryRepository : IRequestCategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public RequestCategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(RequestCategoryDTO requestCategoryDTO)
        {
            try
            {
                if (requestCategoryDTO != null)
                {
                    var requestCategory = new RequestCategory();
                    requestCategory.DepartmentId = requestCategoryDTO.DepartmentId;
                    requestCategory.CategoryName = requestCategoryDTO.CategoryName;
                    _context.requestCategories.Add(requestCategory);
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
            var requestCategory = _context.requestCategories.Find(id);
            if (requestCategory != null)
            {
                _context.requestCategories.Remove(requestCategory);
                _context.SaveChanges();
            }
            else
            {
                throw new NotExistException("Not Exist Exception");
            }
        }
        public RequestCategory Find(int id)
        {
            return _context.requestCategories.Find(id);
        }

        public IEnumerable<RequestCategoryDTO> GetAll()
        {
            return _context.requestCategories.Select(cat => new RequestCategoryDTO
            {
                Id = cat.Id,
                CategoryName = cat.CategoryName,
                DepartmentId = cat.DepartmentId,
                DepartmentName = cat.Department.Name
            }).ToList();
        }

        public RequestCategoryDTO GetById(int id)
        {
            var cat = _context.requestCategories.Include(c => c.Department).Where(cat => cat.Id == id).FirstOrDefault();
            if (cat == null)
            {
                throw new NotExistException("Not Exist Exception");
            }
            else
            {
                var category = new RequestCategoryDTO
                {
                    Id = cat.Id,
                    CategoryName = cat.CategoryName,
                    DepartmentId = cat.DepartmentId,
                    DepartmentName = cat.Department.Name
                };
                return category;
            }

        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(int id, RequestCategoryDTO requestCategoryDTO)
        {
            if (id != requestCategoryDTO.Id)
            {
                throw new NotExistException("Not Exist Exception");
            }
            try
            {
                var requestCategory = new RequestCategory();
                requestCategory.DepartmentId = requestCategoryDTO.DepartmentId;
                requestCategory.CategoryName = requestCategoryDTO.CategoryName;
                _context.Entry(requestCategoryDTO).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw new NotCompletedException("Not Completed Exception");
            }

        }
    }
}
