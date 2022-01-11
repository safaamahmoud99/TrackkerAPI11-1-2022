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
    public class ProjectSitesService : IProjectSitesService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProjectSitesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void AddProjectSitesDTO(ProjectSitesDTO ProjectSitesDTO)
        {
            _unitOfWork.ProjectSites.Add(ProjectSitesDTO);
        }

        public void DeleteProjectSitesDTO(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProjectSitesDTO> GetAllProjectSitesDTOs()
        {
            return _unitOfWork.ProjectSites.GetAll();
        }

        public IEnumerable<Sites> GetAllSitesByProjectId(int ProjectId)
        {
            return _unitOfWork.ProjectSites.GetAllSitesByProjectId(ProjectId);
        }

        public ProjectSites GetProjectSiteByProjectIdAndSiteId(int ProjectId, int SiteId)
        {
            return _unitOfWork.ProjectSites.GetProjectSiteByProjectIdAndSiteId(ProjectId, SiteId);
        }

        public ProjectSitesDTO GetProjectSitesDTOById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProjectSites>> Update(int ProjectId, List<Sites> LstSites)
        {
          return  _unitOfWork.ProjectSites.Update(ProjectId, LstSites);
        }
    }
}
