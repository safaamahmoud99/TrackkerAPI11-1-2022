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
    public class RequestSubCategoryRepository : IRequestSubCategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public RequestSubCategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(RequestSubCategoryDTO requestSubCategoryDTO)
        {
            try
            {
                if (requestSubCategoryDTO != null)
                {
                    var requestSubCategory = new RequestSubCategory();
                    //requestSubCategory.Id = requestSubCategoryDTO.Id;
                    requestSubCategory.RequestCategoryId = requestSubCategoryDTO.RequestCategoryId;
                    requestSubCategory.SubCategoryName = requestSubCategoryDTO.SubCategoryName;
                    _context.requestSubCategories.Add(requestSubCategory);
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
            var requestSubCategory = _context.requestSubCategories.Find(id);
            if (requestSubCategory != null)
            {
                _context.requestSubCategories.Remove(requestSubCategory);
                _context.SaveChanges();
            }
            else
            {
                throw new NotExistException("Not Exist Exception");
            }
        }
        public RequestSubCategory Find(int id)
        {
            return _context.requestSubCategories.Find(id);
        }

        public IEnumerable<RequestSubCategoryDTO> GetAll()
        {
            return _context.requestSubCategories.Select(sub => new RequestSubCategoryDTO
            {
                Id = sub.Id,
                SubCategoryName = sub.SubCategoryName,
                RequestCategoryId = sub.RequestCategoryId,
                RequestCategoryName = sub.RequestCategory.CategoryName
            }).ToList();
        }

        public RequestSubCategoryDTO GetById(int id)
        {
            var sub = _context.requestSubCategories.Include(sub => sub.RequestCategory).Where(s => s.Id == id).FirstOrDefault();

            if (sub == null)
            {
                throw new NotExistException("Not Exist Exception");
            }
            else
            {
                var requestSubCategory = new RequestSubCategoryDTO
                {
                    Id = sub.Id,
                    SubCategoryName = sub.SubCategoryName,
                    RequestCategoryId = sub.RequestCategoryId,
                    RequestCategoryName = sub.RequestCategory.CategoryName
                };
                return requestSubCategory;
            }

        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(int id, RequestSubCategoryDTO requestSubCategoryDTO)
        {
            if (id != requestSubCategoryDTO.Id)
            {
                throw new NotExistException("Not Exist Exception");
            }
            try
            {
                var requestSubCategory = new RequestSubCategory();
                requestSubCategory.Id = requestSubCategoryDTO.Id;
                requestSubCategory.RequestCategoryId = requestSubCategoryDTO.RequestCategoryId;
                requestSubCategory.SubCategoryName = requestSubCategoryDTO.SubCategoryName;
                _context.Entry(requestSubCategory).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw new NotCompletedException("Not Completed Exception");
            }

        }
    }
}
