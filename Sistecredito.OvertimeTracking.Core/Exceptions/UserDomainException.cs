using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistecredito.OvertimeTracking.Core.Exceptions
{
    public class UserDomainException : Exception
    {
        public UserDomainException(string message) : base(message)
        {
        }

        public UserDomainException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

}
