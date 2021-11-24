using BugTracker.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Contracts
{
    public interface IReportRepository : IBaseRepository<Report>
    {
        public IQueryable<Report> FindByApp(int appId);
        public IQueryable<Report> FindByBug(int bugId);
    }
}
