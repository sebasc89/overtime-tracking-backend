using Sistecredito.OvertimeTracking.Infrastructure.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistecredito.OvertimeTracking.Infrastructure.Interfaces.Authentication
{
    public interface IAuthenticateRepository
    {
        Task<ApplicationUser> FindByUserNameAsync(string userName);
    }
}
