using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracker.Data.DTO;
using Tracker.Data.Models;

namespace Tracker.Domain.IRepositories
{
    public interface ITeamRepository
    {
        IEnumerable<Team> GetAll();
        Team GetById(int id);
        Team Find(int id);
        int Add(TeamDTO team);
        void Update(int id ,Team team);
        void Save();
    }
}
