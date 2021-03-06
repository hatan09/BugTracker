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
        public IQueryable<App> FindByCompany(int id);
        public IQueryable<App> SearchByName(string name);
    }
}
