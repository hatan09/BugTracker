using BugTracker.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Contracts
{
    public interface IBugRepository : IBaseRepository<Bug>
    {
        public IQueryable<Bug> FindByApp(int appId);
        public IQueryable<Bug> FindByStatus(int appId, ProgressStatus status);
        public IQueryable<Bug> FindByServerity(int appId, ServerityLevel level);
    }
}
