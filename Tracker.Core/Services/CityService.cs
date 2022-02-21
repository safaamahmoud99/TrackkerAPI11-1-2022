using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data.DTO;
using Tracker.Data.Models;
using Tracker.Domain;
using Tracker.Domain.IServices;
namespace Tracker.Core.Services
{
  public  class CityService:ICityService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CityService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddCity(cityDto city)
        {
            _unitOfWork.City.Add(city);
        }

        public void DeleteCity(int CityId)
        {
            _unitOfWork.City.Delete(CityId);   
        }

        public IEnumerable<cityDto> GetAllCities()
        {
            return _unitOfWork.City.GetAll();
        }

        public cityDto GetCity(int id)
        {
            return _unitOfWork.City.Get(id);  
        }

        public IEnumerable<cityDto> GetCitybegov(int id)
        {
            return _unitOfWork.City.GetCitybegov(id);
        }

        public void UpdateCity(int CityId, cityDto city)
        {
            _unitOfWork.City.Update(CityId, city);
        }
    }
}
