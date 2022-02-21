using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data.DTO;
using Tracker.Data.Models;  
namespace Tracker.Domain.IServices
{
  public  interface IGovernorateService
    {
        GovernorateDto GetGovernorate(int id);
        IEnumerable<GovernorateDto> GetAllGovernorates();
        void AddGovernorate(GovernorateDto governorate);
        void DeleteGovernorate(int governorateId);
        void UpdateGovernorate(int governorateid,GovernorateDto governorate);
    }
}
