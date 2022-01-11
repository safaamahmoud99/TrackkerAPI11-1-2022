using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracker.Data.Models;
using Tracker.Domain.IRepositories;

namespace Tracker.Core.Repositories
{
    public class BrandRepository : IBrandRepository
    {
        private readonly ApplicationDbContext _context;
        public BrandRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(Brand Brand)
        {
            try
            {
                if (Brand != null)
                {
                    _context.Add(Brand);
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
            var brand = _context.Brand.Find(id);

            if (brand != null)
            {
                _context.Brand.Remove(brand);
                _context.SaveChanges();
            }
            else
            {

            }
        }

        public IEnumerable<Brand> GetAll()
        {
            return _context.Brand.ToList();
        }

        public Brand GetById(int id)
        {
            Brand Brand = _context.Brand.Where(a => a.Id == id).FirstOrDefault();
            if (Brand == null)
            {
                throw new NotExistException("Not Exist Exception");
            }
            else
            {
                return Brand;
            }
        }

        public void Update(int Id,Brand Brand)
        {
            if (Id != Brand.Id)
            {
                throw new NotExistException("Not Exist Exception");
            }

            try
            {
            _context.Entry(Brand).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw new NotCompletedException("Not Completed Exception");
            }
        }
    }
}
