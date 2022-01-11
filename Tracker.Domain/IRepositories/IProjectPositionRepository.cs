using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracker.Data.Models;

namespace Tracker.Domain.IRepositories
{
  public interface IProjectPositionRepository 
    {
        IEnumerable<ProjectPosition> GetAll();
        ProjectPosition GetById(int id);
        ProjectPosition Find(int id);
        void Add(ProjectPosition projectPosition);
        void Update(int id ,ProjectPosition projectPosition);
        void Delete(int id);
        void Save();
    }
}
