using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data.Models;  

namespace Tracker.Domain.IServices
{
   public interface  IDaysForAutomaticApprovedStatusService
    {
        IEnumerable<DaysforAutomticApproveStatus> GetAllDaysForAutomaticApprovedStatus();
       DaysforAutomticApproveStatus  GetDayforAutomaticApprovedStatusbyID(int id);
      
        void UpdateDaysForAutomaticApprovedStatus(int Id, DaysforAutomticApproveStatus daysforAutomticApproveStatus);
        
    }
}
