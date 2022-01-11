using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracker.Data.Models;
using Tracker.Data.DTO;

namespace Tracker.Domain.IRepositories
{
    public interface IRequestImageRepositories
    {
        IEnumerable<requestImages> GetAll();
        requestImages GetById(int id);
        IEnumerable<RequestImageDTO> GetRequestImageByRequestId(int requestID);
        requestImages Find(int id);
        void Add(List<RequestImageDTO> request);
        void Save();
    }
}
