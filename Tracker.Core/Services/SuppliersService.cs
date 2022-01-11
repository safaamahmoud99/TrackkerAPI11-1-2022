using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data.Models;
using Tracker.Domain;
using Tracker.Domain.IServices;

namespace Tracker.Core.Services
{
    public class SuppliersService : ISuppliersService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SuppliersService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void AddSupplier(Supplier supplier)
        {
            _unitOfWork.Suppliers.Add(supplier);
        }

        public void DeleteSupplier(int id)
        {
            _unitOfWork.Suppliers.Delete(id);
        }

        public IEnumerable<Supplier> GetAllSuppliers()
        {
            return _unitOfWork.Suppliers.GetAll();
        }

        public Supplier GetSupplierById(int id)
        {
            return _unitOfWork.Suppliers.GetById(id);
        }

        public void UpdateSupplier(int Id, Supplier supplier)
        {
            _unitOfWork.Suppliers.Update(Id, supplier);
        }
    }
}
