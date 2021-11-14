using BugTracker.Contracts;
using BugTracker.Core.Database;
using BugTracker.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Repository
{
    public class ReportRepository : BaseRepository<Report>, IReportRepository
    {
        public ReportRepository(AppDbContext context) : base(context) { }

        public IQueryable<Report> FindByApp(int appId)
            => FindAll(rpt => rpt.AppId == appId);
    }
}
