using BugTracker.Contracts;
using BugTracker.Core.Database;
using BugTracker.Core.Entities;
using System.Linq;

namespace BugTracker.Repository
{
    public class BugRepository : BaseRepository<Bug>, IBugRepository
    {
        public BugRepository(AppDbContext context) : base(context) { }

        public IQueryable<Bug> FindByApp(int appId)
            => FindAll(bug => bug.AppId == appId);

        public IQueryable<Bug> FindByServerity(int appId, ServerityLevel level)
            => FindByApp(appId).Where(bug => bug.Serverity == level);

        public IQueryable<Bug> FindByStatus(int appId, ProgressStatus status)
            => FindByApp(appId).Where(bug => bug.Status == status);
    }
}
