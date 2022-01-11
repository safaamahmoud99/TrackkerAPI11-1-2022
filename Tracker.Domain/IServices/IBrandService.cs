using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data.Models;

namespace Tracker.Domain.IServices
{
    public interface IBrandService
    {
        IEnumerable<Brand> GetAllBrands();
        Brand GetBrandById(int id);
        void AddBrand(Brand Brand);
        void UpdateBrand(int id,Brand Brand);
        void DeleteBrand(int id);
    }
}
