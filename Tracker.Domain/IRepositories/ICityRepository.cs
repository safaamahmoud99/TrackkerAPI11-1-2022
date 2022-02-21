using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data.DTO;
using Tracker.Data.Models; 

namespace Tracker.Domain.IRepositories
{
  public  interface ICityRepository
    {
        cityDto  Get(int id);
        IEnumerable<cityDto> GetAll();
        void Add(cityDto city);
        void Delete(int CityId);
        void Update(int CityId, cityDto city);
        IEnumerable<cityDto>GetCitybegov(int id);
    }
}
