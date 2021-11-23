using BugTracker.Contracts;
using BugTracker.Core.Database;
using BugTracker.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BugTracker.Repository
{
    public class StaffAppRepository : BaseRepository<StaffApp>, IStaffAppRepository
    {
        public StaffAppRepository(AppDbContext context) : base(context) { }

        public void AssignStaff(App app, Staff staff)
        {
            Add(new StaffApp
            {
                IsLeader = false,
                App = app,
                Staff = staff
            });
        }

        public async Task<StaffApp> FindByIdAsync(int appId, string staffId, CancellationToken cancellationToken = default)
            => await _dbSet.FindAsync(appId, staffId);

        public IQueryable<StaffApp> FindByAppId(int appId, CancellationToken cancellationToken)
            => FindAll(sa => sa.AppId == appId);

        public IQueryable<StaffApp> FindByStaffId(string staffId, CancellationToken cancellationToken)
            => FindAll(sa => sa.StaffId == staffId);
    }
}
