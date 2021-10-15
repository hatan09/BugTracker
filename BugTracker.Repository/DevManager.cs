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
    public class DevManager : UserManager<Staff>
    {
        public DevManager(
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
    }
}
