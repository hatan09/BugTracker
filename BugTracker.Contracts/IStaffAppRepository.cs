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
        public void UpdateLeader(int appId, string staffId, CancellationToken cancellationToken);

        public void RemoveLeader(int appId, string staffId, CancellationToken cancellationToken);
    }
}
