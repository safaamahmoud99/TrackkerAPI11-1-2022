using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracker.Data.DTO;
using Tracker.Data.Models;

namespace Tracker.Domain.IRepositories
{
   public interface IStackeholdersRepository 
    {
        IEnumerable<StackeholdersDTO> GetAll();
        StackeholdersDTO GetById(int id);
        IEnumerable<StackeholdersDTO> GetStackeholdersByProjectId(int ProjectId);
        void UpdateByProjectId(int ProjectId, List<StackeholdersDTO> stackeholdersDTO);
        Stackeholders Find(int id);
        void Add(List<StackeholdersDTO> stackeholdersDTO);
        void Update(int id,StackeholdersDTO stackeholdersDTO);
        void Delete(int id);
        void Save();
    }
}
