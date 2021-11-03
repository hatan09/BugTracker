using BugTracker.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BugTracker.Contracts
{
    public interface IAppRepository : IBaseRepository<App>
    {
        
    }
}
