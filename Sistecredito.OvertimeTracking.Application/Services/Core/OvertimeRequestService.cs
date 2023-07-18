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
    public class OvertimeRequestService : BaseService<OvertimeRequestDto, OvertimeRequest>, IOvertimeRequestService
    {
        private readonly IOvertimeRequestRepository _overtimeRequestRepository;
        private readonly IMapper _mapper;

        public OvertimeRequestService(IOvertimeRequestRepository overtimeRequestRepository, IMapper mapper)
        : base(overtimeRequestRepository, mapper)
        {
            _overtimeRequestRepository = overtimeRequestRepository;
            _mapper = mapper;
        }
    }
}
