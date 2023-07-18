using Microsoft.AspNetCore.Mvc;
using Sistecredito.OvertimeTracking.Application.Dtos.Authentication;
using Sistecredito.OvertimeTracking.Application.Helpers;
using Sistecredito.OvertimeTracking.Application.Interfaces.Authentication;
using Sistecredito.OvertimeTracking.Core.Exceptions;
using System.Net;
using System.Security.Authentication;

namespace Sistecredito.OvertimeTracking.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticateController : ControllerBase
    {
        private readonly IAuthenticateService _authService;

        public AuthenticateController(IAuthenticateService authService)
        {
            _authService = authService;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticationRequestDto authenticationRequestDto)
        {
            try
            {
                // Retrieve the user by their username
                var user = await _authService.FindUserByUserNameAsync(authenticationRequestDto.UserName);

                // Verify the user's password.
                var response = await _authService.VerifyUserPasswordAsync(user, authenticationRequestDto.Password);

                // Generate the authentication token

                return Ok(response.AsResponseDTO((int)HttpStatusCode.OK, response.Message));
            }
            catch (UserDomainException ex)
            {
                return BadRequest(ResponseExtension.AsResponseDTO((int)HttpStatusCode.InternalServerError, (int)HttpStatusCode.NotFound, ex.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseExtension.AsResponseDTO((int)HttpStatusCode.InternalServerError, (int)HttpStatusCode.InternalServerError, "Ocurrió un error en el servidor"));
            }
        }
    }

}
