using BugTracker.Contracts;
using BugTracker.Core.Database;
using BugTracker.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BugTracker.Repository
{
    public class AppRepository : BaseRepository<App>, IAppRepository
    {
        public AppRepository(AppDbContext context) : base(context) { }
    }
}
