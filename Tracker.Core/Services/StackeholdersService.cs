using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data.DTO;
using Tracker.Domain;
using Tracker.Domain.IServices;

namespace Tracker.Core.Services
{
    public class StackeholdersService : IStackeholdersService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StackeholdersService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void AddStackeholders(List<StackeholdersDTO> stackeholdersDTO)
        {
            _unitOfWork.Stackeholders.Add(stackeholdersDTO);
        }

        public void DeleteStackeholders(int id)
        {
            _unitOfWork.Stackeholders.Delete(id);
        }

        public IEnumerable<StackeholdersDTO> GetAllStackeholders()
        {
            return _unitOfWork.Stackeholders.GetAll();
        }

        public StackeholdersDTO GetStackeholdersById(int id)
        {
            return _unitOfWork.Stackeholders.GetById(id);
        }

        public IEnumerable<StackeholdersDTO> GetStackeholdersByProjectId(int ProjectId)
        {
            return _unitOfWork.Stackeholders.GetStackeholdersByProjectId(ProjectId);
        }

        public void UpdateByProjectId(int ProjectId, List<StackeholdersDTO> stackeholdersDTO)
        {
            _unitOfWork.Stackeholders.UpdateByProjectId(ProjectId,stackeholdersDTO);
        }

        public void UpdateStackeholders(int id, StackeholdersDTO stackeholdersDTO)
        {
            _unitOfWork.Stackeholders.Update(id,stackeholdersDTO);
        }
    }
}
