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
    public class EmployeeService : BaseService<EmployeeDto, Employee>, IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        : base(employeeRepository, mapper)
        {
            _employeeRepository = employeeRepository;   
            _mapper = mapper;
        }
    }
}
