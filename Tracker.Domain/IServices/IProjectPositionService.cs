using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data.Models;

namespace Tracker.Domain.IServices
{
    public interface IProjectPositionService
    {
        IEnumerable<ProjectPosition> GetAllProjectPositions();
        ProjectPosition GetProjectPositionById(int id);
        void AddProjectPosition(ProjectPosition projectPosition);
        void UpdateProjectPosition(int id,ProjectPosition projectPosition);
        void DeleteProjectPosition(int id);
    }
}
