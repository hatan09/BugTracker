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
    public class DevManager : UserManager<Dev>
    {
        public DevManager(
            IUserStore<Dev> store,
            IOptions<IdentityOptions> optionsAccessor,
            IPasswordHasher<Dev> passwordHasher,
            IEnumerable<IUserValidator<Dev>> userValidators,
            IEnumerable<IPasswordValidator<Dev>> passwordValidators,
            ILookupNormalizer keyNormalizer,
            IdentityErrorDescriber errors,
            IServiceProvider services,
            ILogger<UserManager<Dev>> logger
        ) : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger) { }
    }
}
