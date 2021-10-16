using BugTracker.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Repository
{
    public class AdminManager : UserManager<Admin>
    {
        public AdminManager(
            IUserStore<Admin> store,
            IOptions<IdentityOptions> optionsAccessor,
            IPasswordHasher<Admin> passwordHasher,
            IEnumerable<IUserValidator<Admin>> userValidators,
            IEnumerable<IPasswordValidator<Admin>> passwordValidators,
            ILookupNormalizer keyNormalizer,
            IdentityErrorDescriber errors,
            IServiceProvider services,
            ILogger<UserManager<Admin>> logger
        ) : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger) { }

        public new async Task<Admin?> FindByNameAsync(string userName)
        {
            var admin = await base.FindByNameAsync(userName);
            if (admin is null || admin.IsDeleted)
                return null;

            return admin;
        }
    }
}
