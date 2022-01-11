using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data.Models;

namespace Tracker.Domain.IServices
{
   public interface IRequestTypeService
    {
        IEnumerable<Problems> GetAllRequestType();
        Problems GetRequestTypeById(int id);
        void AddRequestType(Problems requestType);
        void UpdateRequestType(int id, Problems requestType);
        void DeleteRequestType(int id);
    }
}
