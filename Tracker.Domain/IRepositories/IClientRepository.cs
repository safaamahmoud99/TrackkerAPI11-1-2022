using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracker.Data.DTO;
using Tracker.Data.Models;

namespace Tracker.Domain.IRepositories
{
    public interface IClientRepository
    {
        IEnumerable<ClientDTO> GetAll();
        ClientDTO GetById(int id);
        Client Find(int id);
        void Add(ClientDTO client);
        void Update(int id,ClientDTO client);
        void Delete(int id);
    }
}
