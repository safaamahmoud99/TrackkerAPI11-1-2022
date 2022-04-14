using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data.Models;
using Tracker.Domain;
using Tracker.Domain.IServices;
namespace Tracker.Core.Services
{
    public class DaysForAutomaticApprovedStatusService : IDaysForAutomaticApprovedStatusService
    {
        private readonly IUnitOfWork  _unitOfWork;
        public DaysForAutomaticApprovedStatusService (IUnitOfWork unitOfWork )
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<DaysforAutomticApproveStatus> GetAllDaysForAutomaticApprovedStatus()
        {
            return _unitOfWork.DaysForAutomaticApprovedStatus.GetAll();  
        }

        public DaysforAutomticApproveStatus GetDayforAutomaticApprovedStatusbyID(int id)
        {
            return _unitOfWork.DaysForAutomaticApprovedStatus.GetById(id);   
        }

        public void UpdateDaysForAutomaticApprovedStatus(int Id, DaysforAutomticApproveStatus daysforAutomticApproveStatus)
        {
            _unitOfWork.DaysForAutomaticApprovedStatus.Update(Id, daysforAutomticApproveStatus);  
        }

        
    }
}
