using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data.DTO;

namespace Tracker.Domain.IServices
{
    public interface IClientService
    {
        IEnumerable<ClientDTO> GetAllClient();
        ClientDTO GetClientById(int id);
        void AddClient(ClientDTO clientDTO);
        void UpdateClient(int id,ClientDTO clientDTO);
        void DeleteClient(int id);
    }
}
