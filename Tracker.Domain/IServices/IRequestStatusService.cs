using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data.Models;

namespace Tracker.Domain.IServices
{
   public interface IRequestStatusService
    {
        IEnumerable<RequestStatus> GetAllRequestStatus();
        RequestStatus GetRequestStatusById(int id);
        void AddRequestStatus(RequestStatus requestStatus);
        void UpdateRequestStatus(int id,RequestStatus requestStatus);
        void DeleteRequestStatus(int id);
    }
}
