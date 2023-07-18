using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistecredito.OvertimeTracking.Core.Entities
{
    public class PayrollReport
    {
        public int ReportId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime TerminationDate { get; set; }
        public decimal OverTimeConceptValue { get; set; }

        public Employee Employee { get; set; }
    }
}
