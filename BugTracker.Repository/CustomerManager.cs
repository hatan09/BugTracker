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
    public class CustomerManager : UserManager<Customer>
    {
        public CustomerManager(
            IUserStore<Customer> store,
            IOptions<IdentityOptions> optionsAccessor,
            IPasswordHasher<Customer> passwordHasher,
            IEnumerable<IUserValidator<Customer>> userValidators,
            IEnumerable<IPasswordValidator<Customer>> passwordValidators,
            ILookupNormalizer keyNormalizer,
            IdentityErrorDescriber errors,
            IServiceProvider services,
            ILogger<UserManager<Customer>> logger
        ) : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger) { }

        public new async Task<Customer?> FindByNameAsync(string userName)
        {
            var user = await base.FindByNameAsync(userName);
            if (user is null || user.IsDeleted)
                return null;

            return user;
        }

        public IQueryable<Customer> FindAll(Expression<Func<Customer, bool>>? predicate = null)
            => Users
                .Where(u => !u.IsDeleted)
                .WhereIf(predicate != null, predicate!);
    }
}
