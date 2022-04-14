using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data.Models;

namespace Tracker.Domain.IRepositories
{
  public  interface IDaysForAutomaticApprovedStatusRepository
    {
        IEnumerable<DaysforAutomticApproveStatus > GetAll();
        DaysforAutomticApproveStatus  GetById(int id);     
        void Update(int id, DaysforAutomticApproveStatus daysforAutomticApproveStatus);
      
    }
}
