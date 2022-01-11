using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data.DTO;
using Tracker.Data.Models;
using Tracker.Domain;
using Tracker.Domain.IServices;

namespace Tracker.Core.Services
{
    public class OrganizationClientsService : IOrganizationClientsService
    {
        private IUnitOfWork _unitOfWork;

        public OrganizationClientsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Add(OrganizationClientsDTO organizationClientsDTO)
        {
            _unitOfWork.OrganizationClients.Add(organizationClientsDTO);
        }

        public IEnumerable<OrganizationClientsDTO> GetAll()
        {
            return _unitOfWork.OrganizationClients.GetAll();
        }

        public IEnumerable<Client> GetAllAssignedClientsByOrganizationId(int OrganizationId)
        {
            return _unitOfWork.OrganizationClients.GetAllAssignedClientsByOrganizationId(OrganizationId);
        }

        public IEnumerable<Client> GetAllAssignedClientsDataByOrganizationId(int OrganizationId)
        {
             return _unitOfWork.OrganizationClients.GetAllAssignedClientsDataByOrganizationId(OrganizationId);
        }

        public IEnumerable<Client> GetAllUnassignedClients()
        {
            return _unitOfWork.OrganizationClients.GetAllUnassignedClients();
        }

        public IEnumerable<Client> GetAllUnassignedClientsforAnotherOrganizationAndAssignedByThisOrganizationId(int OrganizationId)
        {
            return _unitOfWork.OrganizationClients.GetAllUnassignedClientsforAnotherOrganizationAndAssignedByThisOrganizationId(OrganizationId);
        }

         public IEnumerable<ProjectDTO> GetOrganizationProjectsByClientId(int ClientId)
        {
            return _unitOfWork.OrganizationClients.GetOrganizationProjectsByClientId(ClientId);
        }

        public Task<IEnumerable<OrganizationClients>> UpdateByOrganizationId(int OrganizationId, List<Client> clients)
        {
            return _unitOfWork.OrganizationClients.UpdateByOrganizationId(OrganizationId, clients);
        }
    }
}
