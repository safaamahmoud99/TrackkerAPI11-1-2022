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
    public class SitesService : ISitesService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SitesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void AddSite(siteDto Site)
        {
            _unitOfWork.Sites.Add(Site);
        }

        public void DeleteSite(int SiteId)
        {
            _unitOfWork.Sites.Delete(SiteId);
        }

        public IEnumerable<siteDto> GetAllSites()
        {
            return _unitOfWork.Sites.GetAll();
        }

        public siteDto GetSite(int id)
        {
            return _unitOfWork.Sites.Get(id);
        }

        public void UpdateSite(int SiteId, siteDto Site)
        {
            _unitOfWork.Sites.Update(SiteId, Site);
        }
    }
}
