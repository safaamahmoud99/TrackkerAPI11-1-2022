using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data.DTO;
using Tracker.Data.Models;
using Tracker.Domain.IRepositories;

namespace Tracker.Core.Repositories
{
    public class CityRepository : ICityRepository
    {
        private readonly ApplicationDbContext _context;
        public CityRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(cityDto cityDto)
        {
            try
            {
                if (cityDto != null)
                {
                    var city = new City();
                    city.cityName = cityDto.cityName;
                    city.GovernorateId = cityDto.governorateId;
                    _context.Cities.Add(city);
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

        public IEnumerable<cityDto> GetCitybegov(int id)
        {
            return _context.Cities.Where(r => r.GovernorateId==id).Select(cit=> new cityDto 
            {
                Id = cit.Id,
                cityName =cit.cityName,
                governorateId =cit.GovernorateId,
                governorateName =cit.Governorate.governorateName 
            }).ToList();
        }
        public void Delete(int CityId)
        {
            var City = _context.Cities.Find(CityId);
            if (City != null)
            {
                _context.Cities.Remove(City);
                _context.SaveChanges();
            }
            else
            {
                throw new NotExistException("Not Exist Exception");
            }
        }

        public cityDto Get(int id)
        {
            var cit = _context.Cities.Include(cit => cit.Governorate).Where(s => s.Id == id).FirstOrDefault();

            if (cit == null)
            {
                throw new NotExistException("Not Exist Exception");
            }
            else
            {
                var citydto = new cityDto
                {
                    Id = cit.Id,
                    cityName = cit.cityName,
                    governorateId = cit.GovernorateId,
                    governorateName = cit.Governorate.governorateName
                };
                return citydto;
            }
        }

        public IEnumerable<cityDto> GetAll()
        {

            return _context.Cities.Select(cit => new cityDto
            {
                Id = cit.Id,
                cityName = cit.cityName,
                governorateId = cit.GovernorateId,
                governorateName = cit.Governorate.governorateName
            }).ToList();
        }

        public void Update(int CityId, cityDto cityDto)
        {
            if (CityId != cityDto.Id)
            {
                throw new NotExistException("Not Exist Exception");
            }

          try
            {
                var city = new City();
                city.Id = cityDto.Id;
                city.cityName = cityDto.cityName;
                city.GovernorateId = cityDto.governorateId;
                _context.Entry(city).State = EntityState.Modified;
                _context.SaveChanges();

            }
            catch (Exception)
            {
                throw new NotCompletedException("Not Completed Exception");
            }
        }
    }
}
