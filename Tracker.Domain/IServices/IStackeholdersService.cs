using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data.DTO;
using Tracker.Data.Models;

namespace Tracker.Domain.IServices
{
    public interface IStackeholdersService
    {
        IEnumerable<StackeholdersDTO> GetAllStackeholders();
        StackeholdersDTO GetStackeholdersById(int id);
        IEnumerable<StackeholdersDTO> GetStackeholdersByProjectId(int ProjectId);
        void UpdateByProjectId(int ProjectId, List<StackeholdersDTO> stackeholdersDTO);
        void AddStackeholders(List<StackeholdersDTO> stackeholdersDTO);
        void UpdateStackeholders(int id,StackeholdersDTO stackeholdersDTO);
        void DeleteStackeholders(int id);
    }
}
