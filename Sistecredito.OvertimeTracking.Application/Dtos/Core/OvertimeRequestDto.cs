﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistecredito.OvertimeTracking.Application.Dtos.Core
{
    public class OvertimeRequestDto
    {
        public int RequestId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime RequestDate { get; set; }
        public decimal OvertimeHours { get; set; }
        public string? Reason { get; set; }
        public int ApprovalStatusId { get; set; }
        public bool? ApprovedByLeader { get; set; }
        public bool? ApprovedByHr { get; set; }
        public string? HrRejectionReason { get; set; }
    }
}
