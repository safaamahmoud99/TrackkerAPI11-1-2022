using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data.DTO;
using Tracker.Data.Models;

namespace Tracker.Domain.IRepositories
{
    public interface IOrganizationClientsRepository
    {
        IEnumerable<OrganizationClientsDTO> GetAll();
        IEnumerable<ProjectDTO> GetOrganizationProjectsByClientId(int ClientId);
        void Add(OrganizationClientsDTO organizationClientsDTO);
        IEnumerable<Client> GetAllUnassignedClients();
        IEnumerable<Client> GetAllAssignedClientsByOrganizationId(int OrganizationId);
        IEnumerable<Client> GetAllAssignedClientsDataByOrganizationId(int OrganizationId);
        IEnumerable<Client> GetAllUnassignedClientsforAnotherOrganizationAndAssignedByThisOrganizationId(int OrganizationId);
        Task<IEnumerable<OrganizationClients>> UpdateByOrganizationId(int OrganizationId, List<Client> clients);

    }
}
