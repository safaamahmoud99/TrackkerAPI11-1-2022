using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data.Models;

namespace Tracker.Domain.IServices
{
    public interface IRequestModeService
    {
        IEnumerable<RequestMode> GetAllRequestMode();
        RequestMode GetRequestModeById(int id);
        RequestMode FindRequestMode(int id);
        void AddRequestMode(RequestMode RequestMode);
        void UpdateRequestMode(int id,RequestMode RequestMode);
        void DeleteRequestMode(int id);
    }
}
