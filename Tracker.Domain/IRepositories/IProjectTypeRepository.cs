using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracker.Data.Models;

namespace Tracker.Domain.IRepositories
{
   public interface IProjectTypeRepository
    {
        IEnumerable<ProjectType> GetAll();
        ProjectType GetById(int id);
        ProjectType Find(int id);
        void Add(ProjectType projectType);
        void Update(int id,ProjectType projectType);
        void Delete(int id);
        void Save();
    }

}
