using Microsoft.AspNetCore.Identity;
using Sistecredito.OvertimeTracking.Core.Exceptions;
using Sistecredito.OvertimeTracking.Infrastructure.Identity;
using Sistecredito.OvertimeTracking.Infrastructure.Interfaces.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistecredito.OvertimeTracking.Infrastructure.Repositories.Authentication
{
    public class AuthenticateRepository : IAuthenticateRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AuthenticateRepository(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ApplicationUser> FindByUserNameAsync(string userName)
        {
            return await _userManager.FindByNameAsync(userName);
        }
    }
}
