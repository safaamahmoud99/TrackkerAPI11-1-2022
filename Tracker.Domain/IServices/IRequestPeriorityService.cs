using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data.DTO;
using Tracker.Data.Models;

namespace Tracker.Domain.IServices
{
   public interface IRequestPeriorityService
    {
        IEnumerable<RequestPeriority> GetAllRequestPeriority();
        RequestPeriority GetRequestPeriorityById(int id);
        void AddRequestPeriority(RequestPeriority requestPeriority);
        void UpdateRequestPeriority(int id,RequestPeriority requestPeriority);
        void DeleteRequestPeriority(int id);
    }
}
