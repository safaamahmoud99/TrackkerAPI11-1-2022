using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data.DTO;
using Tracker.Data.Models;  

namespace Tracker.Domain.IRepositories
{
   public interface IGovernorateRepository
    {
        GovernorateDto Get(int id);
        IEnumerable<GovernorateDto> GetAll();
        void Add(GovernorateDto governorate);
        void Delete(int GovernorateId);
        void Update(int GovernorateId,GovernorateDto governorate);
    }
}
