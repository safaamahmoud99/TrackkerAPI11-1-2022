using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracker.Data.DTO;
using Tracker.Data.Models;

namespace Tracker.Domain.IRepositories
{
    public interface IRequestDescriptionRepository 
    {
        IEnumerable<RequestDescriptionDTO> GetAll();
        RequestDescriptionDTO GetById(int id);
        IEnumerable<RequestDescriptionDTO> GetAllDescriptionsByRequestId(int RequestId);
        RequestDescription Find(int id);
        void Add(RequestDescriptionDTO requestDescriptionDTO);
        void Update(int id,RequestDescriptionDTO requestDescriptionDTO);
        void Delete(int id);
        void Save();
    }
}
