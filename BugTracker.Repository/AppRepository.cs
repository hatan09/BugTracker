using BugTracker.Contracts;
using BugTracker.Core.Database;
using BugTracker.Core.Entities;
using BugTracker.Repository.Extensions;
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

        public override IQueryable<App> FindAll(Expression<Func<App, bool>>? predicate = null)
            => _dbSet.WhereIf(predicate != null, predicate!).Where(app => !app.IsDeleted);

        public override void Delete(App entity)
        {
            entity.IsDeleted = true;
            _dbSet.Update(entity);
        }

        public IQueryable<App> FindByCompany(int id)
            => FindAll(app => app.CompanyId == id);

        public IQueryable<App> SearchByName(string name)
        {
            var apps = FindAll(null);

            if (string.IsNullOrWhiteSpace(name)) return null;

            Search(ref apps, name);
            return apps;
        }

        private static void Search(ref IQueryable<App> apps, string name)
        {
            if (!apps.Any()) return;

            apps = apps.Where(cpn => cpn.Name.ToLower().Contains(name.Trim().ToLower()));
        }
    }
}
