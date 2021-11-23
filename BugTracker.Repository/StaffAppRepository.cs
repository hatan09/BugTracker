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

        public async void UpdateLeader(int appId, string staffId, CancellationToken cancellationToken)
        {
            var staffApps = await FindAll(sa => sa.AppId == appId && sa.StaffId == staffId).FirstOrDefaultAsync(cancellationToken);

            staffApps.IsLeader = true;
            _dbSet.Update(staffApps);
        }

        public async void RemoveLeader(int appId, string staffId, CancellationToken cancellationToken)
        {
            var staffApps = await FindAll(sa => sa.AppId == appId && sa.StaffId == staffId).FirstOrDefaultAsync(cancellationToken);

            staffApps.IsLeader = false;
            _dbSet.Update(staffApps);
        }
    }
}
