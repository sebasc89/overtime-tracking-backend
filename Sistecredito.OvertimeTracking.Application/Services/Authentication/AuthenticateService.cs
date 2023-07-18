using AutoMapper;
using Microsoft.Extensions.Localization;
using Sistecredito.OvertimeTracking.Application.Dtos.Authentication;
using Sistecredito.OvertimeTracking.Application.Interfaces.Authentication;
using Sistecredito.OvertimeTracking.Core.Entities;
using Sistecredito.OvertimeTracking.Core.Exceptions;
using Sistecredito.OvertimeTracking.Infrastructure.Identity;
using Sistecredito.OvertimeTracking.Infrastructure.Interfaces.Authentication;
using Sistecredito.OvertimeTracking.Infrastructure.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Sistecredito.OvertimeTracking.Application.Services.Authentication
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly IAuthenticateRepository _userRepository;
        private readonly IPasswordService _passwordService;
        private readonly IMapper _mapper;
        private ResourceManager _resourceManager;

        public AuthenticateService(IAuthenticateRepository userRepository, IPasswordService passwordService, IMapper mapper)
        {
            _userRepository = userRepository;
            _passwordService = passwordService;
            _mapper = mapper;
            _resourceManager = new ResourceManager(typeof(Messages));
        }

        public async Task<User> FindUserByUserNameAsync(string userName)
        {
            var applicationUser = await _userRepository.FindByUserNameAsync(userName);

            if (applicationUser == null)
            {
                var errorMessage = _resourceManager.GetString("UserNotFound"); 
                throw new UserDomainException(string.Format(errorMessage, userName));
            }

            return _mapper.Map<User>(applicationUser);
        }

        public async Task<AuthenticationResponseDto> VerifyUserPasswordAsync(User user, string password)
        {
            var authenticationResponseDto = new AuthenticationResponseDto();

            string hashedPassword = user.PasswordHash;
            var isPasswordValid = _passwordService.VerifyPassword(password, hashedPassword);

            if (!isPasswordValid.Result)
            {
                authenticationResponseDto.Result = false;
                var errorMessage = _resourceManager.GetString("PasswordVerifyFailed");
                authenticationResponseDto.Message = errorMessage;
                throw new UserDomainException(authenticationResponseDto.Message);
            }

            authenticationResponseDto.Result = true;
            var message = _resourceManager.GetString("SuccessAuthentication");
            authenticationResponseDto.Message = message;

            return authenticationResponseDto;
        }
    }
}
