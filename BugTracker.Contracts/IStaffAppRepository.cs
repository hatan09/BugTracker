using BugTracker.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BugTracker.Contracts
{
    public interface IStaffAppRepository : IBaseRepository<StaffApp>
    {
        public Task<StaffApp> FindByIdAsync(int appId, string staffId, CancellationToken cancellationToken = default);
        public void AssignStaff(App app, Staff staff);

        public IQueryable<StaffApp> FindByAppId(int appId, CancellationToken cancellationToken);

        public IQueryable<StaffApp> FindByStaffId(string staffId, CancellationToken cancellationToken);
    }
}
