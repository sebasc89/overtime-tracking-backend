using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistecredito.OvertimeTracking.Infrastructure.Interfaces.Authentication
{
    public interface IPasswordService
    {
        string EncryptPassword(string password);
        Task<bool> VerifyPassword(string password, string hashedPassword);
    }
}
