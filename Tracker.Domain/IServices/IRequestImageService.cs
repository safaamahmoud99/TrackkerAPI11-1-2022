using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data.DTO;
using Tracker.Data.Models;

namespace Tracker.Domain.IServices
{
    public interface IRequestImageService
    {
        IEnumerable<requestImages> GetAllRequestImage();
        requestImages GetRequestImageById(int id);
        IEnumerable<RequestImageDTO> GetRequestImageByRequestId(int requestID);
        void AddRequestImage(List<RequestImageDTO> request);
    }
}
