using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data.Models;
using Tracker.Domain.IRepositories;

namespace Tracker.Core.Repositories
{
    public class DaysForAutomaticApprovedStatusReposity : IDaysForAutomaticApprovedStatusRepository
    {
        private readonly ApplicationDbContext _context;
        public DaysForAutomaticApprovedStatusReposity(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<DaysforAutomticApproveStatus> GetAll()
        {
            return _context.DaysforAutomticApproveStatus.ToList();
        }

        public DaysforAutomticApproveStatus GetById(int id)
        {
            DaysforAutomticApproveStatus daysforAutomticApproveStatus = _context.DaysforAutomticApproveStatus.Where(a => a.Id == id).FirstOrDefault();
            if (daysforAutomticApproveStatus == null)
            {
                throw new NotExistException("Not Exist Exception");
            }
            else
            {
                return daysforAutomticApproveStatus;
            }
        }

        public void Update(int id, DaysforAutomticApproveStatus daysforAutomticApproveStatus)
        {
            if (id != daysforAutomticApproveStatus.Id)
            {
                throw new NotExistException("Not Exist Exception");
            }
            _context.Entry(daysforAutomticApproveStatus).State = EntityState.Modified;
            try
            {
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw new NotCompletedException("Not Completed Exception");
            }
        }
    }
}
