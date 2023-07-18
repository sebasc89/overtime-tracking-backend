using Sistecredito.OvertimeTracking.Application.Dtos.Authentication;
using Sistecredito.OvertimeTracking.Core.Entities;
using Sistecredito.OvertimeTracking.Infrastructure.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistecredito.OvertimeTracking.Application.Interfaces.Authentication
{
    public interface IAuthenticateService
    {
        Task<User> FindUserByUserNameAsync(string userName);
        Task<AuthenticationResponseDto> VerifyUserPasswordAsync(User user, string password);
    }
}
