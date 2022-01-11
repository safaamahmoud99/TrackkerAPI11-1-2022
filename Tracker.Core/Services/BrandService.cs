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
    public class BrandService : IBrandService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BrandService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void AddBrand(Brand Brand)
        {
            _unitOfWork.Brand.Add(Brand);
        }

        public void DeleteBrand(int id)
        {
            _unitOfWork.Brand.Delete(id);
        }

        public IEnumerable<Brand> GetAllBrands()
        {
            return _unitOfWork.Brand.GetAll();
        }

        public Brand GetBrandById(int id)
        {
            return _unitOfWork.Brand.GetById(id);
        }

        public void UpdateBrand(int id, Brand Brand)
        {
            _unitOfWork.Brand.Update(id, Brand);
        }
    }
}
