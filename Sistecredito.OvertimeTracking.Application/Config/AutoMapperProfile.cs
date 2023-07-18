
using AutoMapper;
using Sistecredito.OvertimeTracking.Application.Dtos.Core;
using Sistecredito.OvertimeTracking.Core.Entities;
using Sistecredito.OvertimeTracking.Infrastructure.Identity;

namespace Sistecredito.OvertimeTracking.Application.Config
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, ApplicationUser>().ReverseMap();
            CreateMap<Area, AreaDto>().ReverseMap();
        }
    }
}
