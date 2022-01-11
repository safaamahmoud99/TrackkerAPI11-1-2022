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
    public class SiteClientsService : ISiteClientsService
    {
        private IUnitOfWork _unitOfWork;

        public SiteClientsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void AddSiteClientsDTO(SiteClientsDTO SiteClientsDTO)
        {
            _unitOfWork.SiteClients.Add(SiteClientsDTO);
        }

        public void DeleteSiteClientsDTO(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Client> GetAllAssignedClients(int SiteId, int ProjectId)
        {
            return _unitOfWork.SiteClients.GetAllAssignedClients(SiteId, ProjectId);
        }

        public IEnumerable<ClientDTO> GetAllAssignedClientsByProjectId(int ProjectId)
        {
            return _unitOfWork.SiteClients.GetAllAssignedClientsByProjectId(ProjectId);
        }

        public IEnumerable<SiteClientsDTO> GetAllSiteClientsDTOs()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Client> GetAllUnassignedClients(int SiteId, int ProjectId)
        {
            return _unitOfWork.SiteClients.GetAllUnassignedClients(SiteId, ProjectId);
        }

        public IEnumerable<Client> GetAllUnassignedClientsforAnotherProjectAndAssignedByThisProjectId(int SiteId, int ProjectId)
        {
            return _unitOfWork.SiteClients.GetAllUnassignedClientsforAnotherProjectAndAssignedByThisProjectId(SiteId, ProjectId);
        }

        public SiteClientsDTO GetSiteClientsDTOById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SiteClients>> UpdateByprojectSiteId(int projectSiteId, List<Client> clients)
        {
            return _unitOfWork.SiteClients.UpdateByprojectSiteId(projectSiteId,clients);
        }

        public void UpdateSiteClientsDTO(int Id, SiteClientsDTO SiteClientsDTO)
        {
            throw new NotImplementedException();
        }
    }
}
