using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistecredito.OvertimeTracking.Core.Entities
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public bool IsActive { get; set; }
        public int AreaId { get; set; }
        public Area Area { get; set; }
        public int PositionId { get; set; }
        public Position Position { get; set; }
        public Guid ApplicationUserId { get; set; }
        public User ApplicationUser { get; set; }
        public int? LeaderId { get; set; }
        public Employee Leader { get; set; }
    }
}
