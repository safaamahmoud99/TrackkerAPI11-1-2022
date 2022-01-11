using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data.DTO;
using Tracker.Data.Models;

namespace Tracker.Domain.IRepositories
{
    public interface ISiteClientsRepository
    {
        IEnumerable<SiteClientsDTO> GetAll();
        IEnumerable<Client> GetAllUnassignedClients(int SiteId, int ProjectId);
        IEnumerable<Client> GetAllUnassignedClientsforAnotherProjectAndAssignedByThisProjectId(int SiteId, int ProjectId);
        IEnumerable<Client> GetAllAssignedClients(int SiteId, int ProjectId);
        IEnumerable<ClientDTO> GetAllAssignedClientsByProjectId(int ProjectId);
        SiteClientsDTO GetById(int id);
        void Add(SiteClientsDTO SiteClientsDTO);
        Task<IEnumerable<SiteClients>> UpdateByprojectSiteId(int projectSiteId, List<Client> clients);
        void Update(int Id, SiteClientsDTO SiteClientsDTO);
        void Delete(int id);
    }
}
