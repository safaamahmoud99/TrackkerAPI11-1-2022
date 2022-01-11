using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data.DTO;

namespace Tracker.Domain.IServices
{
   public interface IRequestDescriptionService
    {
        IEnumerable<RequestDescriptionDTO> GetAllRequestDescription();
        RequestDescriptionDTO GetRequestDescriptionById(int id);
        IEnumerable<RequestDescriptionDTO> GetAllDescriptionsByRequestId(int RequestId);
        void AddRequestDescription(RequestDescriptionDTO requestDescriptionDTO);
        void UpdateRequestDescription(int id,RequestDescriptionDTO requestDescriptionDTO);
        void DeleteRequestDescription(int id);
    }
}
