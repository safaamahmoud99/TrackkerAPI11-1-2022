using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracker.Data.DTO;
using Tracker.Data.Models;
using Tracker.Domain.IRepositories;
using TrackingSystemAPI.DTO;

namespace Tracker.Core.Repositories
{
    public class StackeholdersRepository : IStackeholdersRepository
    {
        private readonly ApplicationDbContext _context;
        public StackeholdersRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(List<StackeholdersDTO> stackeholdersDTO)
        {
            //List<Stackeholders> Stackeholders = new List<Stackeholders>();
            try
            {
                if (stackeholdersDTO != null)
                {
                    foreach (var item in stackeholdersDTO)
                    {

                        Stackeholders stackeholderObj = new Stackeholders();
                        stackeholderObj.StackeholderName = item.StackeholderName;
                        stackeholderObj.Mobile = item.Mobile;
                        stackeholderObj.ProjectId = item.ProjectId;
                        stackeholderObj.Rank = item.Rank;
                        stackeholderObj.Description = item.Description;
                        _context.stackeholders.Add(stackeholderObj);
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
            Stackeholders stackeholders = _context.stackeholders.Find(id);
            if (stackeholders != null)
            {
                _context.stackeholders.Remove(stackeholders);
                _context.SaveChanges();
            }
            else
            {
                throw new NotExistException("Not Exist Exception");
            }
        }
        public Stackeholders Find(int id)
        {
            return _context.stackeholders.Find(id);
        }
        public IEnumerable<StackeholdersDTO> GetAll()
        {

            var stackeholders = _context.stackeholders.Select(stack => new StackeholdersDTO
            {
                Id = stack.Id,
                StackeholderName = stack.StackeholderName,
                ProjectId = stack.ProjectId,
                ProjectName = stack.Project.ProjectName,
                Mobile = stack.Mobile,
                Rank = stack.Rank,
                Description = stack.Description
            }).ToList();
            return stackeholders;
        }
        public StackeholdersDTO GetById(int id)
        {
            var stack = _context.stackeholders.Include(p => p.Project).FirstOrDefault(e => e.Id == id);
            if (stack == null)
            {
                throw new NotExistException("Not Exist Exception");
            }
            else
            {
                StackeholdersDTO stackeholdersDTO = new StackeholdersDTO
                {
                    Id = stack.Id,
                    StackeholderName = stack.StackeholderName,
                    ProjectId = stack.ProjectId,
                    ProjectName = stack.Project.ProjectName,
                    Mobile = stack.Mobile,
                    Rank = stack.Rank,
                    Description = stack.Description
                };
                return stackeholdersDTO;
            }

        }
        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(int id, StackeholdersDTO stackeholdersDTO)
        {
            if (id != stackeholdersDTO.Id)
            {
                throw new NotExistException("Not Exist Exception");
            }
            try
            {
                Stackeholders stackeholders = new Stackeholders();
                stackeholders.Id = stackeholdersDTO.Id;
                stackeholders.StackeholderName = stackeholdersDTO.StackeholderName;
                stackeholders.Mobile = stackeholdersDTO.Mobile;
                stackeholders.Rank = stackeholdersDTO.Rank;
                stackeholders.Description = stackeholdersDTO.Description;
                stackeholders.ProjectId = stackeholdersDTO.ProjectId;
                _context.Entry(stackeholders).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw new NotCompletedException("Not Completed Exception");
            }
        }
            public IEnumerable<StackeholdersDTO> GetStackeholdersByProjectId(int ProjectId)
            {
                var stackHolder = _context.stackeholders.Where(s => s.ProjectId == ProjectId).Select(stack => new StackeholdersDTO
                {
                    Id = stack.Id,
                    StackeholderName = stack.StackeholderName,
                    ProjectId = stack.ProjectId,
                    ProjectName = stack.Project.ProjectName,
                    Mobile = stack.Mobile,
                    Rank = stack.Rank,
                    Description = stack.Description
                }).ToList();
                return stackHolder;
            }

            public void UpdateByProjectId(int ProjectId, List<StackeholdersDTO> stackeholdersDTO)
            {
            if (ProjectId != 0)
            {
                throw new NotExistException("Not Exist Exception");
            }
            try
            {
                foreach (var item in stackeholdersDTO)
                {
                    Stackeholders stackeholderObj = new Stackeholders();
                    stackeholderObj.Id = item.Id;
                    stackeholderObj.StackeholderName = item.StackeholderName;
                    stackeholderObj.Mobile = item.Mobile;
                    item.ProjectId = ProjectId;
                    stackeholderObj.ProjectId = item.ProjectId;
                    stackeholderObj.Rank = item.Rank;
                    stackeholderObj.Description = item.Description;
                    // _context.stackeholders.Add(stackeholderObj);
                    _context.Entry(stackeholderObj).State = EntityState.Modified;
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
