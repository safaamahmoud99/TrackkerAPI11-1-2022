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
    public class GovernorateRepository : IGovernorateRepository
    {
        private readonly ApplicationDbContext _context;
        public GovernorateRepository(ApplicationDbContext context)
        {
            _context = context; 
        }
        public void Add(GovernorateDto governorate)
        {
            try
            {
                if (governorate != null)
                {
                    var g= new Governorate();
                    g.governorateName = governorate.governorateName;
                    _context.Add(g);
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

        public void Delete(int GovernorateId)
        {
            var Governorate  = _context.Governorates.Find(GovernorateId);
            if (Governorate != null)
            {
                _context.Governorates.Remove(Governorate);
                _context.SaveChanges();
            }
            else
            {
                throw new NotExistException("Not Exist Exception");
            }
        }

        public GovernorateDto Get(int id)
        {
            var g = _context.Governorates.Where(gov => gov.Id == id).FirstOrDefault();
            if (g == null)
            {
                throw new NotExistException("Not Exist Exception");
            }
            else
            {
                var gov = new GovernorateDto
                {
                   Id=g.Id,
                   governorateName=g.governorateName

                };
                return gov;
            }
        }

        public IEnumerable<GovernorateDto> GetAll()
        {
            return _context.Governorates.Select(gov => new GovernorateDto 
            {
                Id =gov.Id ,
                governorateName=gov.governorateName  
            }).ToList();
        }

        public void Update(int GovernorateId, GovernorateDto governorate)
        {
            if (GovernorateId !=governorate.Id)
            {
                throw new NotExistException("Not Exist Exception");
            }
            try
            {
                var g=new Governorate();
                g.Id = governorate.Id;
                g.governorateName = governorate.governorateName;
                _context.Entry(g).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new NotCompletedException("ex");
            }
        }
    }
}
