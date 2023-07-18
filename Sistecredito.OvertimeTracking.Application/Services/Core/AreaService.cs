using Sistecredito.OvertimeTracking.Application.Interfaces;
using Sistecredito.OvertimeTracking.Core.Interfaces;
using Sistecredito.OvertimeTracking.Core.Entities;
using Sistecredito.OvertimeTracking.Application.Dtos.Core;
using AutoMapper;
using Sistecredito.OvertimeTracking.Application.Interfaces.Core;
using Sistecredito.OvertimeTracking.Application.Dtos.Common;
using System.Net;
using Sistecredito.OvertimeTracking.Core.Interfaces.Repositories;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace Sistecredito.OvertimeTracking.Application.Services
{
    public class AreaService : BaseService<AreaDto, Area>, IAreaService
    {
        private readonly IAreaRepository _areaRepository;
        private readonly IMapper _mapper;

        public AreaService(IAreaRepository areaRepository,IMapper mapper)
        : base(areaRepository,mapper)
        {
            _areaRepository = areaRepository;
            _mapper = mapper;
        }
    }
}
