using Microsoft.Extensions.DependencyInjection;
using Sistecredito.OvertimeTracking.Application.Dtos.Core;
using Sistecredito.OvertimeTracking.Application.Interfaces.Authentication;
using Sistecredito.OvertimeTracking.Application.Interfaces.Core;
using Sistecredito.OvertimeTracking.Application.Interfaces;
using Sistecredito.OvertimeTracking.Application.Services.Authentication;
using Sistecredito.OvertimeTracking.Application.Services;
using Sistecredito.OvertimeTracking.Core.Interfaces.Repositories;
using Sistecredito.OvertimeTracking.Infrastructure.Helpers.Authentication;
using Sistecredito.OvertimeTracking.Infrastructure.Interfaces.Authentication;
using Sistecredito.OvertimeTracking.Infrastructure.Repositories.Authentication;
using Sistecredito.OvertimeTracking.Infrastructure.Repositories.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistecredito.OvertimeTracking.Core.Interfaces;
using Sistecredito.OvertimeTracking.Infrastructure.Repositories;
using Sistecredito.OvertimeTracking.Core.Entities;
using Sistecredito.OvertimeTracking.Application.Services.Core;

namespace Sistecredito.OvertimeTracking.Application.Config
{
    public class DependencyInjectionConfig
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IAuthenticateRepository, AuthenticateRepository>();

            services.AddScoped<IBaseRepository<Area>, AreaRepository>();
            services.AddScoped<IAreaRepository, AreaRepository>();
            services.AddScoped<IAreaService, AreaService>();

            services.AddScoped<IBaseRepository<Position>, PositionRepository>();
            services.AddScoped<IPositionRepository, PositionRepository>();
            services.AddScoped<IPositionService, PositionService>();

            services.AddScoped<IBaseRepository<ApprovalStatus>, ApprovalStatusRepository>();
            services.AddScoped<IApprovalStatusRepository, ApprovalStatusRepository>();
            services.AddScoped<IApprovalStatusService, ApprovalStatusService>();

            services.AddScoped<IBaseRepository<OvertimeRequest>, OvertimeRequestRepository>();
            services.AddScoped<IOvertimeRequestRepository, OvertimeRequestRepository>();
            services.AddScoped<IOvertimeRequestService, OvertimeRequestService>();

            services.AddScoped<IBaseRepository<Employee>, EmployeeRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IEmployeeService, EmployeeService>();

            services.AddScoped<IAuthenticateService, AuthenticateService>();
            services.AddScoped<IPasswordService, PasswordService>();
        }
    }
}
