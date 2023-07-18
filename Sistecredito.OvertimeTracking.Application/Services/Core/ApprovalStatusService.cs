using AutoMapper;
using Sistecredito.OvertimeTracking.Application.Dtos.Core;
using Sistecredito.OvertimeTracking.Application.Interfaces.Core;
using Sistecredito.OvertimeTracking.Core.Entities;
using Sistecredito.OvertimeTracking.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistecredito.OvertimeTracking.Application.Services.Core
{
    public  class ApprovalStatusService : BaseService<ApprovalStatusDto, ApprovalStatus>, IApprovalStatusService
    {
        private readonly IApprovalStatusRepository _approvalStatusRepository;
        private readonly IMapper _mapper;

        public ApprovalStatusService(IApprovalStatusRepository approvalStatusRepository, IMapper mapper)
        : base(approvalStatusRepository, mapper)
        {
            _approvalStatusRepository = approvalStatusRepository;
            _mapper = mapper;
        }
    }
}
