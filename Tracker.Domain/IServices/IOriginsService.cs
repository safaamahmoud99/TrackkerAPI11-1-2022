using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data.Models;

namespace Tracker.Domain.IServices
{
    public interface IOriginsService
    {
        IEnumerable<Origin> GetAllOrigins();
        Origin GetOriginsById(int id);
        void AddOrigin(Origin origin);
        void UpdateOrigin(int Id, Origin origin);
        void DeleteOrigin(int id);
    }
}
