using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data.Models;
using Tracker.Domain;
using Tracker.Domain.IServices;

namespace Tracker.Core.Services
{
    public class OriginsService : IOriginsService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OriginsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void AddOrigin(Origin origin)
        {
            _unitOfWork.Origins.Add(origin);
        }

        public void DeleteOrigin(int id)
        {
            _unitOfWork.Origins.Delete(id);
        }

        public IEnumerable<Origin> GetAllOrigins()
        {
            return _unitOfWork.Origins.GetAll();
        }

        public Origin GetOriginsById(int id)
        {
            return _unitOfWork.Origins.GetById(id);
        }

        public void UpdateOrigin(int Id, Origin origin)
        {
            _unitOfWork.Origins.Update(Id, origin);
        }
    }
}
