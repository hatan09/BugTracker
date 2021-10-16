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
    class CompanyRepository : BaseRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(AppDbContext context) : base(context) { }

        public async Task<Company> FindByGuidAsync(string guid, CancellationToken cancellationToken = default)
            => await FindAll(cpn => cpn.Guid.Equals(guid))
                .FirstOrDefaultAsync(cancellationToken);
    }
}
