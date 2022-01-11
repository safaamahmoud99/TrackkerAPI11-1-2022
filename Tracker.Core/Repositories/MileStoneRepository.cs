using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracker.Data.DTO;
using Tracker.Data.Models;
using Tracker.Domain.IRepositories;
namespace Tracker.Core.Repositories
{
    public class MileStoneRepository : IMileStoneRepository
    {
        private readonly ApplicationDbContext _context;
        public MileStoneRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(List<MileStoneDTO> mileStoneDTO)
        {
            try
            {
                if (mileStoneDTO != null)
                {
                    foreach (var item in mileStoneDTO)
                    {
                        var milestone = new MileStone();
                        milestone.Id = item.Id;
                        milestone.Title = item.Title;
                        milestone.StartDate = item.StartDate;
                        milestone.EndDate = item.EndDate;
                        milestone.Description = item.Description;
                        milestone.ProjectId = item.ProjectId;
                        _context.mileStones.Add(milestone);
                        _context.SaveChanges();
                    }
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
            MileStone mileStone = _context.mileStones.Find(id);
            if (mileStone != null)
            {
                _context.mileStones.Remove(mileStone);
                _context.SaveChanges();
            }
            else
            {
                throw new NotExistException("Not Exist Exception");
            }
        }

        public MileStone Find(int id)
        {
            return _context.mileStones.Find(id);
        }

        public IEnumerable<MileStoneDTO> GetAll()
        {
            var milestone = _context.mileStones.Select(e => new MileStoneDTO
            {
                Id = e.Id,
                Title = e.Title,
                Description = e.Description,
                ProjectId = e.ProjectId,
                ProjectName = e.Project.ProjectName,
                EndDate = e.EndDate,
                StartDate = e.StartDate
            }).ToList();
            return milestone;
        }

        public MileStoneDTO GetById(int id)
        {
            var milestone = _context.mileStones.Include(m => m.Project).FirstOrDefault(e => e.Id == id);
            var mileStoneDTO = new MileStoneDTO
            {
                Id = milestone.Id,
                Title = milestone.Title,
                Description = milestone.Description,
                EndDate = milestone.EndDate,
                StartDate = milestone.StartDate,
                ProjectName = milestone.Project.ProjectName,
                ProjectId = milestone.ProjectId,
            };
            if (milestone == null)
            {
                return null;
            }

            return mileStoneDTO;
        }
        public IEnumerable<MileStoneDTO> GetMileStonesByProjectId(int ProjectId)
        {
            var mileStone = _context.mileStones.Where(m => m.ProjectId == ProjectId).Select(mile => new MileStoneDTO
            {
                Id = mile.Id,
                Title = mile.Title,
                Description = mile.Description,
                EndDate = mile.EndDate,
                StartDate = mile.StartDate,
                ProjectName = mile.Project.ProjectName,
                ProjectId = mile.ProjectId,
            }).ToList();
            return mileStone;
        }
        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(int id, MileStoneDTO mileStoneDTO)
        {
            if (id != mileStoneDTO.Id)
            {
                throw new NotExistException("Not Exist Exception");
            }
            try
            {
                var milestone = new MileStone();
                milestone.Id = mileStoneDTO.Id;
                milestone.Title = mileStoneDTO.Title;
                milestone.Description = mileStoneDTO.Description;
                milestone.EndDate = mileStoneDTO.EndDate;
                milestone.StartDate = mileStoneDTO.StartDate;
                milestone.ProjectId = mileStoneDTO.ProjectId;
                _context.Entry(milestone).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw new NotCompletedException("Not Completed Exception");
            }
        }
        public void UpdateByProjectId(int ProjectId, List<MileStoneDTO> mileStoneDTOs)
        {
            if (ProjectId == 0)
            {
                throw new NotExistException("Not Exist Exception");
            }
            try
            {
                foreach (var item in mileStoneDTOs)
                {
                    var milestone = new MileStone();
                    milestone.Id = item.Id;
                    milestone.Title = item.Title;
                    milestone.Description = item.Description;
                    milestone.EndDate = item.EndDate;
                    milestone.StartDate = item.StartDate;
                    item.ProjectId = ProjectId;
                    milestone.ProjectId = item.ProjectId;
                    _context.Entry(milestone).State = EntityState.Modified;
                    _context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw new NotCompletedException("Not Completed Exception");
            }
        }
    }
}

