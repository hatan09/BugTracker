using BugTracker.Core.Entities;
using BugTracker.Repository.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Repository
{
    public class StaffManager : UserManager<Staff>
    {
        public StaffManager(
            IUserStore<Staff> store,
            IOptions<IdentityOptions> optionsAccessor,
            IPasswordHasher<Staff> passwordHasher,
            IEnumerable<IUserValidator<Staff>> userValidators,
            IEnumerable<IPasswordValidator<Staff>> passwordValidators,
            ILookupNormalizer keyNormalizer,
            IdentityErrorDescriber errors,
            IServiceProvider services,
            ILogger<UserManager<Staff>> logger
        ) : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger) { }

        public new async Task<Staff?> FindByNameAsync(string userName)
        {
            var staff = await base.FindByNameAsync(userName);
            if (staff is null || staff.IsDeleted)
                return null;

            return staff;
        }

        public IQueryable<Staff> FindAll(Expression<Func<Staff, bool>>? predicate = null)
            => Users
                .Where(s => !s.IsDeleted)
                .WhereIf(predicate != null, predicate!);
    }
}
