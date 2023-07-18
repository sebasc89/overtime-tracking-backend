using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistecredito.OvertimeTracking.Core.Entities
{
    public class LeaderArea
    {
        public int Id { get; set; }
        public int LeaderId { get; set; }
        public Employee Leader { get; set; }
        public int AreaId { get; set; }
        public Area Area { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
    }
}
