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
    public class SupplierRepository : ISuppliersRepository
    {
        private readonly ApplicationDbContext _context;
        public SupplierRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Supplier supplier)
        {
            try
            {
                if (supplier != null)
                {
                    _context.Suppliers.Add(supplier);
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
            Supplier supplier = GetById(id);
            if (supplier != null)
            {
                _context.Suppliers.Remove(supplier);
                _context.SaveChanges();
            }
            else
            {
                throw new NotExistException("Not Exist Exception");
            }
        }
        public Supplier Find(int id)
        {
            return _context.Suppliers.Find(id);
        }

        public IEnumerable<Supplier> GetAll()
        {
            return _context.Suppliers.ToList();
        }

        public Supplier GetById(int id)
        {
            Supplier supplier = _context.Suppliers.Where(a => a.Id == id).FirstOrDefault();
            if (supplier == null)
            {
                throw new NotExistException("Not Exist Exception");
            }
            else
            {
                return supplier;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(int id, Supplier supplier)
        {
            if (id != supplier.Id)
            {
                throw new NotExistException("Not Exist Exception");
            }
            _context.Entry(supplier).State = EntityState.Modified;
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
