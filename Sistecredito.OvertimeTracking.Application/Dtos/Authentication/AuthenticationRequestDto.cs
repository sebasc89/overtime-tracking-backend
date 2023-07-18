using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistecredito.OvertimeTracking.Application.Dtos.Authentication
{
    public class AuthenticationRequestDto
    {
        public string? UserName { get; set; }

        public string? Password { get; set; }
    }
}
