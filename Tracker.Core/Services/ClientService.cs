using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data.DTO;
using Tracker.Domain;
using Tracker.Domain.IServices;

namespace Tracker.Core.Services
{
    public class ClientService : IClientService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ClientService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void AddClient(ClientDTO clientDTO)
        {
            _unitOfWork.Client.Add(clientDTO);
        }

        public void DeleteClient(int id)
        {
            _unitOfWork.Client.Delete(id);
        }

        public IEnumerable<ClientDTO> GetAllClient()
        {
            return _unitOfWork.Client.GetAll();
        }

        public ClientDTO GetClientById(int id)
        {
            return _unitOfWork.Client.GetById(id);
        }

        public void UpdateClient(int id, ClientDTO clientDTO)
        {
            _unitOfWork.Client.Update(id,clientDTO);
        }
    }
}
