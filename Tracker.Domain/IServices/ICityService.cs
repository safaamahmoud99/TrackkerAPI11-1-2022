using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data.DTO;
using Tracker.Data.Models; 

namespace Tracker.Domain.IServices
{
   public interface ICityService
    {
        cityDto GetCity(int id);
        IEnumerable<cityDto> GetAllCities();
        void AddCity(cityDto city);
        void DeleteCity(int CityId);
        void UpdateCity(int CityId,cityDto city);
        IEnumerable<cityDto> GetCitybegov(int id);


    }
}
