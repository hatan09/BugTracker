using BugTracker.Contracts;
using BugTracker.Core.Database;
using BugTracker.Core.Entities;
using BugTracker.Repository.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BugTracker.Repository
{
    public class CompanyRepository : BaseRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(AppDbContext context) : base(context) { }

        public override IQueryable<Company> FindAll(Expression<Func<Company, bool>>? predicate = null)
            => _dbSet.WhereIf(predicate != null, predicate!).Where(cpn => !cpn.IsDeleted);

        public async Task<Company> FindByGuidAsync(Guid guid, CancellationToken cancellationToken = default)
            => await FindAll(cpn => cpn.Guid.Equals(guid))
                .Where(cpn => !cpn.IsDeleted)
                .FirstOrDefaultAsync(cancellationToken);

        public override void Delete(Company entity)
        {
            entity.IsDeleted = true;
            _dbSet.Update(entity);
        }

        public IQueryable<Company> SearchByName(string name)
        {
            var companies = FindAll(null);

            if (string.IsNullOrWhiteSpace(name)) return null;

            Search(ref companies, name);
            return companies;
        }

        private static void Search(ref IQueryable<Company> companies, string name)
        {
            if (!companies.Any()) return;

            companies = companies.Where(cpn => cpn.Name.ToLower().Contains(name.Trim().ToLower()));
        }
    }
}
