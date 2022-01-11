using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data.DTO;
using Tracker.Data.Models;

namespace Tracker.Domain.IServices
{
    public interface ISiteClientsService
    {
        IEnumerable<SiteClientsDTO> GetAllSiteClientsDTOs();
        //IEnumerable<Client> GetAllClientBySites(int ProjectId);
        IEnumerable<Client> GetAllUnassignedClients(int SiteId, int ProjectId);
        IEnumerable<Client> GetAllAssignedClients(int SiteId, int ProjectId);
        IEnumerable<ClientDTO> GetAllAssignedClientsByProjectId(int ProjectId);
        IEnumerable<Client> GetAllUnassignedClientsforAnotherProjectAndAssignedByThisProjectId(int SiteId, int ProjectId);
        SiteClientsDTO GetSiteClientsDTOById(int id);
        Task<IEnumerable<SiteClients>> UpdateByprojectSiteId(int projectSiteId, List<Client> clients);
        void AddSiteClientsDTO(SiteClientsDTO SiteClientsDTO);
        void UpdateSiteClientsDTO(int Id, SiteClientsDTO SiteClientsDTO);
        void DeleteSiteClientsDTO(int id);
    }
}
