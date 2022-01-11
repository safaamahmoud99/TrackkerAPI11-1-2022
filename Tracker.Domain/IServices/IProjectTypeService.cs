using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data.Models;

namespace Tracker.Domain.IServices
{
    public interface IProjectTypeService
    {
        IEnumerable<ProjectType> GetAllProjectTypes();
        ProjectType GetProjectTypeById(int id);
        void AddProjectType(ProjectType projectType);
        void UpdateProjectType(int id,ProjectType projectType);
        void DeleteProjectType(int id);
    }
}
